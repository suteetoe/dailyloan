using DailyLoan.Data.Models;
using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Domain
{
    public class LoanPaymentProcess
    {
        List<ContractPayPeriod> contractPeriodPayments = new List<ContractPayPeriod>();
        Contract contract;
        public List<ContractPayPeriod> PeriodPayments
        {
            get
            {
                return contractPeriodPayments;
            }
        }

        public LoanPaymentProcess(Contract contract)
        {
            this.contract = contract;
            foreach (var period in contract.ContractPeriods)
            {
                ContractPayPeriod payment = new ContractPayPeriod();
                payment.Details = new List<ContractPeriodPaymentDetail>();

                payment.period_no = period.period_no;
                payment.amount = period.amount;

                contractPeriodPayments.Add(payment);
            }
        }

        public void AddPayment(string doc_do, DateTime doc_date, string doc_time, decimal pay_amount)
        {
            decimal remainingPayAmount = pay_amount;
            for (int i = 0; i < contractPeriodPayments.Count; i++)
            {
                ContractPayPeriod payPeriod = contractPeriodPayments[i];
                if (payPeriod.balance_amount > 0 && remainingPayAmount > 0)
                {
                    decimal payThisPeriod = 0M;
                    if (remainingPayAmount >= payPeriod.balance_amount)
                    {
                        payThisPeriod = payPeriod.balance_amount;
                    }
                    else
                    {
                        payThisPeriod = remainingPayAmount;
                    }

                    // add payment detail for this period
                    ContractPeriodPaymentDetail detail = new ContractPeriodPaymentDetail();
                    detail.doc_no = doc_do;
                    detail.doc_date = doc_date;
                    detail.doc_time = doc_time;
                    detail.amount = payThisPeriod;

                    contractPeriodPayments[i].Details.Add(detail);
                    contractPeriodPayments[i].paid_amount += payThisPeriod;

                    remainingPayAmount -= payThisPeriod;
                }

                // stop if no remaining amount
                if (remainingPayAmount <= 0)
                {
                    break;
                }
            }
        }

        public List<ContractPeriodPayment> GetResult()
        {
            List<ContractPeriodPayment> result = new List<ContractPeriodPayment>();

            for (int i = 0; i < contractPeriodPayments.Count; i++)
            {
                ContractPeriodPayment period = new ContractPeriodPayment();
                period.contract_no = contract.contract_no;
                period.period_no = contractPeriodPayments[i].period_no;
                period.pay_amount = contractPeriodPayments[i].paid_amount;
                period.pay_detail = contractPeriodPayments[i].Details;

                result.Add(period);
            }

            return result;
        }
    }

    public class ContractPayPeriod
    {
        public int period_no { get; set; }

        public decimal amount { get; set; } = 0M;

        public decimal paid_amount { get; set; } = 0M;

        public decimal balance_amount
        {
            get
            {
                return amount - paid_amount;
            }
        }

        public List<ContractPeriodPaymentDetail> Details { get; set; }
    }

}
