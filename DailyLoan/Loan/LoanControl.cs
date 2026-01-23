using DailyLoan.Data.Models;
using DailyLoan.Data.Repository;
using DailyLoan.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Loan
{
    public partial class LoanControl : UserControl
    {
        bool onLoad = false;
        HolidayRepository holidayRepository = new HolidayRepository();
        ContractRepository contractRepository = new ContractRepository();

        public LoanControl()
        {
            InitializeComponent();

            this.ChangeFormMode(false);
            this._loanScreenTop1._textBoxChanged += _loanScreenTop1__textBoxChanged;
            this.showSummaryLabel(0, 0, 0);
        }

        private void _loanScreenTop1__textBoxChanged(object sender, string name)
        {
            if (name == "principle_amount" || name == "interest_rate" || name == "total_interest")
            {
                this.calcLoanRate();
            }
            else if (name == "num_of_period" || name == "amount_per_period")
            {
                calcPayPeriod();
            }
            else if (name == "first_period_date")
            {
                GenerateContractPaymentPeriod();
            }
        }

        void calcLoanRate()
        {
            decimal principle = this._loanScreenTop1._getDataNumber("principle_amount");
            decimal interestRate = this._loanScreenTop1._getDataNumber("interest_rate");
            decimal totalInterest = this._loanScreenTop1._getDataNumber("total_interest");

            if (principle > 0 && totalInterest == 0 && interestRate > 0)
            {
                // calc total interest
                totalInterest = (principle * interestRate) / 100;
                this._loanScreenTop1._setDataNumber("total_interest", totalInterest);
            }

            decimal totalLoan = principle + totalInterest;

            showSummaryLabel(totalLoan, 0, totalLoan);

        }

        void calcPayPeriod()
        {
            decimal principle = this._loanScreenTop1._getDataNumber("principle_amount");
            decimal totalInterest = this._loanScreenTop1._getDataNumber("total_interest");

            decimal totalLoan = principle + totalInterest;

            decimal amountPerPeriod = this._loanScreenTop1._getDataNumber("amount_per_period");
            int numOfPeriod = (int)this._loanScreenTop1._getDataNumber("num_of_period");

            if (amountPerPeriod > 0 && numOfPeriod == 0)
            {
                // calc num of period
                if (amountPerPeriod != 0)
                {
                    numOfPeriod = (int)Math.Ceiling(totalLoan / amountPerPeriod);
                    this._loanScreenTop1._setDataNumber("num_of_period", numOfPeriod);
                }
            }
            else if (amountPerPeriod == 0 && numOfPeriod > 0)
            {
                // calc amount per period
                if (numOfPeriod != 0)
                {
                    amountPerPeriod = totalLoan / numOfPeriod;
                    this._loanScreenTop1._setDataNumber("amount_per_period", amountPerPeriod);
                }
            }
        }

        void showSummaryLabel(decimal totalLoan, decimal totalPaid, decimal totalBalance)
        {
            this._labelTotalLoan.Text = SMLControl.Utils._numberUtils.FormatNumber(totalLoan, 2);
            this._labelTotalPaid.Text = SMLControl.Utils._numberUtils.FormatNumber(totalPaid, 2);
            this._labelTotalBalance.Text = SMLControl.Utils._numberUtils.FormatNumber(totalBalance, 2);
        }

        void GenerateContractPaymentPeriod()
        {
            this._paymentPeriodGrid1._clear();

            decimal principle = this._loanScreenTop1._getDataNumber("principle_amount");
            decimal totalInterest = this._loanScreenTop1._getDataNumber("total_interest");
            decimal totalLoan = principle + totalInterest;
            int totalPeriod = (int)this._loanScreenTop1._getDataNumber("num_of_period");
            decimal amountPerPeriod = this._loanScreenTop1._getDataNumber("amount_per_period");
            DateTime firstPayDue = this._loanScreenTop1._getDataDate("first_period_date");

            LoanType loanType = this._loanScreenTop1.getLoanType();

            if (loanType == null)
            {
                MessageBox.Show("กรุณาเลือกประเภทสินเชื่อก่อน");
                return;
            }

            if (totalPeriod > 0)
            {
                var holidays = holidayRepository.ListHoliday(firstPayDue);

                var holidayDayList = new List<DateTime>();
                foreach (var holiday in holidays)
                {
                    holidayDayList.Add(holiday.holiday_date);
                }

                LoanPeriod loanPeriod = new LoanPeriod(totalLoan, totalPeriod, amountPerPeriod, firstPayDue, 0);
                loanPeriod.ProcessDay = (ProcessDay)loanType.working_holiday_type;
                if (holidayDayList.Count > 0)
                {
                    loanPeriod.AddHolidays(holidayDayList.ToArray());
                }

                loanPeriod.CalcPeriodAmount();
                List<PayPeriod> payPeriods = loanPeriod.PayPeriods.ToList();

                this._paymentPeriodGrid1.LoadListPayPeriod(payPeriods);

                // set last period to last_due_date 
                if (payPeriods.Count > 0)
                {
                    DateTime lastDueDate = payPeriods[payPeriods.Count - 1].PayDueDate;
                    this._loanScreenTop1._setDataDate("last_period_date", lastDueDate);
                }
            }
        }

        private void _saveContractButton_Click(object sender, EventArgs e)
        {
            string checkInputRequiredMsg = this._loanScreenTop1._checkEmtryField();
            if (checkInputRequiredMsg != "")
            {
                MessageBox.Show("กรุณาระบุข้อมูลให้ครบถ้วน\r\n" + checkInputRequiredMsg, "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<PayPeriod> payPeriods = this._paymentPeriodGrid1.PayPeriods;
            if (payPeriods == null || payPeriods.Count == 0)
            {
                MessageBox.Show("กรุณาสร้างงวดการชำระเงินก่อนทำการบันทึกข้อมูล", "ไม่มีงวดการชำระเงิน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string confirmSaveMsg = "คุณต้องการบันทึกข้อมูลสัญญาสินเชื่อ ใช่หรือไม่?";
            var result = MessageBox.Show(confirmSaveMsg, "ยืนยันการบันทึกข้อมูล", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    Contract contract = this._loanScreenTop1.GetContractModel();
                    contract.ContractPeriods = new List<ContractPeriod>();

                    if (payPeriods != null)
                    {
                        foreach (var payPeriod in payPeriods)
                        {
                            ContractPeriod contractPeriod = new ContractPeriod()
                            {
                                period_no = payPeriod.PeriodNumber,
                                due_date = payPeriod.PayDueDate,
                                amount = payPeriod.PayAmount
                            };
                            contract.ContractPeriods.Add(contractPeriod);
                        }
                    }


                    contractRepository.CreateContract(contract);

                    MessageBox.Show("บันทึกข้อมูลสัญญาสินเชื่อเรียบร้อยแล้ว", "บันทึกข้อมูลสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.ClearData();
                    ChangeFormMode(false);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล \r\n" + ex.Message, "ข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }


        void ClearData()
        {
            this._loanScreenTop1._clear();
            this._paymentPeriodGrid1._clear();
        }


        private void _newContractButton_Click(object sender, EventArgs e)
        {
            this.ClearData();
            this.ChangeFormMode(true);

        }

        void ChangeFormMode(bool isEdit)
        {
            this._saveContractButton.Enabled = isEdit;
            this._discardButton.Enabled = isEdit;

            this._loanScreenTop1.LockScreen = !isEdit;
            this._searchContractButton.Enabled = !isEdit;
            this._newContractButton.Enabled = !isEdit;
            this._payButton.Enabled = false;

        }

        private void _discardButton_Click(object sender, EventArgs e)
        {
            this.ChangeFormMode(false);
            this.ClearData();
        }

        private void _searchContractButton_Click(object sender, EventArgs e)
        {
            SearchContractForm searchContractForm = new SearchContractForm();
            searchContractForm.Size = new Size(600, 400);
            searchContractForm.StartPosition = FormStartPosition.CenterParent;
            searchContractForm.AfterSelectData += (data) =>
            {
                string contractNo = data["contract_no"].ToString();
                this.LoadContract(contractNo);
                searchContractForm.Close();
            };
            searchContractForm.ShowDialog(this);
        }

        void LoadContract(string contractNo)
        {

            ContractBalance contract = contractRepository.FindContractWithBalanceByContractNo(contractNo);
            this._loanScreenTop1.LoadContractData(contract);

            List<PayPeriod> payPeriods = new List<PayPeriod>();
            foreach (var cp in contract.ContractPeriodBalances)
            {
                payPeriods.Add(new PayPeriod(cp.period_no, cp.due_date, cp.amount, cp.paid_amount, cp.over_due_amount));
            }

            this._paymentPeriodGrid1.LoadListPayPeriod(payPeriods);
            decimal totalLoan = contract.principle_amount + contract.total_interest;
            decimal totalPaid = 0M;
            decimal totalBalance = totalLoan - totalPaid;
            this.showSummaryLabel(totalLoan, totalPaid, totalBalance);
            this.ChangeFormMode(false);
            this._payButton.Enabled = true;
        }

        private void _payButton_Click(object sender, EventArgs e)
        {
            string contractNo = this._loanScreenTop1._getDataStr("contract_no");

            Contract contract = contractRepository.FindContractByContractNo(contractNo);

            PayContractForm form = new PayContractForm();
            List<PayPeriod> payPeriods = this._paymentPeriodGrid1.PayPeriods;
            form.LoadContractPeriod(contract);
            form.StartPosition = FormStartPosition.CenterScreen;
            form.ShowDialog(this);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.R:
                    {
                        this.processContractPayment();
                    }
                    return true;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        void processContractPayment()
        {
            string contractNo = this._loanScreenTop1._getDataStr("contract_no");
            ContractProcess contractProcess = new ContractProcess();
            contractProcess.StartProcessPayment(contractNo);
            MessageBox.Show("Success");

        }
    }
}
