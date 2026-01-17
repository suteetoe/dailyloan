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

        private void _saveContractButton_Click(object sender, EventArgs e)
        {
            decimal principle = this._loanScreenTop1._getDataNumber("principle");
            decimal totalInterest = this._loanScreenTop1._getDataNumber("total_interest");
            decimal totalLoan = principle + totalInterest;
            int totalPeriod = (int)this._loanScreenTop1._getDataNumber("num_of_period");
            decimal amountPerPeriod = this._loanScreenTop1._getDataNumber("amount_per_period");
            DateTime firstPayDue = this._loanScreenTop1._getDataDate("first_period_date");


            LoanPeriod loanPeriod = new LoanPeriod(totalLoan, totalPeriod, amountPerPeriod, firstPayDue, 0);
            List<PayPeriod> payPeriods = loanPeriod.PayPeriods.ToList();

            this._paymentPeriodGrid1.LoadListPayPeriod(payPeriods);
        }


        void ClearData()
        {
            this._loanScreenTop1._clear();
        }


        private void _newContractButton_Click(object sender, EventArgs e)
        {
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
    }
}
