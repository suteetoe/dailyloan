using DailyLoan.Data.Models;
using DailyLoan.Data.Repository;
using DailyLoan.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Loan
{
    public partial class ChangeContractStartDateForm : Form
    {
        string contractNo = "";
        Data.Models.Contract contract = null;
        Data.Models.LoanType loanType = null;
        ContractRepository contractRepository = new ContractRepository();
        LoanTypeRepository loanTypeRepository = new LoanTypeRepository();
        HolidayRepository holidayRepository = new HolidayRepository();

        public ChangeContractStartDateForm(string contractNo)
        {
            this.contractNo = contractNo;
            var getContract = contractRepository.FindContractByContractNo(contractNo);
            var getLoanType = loanTypeRepository.GetLoanTypeByCode(getContract.loan_type);

            InitializeComponent();
            this._changeContractStartDateScreenTop1._textBoxChanged += _changeContractStartDateScreenTop1__textBoxChanged;
            this.contract = getContract;
            this.loanType = getLoanType;

            this.Shown += ChangeContractStartDateForm_Shown;
        }

        private void _changeContractStartDateScreenTop1__textBoxChanged(object sender, string name)
        {
            if (name.Equals("new_first_period_date"))
            {
                DateTime newStratDate = this._changeContractStartDateScreenTop1._getDataDate("new_first_period_date");
                List<Holiday> holidays = holidayRepository.ListHoliday(newStratDate.Date);
                List<DateTime> Dateholidays = holidays.Select(h => h.holiday_date).ToList();

                // recalc new due date
                LoanPeriod newPeriodProcess = new LoanPeriod(contract.total_contract_amount, contract.num_of_period, contract.amount_per_period, newStratDate.Date, 0);
                newPeriodProcess.ProcessDay = (ProcessDay)loanType.working_holiday_type;
                newPeriodProcess.AddHolidays(Dateholidays.ToArray());
                newPeriodProcess.CalcPeriodAmount();
                List<PayPeriod> payPeriods = newPeriodProcess.PayPeriods.ToList();


                for (int row = 0; row < this._changeContractStartDateGrid1._rowData.Count; row++)
                {
                    int periodNo = Convert.ToInt32(this._changeContractStartDateGrid1._cellGet(row, "period_no"));
                    var newPeriod = payPeriods.Where(p => p.PeriodNumber == periodNo).FirstOrDefault();
                    if (newPeriod != null)
                    {
                        this._changeContractStartDateGrid1._cellUpdate(row, "due_date_new", newPeriod.PayDueDate, true);
                    }
                }
                this._changeContractStartDateGrid1.Invalidate();

                // set last day of period

                this._changeContractStartDateScreenTop1._setDataDate("new_last_period_date", payPeriods[payPeriods.Count - 1].PayDueDate);
            }
        }

        private void ChangeContractStartDateForm_Shown(object sender, EventArgs e)
        {
            this.SetContractData();
        }

        void SetContractData()
        {
            this._changeContractStartDateScreenTop1._setDataStr("contract_no", this.contractNo);
            this._changeContractStartDateScreenTop1._setDataDate("first_period_date", this.contract.first_period_date);
            this._changeContractStartDateScreenTop1._setDataDate("last_period_date", this.contract.last_period_date);

            this._changeContractStartDateGrid1._clear();
            foreach (var period in this.contract.ContractPeriods)
            {
                int addr = this._changeContractStartDateGrid1._addRow();
                this._changeContractStartDateGrid1._cellUpdate(addr, "period_no", period.period_no, false);
                this._changeContractStartDateGrid1._cellUpdate(addr, "due_date", period.due_date, true);

            }
            this._changeContractStartDateGrid1.Invalidate();
        }

        private void _processButton_Click(object sender, EventArgs e)
        {
            // update date contract
            string confirmUpdateMessage = "คุณต้องการเปลี่ยนวันที่เริ่มชำระของสัญญา " + this.contractNo + " ใช่หรือไม่?";
            if (MessageBox.Show(confirmUpdateMessage, "ยืนยัน", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            DateTime newStratDate = this._changeContractStartDateScreenTop1._getDataDate("new_first_period_date");
            List<Holiday> holidays = holidayRepository.ListHoliday(newStratDate.Date);
            List<DateTime> Dateholidays = holidays.Select(h => h.holiday_date).ToList();

            LoanPeriod newPeriodProcess = new LoanPeriod(contract.total_contract_amount, contract.num_of_period, contract.amount_per_period, newStratDate.Date, 0);
            newPeriodProcess.ProcessDay = (ProcessDay)loanType.working_holiday_type;
            newPeriodProcess.AddHolidays(Dateholidays.ToArray());
            newPeriodProcess.CalcPeriodAmount();


            List<PayPeriod> payPeriods = newPeriodProcess.PayPeriods.ToList();
            DateTime lastDuePeriod = payPeriods[payPeriods.Count - 1].PayDueDate;

            var diffPeriod = newPeriodProcess.DiffContractPeriodDate(contract.ContractPeriods.ToArray());
            if (diffPeriod.Count > 0)
            {
                foreach (var period in diffPeriod)
                {
                    contractRepository.UpdateContractPeriodDueDate(contractNo, period.PeriodNumber, period.PayDueDate);
                }
            }
            contractRepository.UpdateContractFirstPeriodDue(contractNo, newStratDate.Date, lastDuePeriod.Date);
            this.DialogResult = DialogResult.OK;

        }
    }
}
