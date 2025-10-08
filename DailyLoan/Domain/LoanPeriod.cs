using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Domain
{
    public class LoanPeriod
    {
        decimal totalLoan;
        int totalPeriod;
        decimal payPeriodAmount;

        List<PayPeriod> payPeriods;

        public IEnumerable<PayPeriod> PayPeriods { get { return this.payPeriods; } }

        public LoanPeriod(decimal totalLoan, int totalPeriod, decimal payPeriodAmount)
        {
            this.totalLoan = totalLoan;
            this.totalPeriod = totalPeriod;
            this.payPeriodAmount = payPeriodAmount;
            this.payPeriods = new List<PayPeriod>();
            CalcPeriodAmount();
        }

        void CalcPeriodAmount()
        {
            decimal totalPayAmount = 0M;

            for (int i = 0; i < this.totalPeriod; i++)
            {
                decimal payAmount = this.payPeriodAmount;
                if (i == this.totalPeriod - 1)
                {
                    payAmount = this.totalLoan - totalPayAmount;
                }
                totalPayAmount += payAmount;
                this.payPeriods.Add(new PayPeriod(i + 1, payAmount));
            }

            decimal payDiffAmount = (this.totalLoan - totalPayAmount);
            if (payDiffAmount != 0 && this.payPeriods.Count > 0)
            {
                PayPeriod lastPeriod = this.payPeriods[this.payPeriods.Count - 1];
                this.payPeriods[this.payPeriods.Count - 1] = new PayPeriod(lastPeriod.PeriodNumber, lastPeriod.PayAmount + payDiffAmount);
            }

        }
    }

    public class PayPeriod
    {
        int periodNumber;
        decimal payAmount;

        public int PeriodNumber { get { return this.periodNumber; } }
        public decimal PayAmount { get { return this.payAmount; } }

        public PayPeriod(int periodNumber, decimal payAmount)
        {
            this.periodNumber = periodNumber;
            this.payAmount = payAmount;
        }
    }

}