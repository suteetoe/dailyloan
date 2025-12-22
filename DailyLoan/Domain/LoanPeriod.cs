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

        DateTime startPayDate;
        int periodType = 0; // 0=day, 1=week, 2=month


        public IEnumerable<PayPeriod> PayPeriods { get { return this.payPeriods; } }

        public LoanPeriod(decimal totalLoan, int totalPeriod, decimal payPeriodAmount, DateTime startPayDate, int periodType)
        {
            this.totalLoan = totalLoan;
            this.totalPeriod = totalPeriod;
            this.payPeriodAmount = payPeriodAmount;
            this.payPeriods = new List<PayPeriod>();
            this.startPayDate = startPayDate;
            this.periodType = periodType;
            CalcPeriodAmount();
        }

        void CalcPeriodAmount()
        {
            decimal totalPayAmount = 0M;
            DateTime duePayment = this.startPayDate;

            for (int i = 0; i < this.totalPeriod; i++)
            {
                decimal payAmount = this.payPeriodAmount;
                if (i == this.totalPeriod - 1)
                {
                    payAmount = this.totalLoan - totalPayAmount;
                }
                totalPayAmount += payAmount;


                this.payPeriods.Add(new PayPeriod(i + 1, duePayment, payAmount));

                switch (this.periodType)
                {
                    case 0:
                        duePayment = duePayment.AddDays(1);
                        break;
                    case 1:
                        duePayment = duePayment.AddDays(7);
                        break;
                    case 2:
                        duePayment = duePayment.AddMonths(1);
                        break;
                };
            }

            decimal payDiffAmount = (this.totalLoan - totalPayAmount);
            if (payDiffAmount != 0 && this.payPeriods.Count > 0)
            {
                PayPeriod lastPeriod = this.payPeriods[this.payPeriods.Count - 1];
                this.payPeriods[this.payPeriods.Count - 1] = new PayPeriod(lastPeriod.PeriodNumber, duePayment, lastPeriod.PayAmount + payDiffAmount);
            }
        }
    }

    public class PayPeriod
    {
        int periodNumber;
        decimal payAmount;
        DateTime payDueDate;

        public int PeriodNumber { get { return this.periodNumber; } }
        public decimal PayAmount { get { return this.payAmount; } }

        public DateTime PayDueDate { get { return this.payDueDate; } }

        public PayPeriod(int periodNumber, DateTime payDueDate, decimal payAmount)
        {
            this.periodNumber = periodNumber;
            this.payAmount = payAmount;
            this.payDueDate = payDueDate;
        }
    }

}