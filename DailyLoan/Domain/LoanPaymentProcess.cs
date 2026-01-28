using DailyLoan.Data.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
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
        private decimal _totalPayAmount = 0M;
        private decimal _totalPaidPrincipal = 0M;
        private decimal _totalPaidInterest = 0M;

        public decimal TotalPaidPrincipal
        {
            get
            {
                return this._totalPaidPrincipal;
            }
        }

        public decimal TotalPaidInterest
        {
            get
            {
                return this._totalPaidInterest;
            }
        }

        public decimal totalPayAmount
        {
            get
            {
                return this._totalPayAmount;
            }
        }

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
            this._totalPayAmount += pay_amount;

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
                period.pay_principal_amount = contractPeriodPayments[i].pay_principal_amount;
                period.pay_interest_amount = contractPeriodPayments[i].pay_interest_amount;
                result.Add(period);
            }

            return result;
        }

        public void CalcPrincipleAndInterest()
        {
            _totalPaidPrincipal = 0M;
            _totalPaidInterest = 0M;

            for (int i = 0; i < contractPeriodPayments.Count; i++)
            {
                decimal periodPaidAmount = contractPeriodPayments[i].paid_amount;
                if (periodPaidAmount > 0)
                {
                    decimal interestAmount = Math.Round((periodPaidAmount * contract.interest_rate) / 100M, 2);
                    decimal principalAmount = periodPaidAmount - interestAmount;

                    contractPeriodPayments[i].pay_principal_amount = principalAmount;
                    contractPeriodPayments[i].pay_interest_amount = interestAmount;


                    // last period
                    if (i == contractPeriodPayments.Count - 1)
                    {
                        decimal totalPrincipalPaid = 0M;
                        decimal totalInterestPaid = 0M;
                        for (int j = 0; j < contractPeriodPayments.Count - 1; j++)
                        {
                            totalPrincipalPaid += contractPeriodPayments[j].pay_principal_amount;
                            totalInterestPaid += contractPeriodPayments[j].pay_interest_amount;
                        }

                        contractPeriodPayments[i].pay_principal_amount = contract.principle_amount - totalPrincipalPaid;
                        contractPeriodPayments[i].pay_interest_amount = contract.total_interest - totalInterestPaid;
                    }

                    _totalPaidPrincipal += contractPeriodPayments[i].pay_principal_amount;
                    _totalPaidInterest += contractPeriodPayments[i].pay_interest_amount;

                }
            }


        }

        public int PaySuccessPeriodCount()
        {
            int count = 0;
            for (int i = 0; i < contractPeriodPayments.Count; i++)
            {
                if (contractPeriodPayments[i].balance_amount <= 0)
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            return count;
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

        public decimal pay_principal_amount { get; set; }

        public decimal pay_interest_amount { get; set; }

        public List<ContractPeriodPaymentDetail> Details { get; set; }
    }

}
