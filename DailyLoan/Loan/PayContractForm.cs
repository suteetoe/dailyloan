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
    public partial class PayContractForm : Form
    {
        public const string DOC_FORMAT = "@YYMM######";
        public const string DOC_PREFIX = "EE";


        ContractPayRepository contractPayRepository = new ContractPayRepository();

        Data.Models.Contract contract;
        public PayContractForm()
        {
            InitializeComponent();

            this._payPeriodGrid1._alterCellUpdate += _payPeriodGrid1__alterCellUpdate;
        }

        private void _payPeriodGrid1__alterCellUpdate(object sender, int row, int column)
        {

            if (column == 0)
            {
                updatePaymentAmount();
            }
        }

        void updatePaymentAmount()
        {
            decimal totalAmount = 0M;
            for (int i = 0; i < this._payPeriodGrid1._rowData.Count; i++)
            {
                string isChecked = this._payPeriodGrid1._cellGet(i, 0).ToString();
                if (isChecked == "1")
                {
                    decimal amount = (decimal)this._payPeriodGrid1._cellGet(i, "amount");
                    totalAmount += amount;
                }
            }

            this._payAmountTextbox._setDataNumber = (decimal)totalAmount;
        }

        public void LoadContractPeriod(Data.Models.Contract contract)
        {

            this.contract = contract;

            this._payPeriodGrid1._clear();

            foreach (var period in this.contract.ContractPeriods)
            {
                int addRowIdx = this._payPeriodGrid1._addRow();
                this._payPeriodGrid1._cellUpdate(addRowIdx, "period_no", period.period_no, false);
                this._payPeriodGrid1._cellUpdate(addRowIdx, "due_date", period.due_date, true);
                this._payPeriodGrid1._cellUpdate(addRowIdx, "amount", period.amount, false);
            }
            this.Invalidate();

        }

        private void _payButton_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime payDateTime = DateTime.Now;

                string newDocNo = contractPayRepository.NextDocNo(DOC_PREFIX, DateTime.Now, DOC_FORMAT);

                Data.Models.ContractPay contractPay = new Data.Models.ContractPay();
                contractPay.doc_no = newDocNo;
                contractPay.doc_date = payDateTime;
                contractPay.doc_time = payDateTime.ToString("HH:mm");
                contractPay.contract_no = this.contract.contract_no;
                contractPay.total_amount = this._payAmountTextbox._double;

                contractPayRepository.CreateContractPayment(contractPay);

                MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว");

                ContractProcess contractProcess = new ContractProcess();
                contractProcess.StartProcessPayment(this.contract.contract_no);

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
        }
    }
}
