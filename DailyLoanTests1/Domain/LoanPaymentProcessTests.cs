using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyLoan.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyLoan.Data.Models;

namespace DailyLoan.Domain.Tests
{
    [TestClass()]
    public class LoanPaymentProcessTests
    {
        [TestMethod()]
        public void TestLoanPaymentProcess()
        {

            // create contract with 3 periods
            Contract contract = new Contract();
            contract.ContractPeriods = new List<ContractPeriod>();
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 1, amount = 1000M, due_date = new DateTime(2026, 1, 15), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 2, amount = 1000M, due_date = new DateTime(2026, 1, 16), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 3, amount = 1000M, due_date = new DateTime(2026, 1, 17), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 4, amount = 1000M, due_date = new DateTime(2026, 1, 18), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 5, amount = 1000M, due_date = new DateTime(2026, 1, 19), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 6, amount = 1000M, due_date = new DateTime(2026, 1, 20), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 7, amount = 1000M, due_date = new DateTime(2026, 1, 21), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 8, amount = 1000M, due_date = new DateTime(2026, 1, 22), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 9, amount = 1000M, due_date = new DateTime(2026, 1, 23), });
            contract.ContractPeriods.Add(new ContractPeriod() { period_no = 10, amount = 1000M, due_date = new DateTime(2026, 1, 24), });

            // create loan payment process
            LoanPaymentProcess paymentProcess = new LoanPaymentProcess(contract);

            // verify payments
            var payments = paymentProcess.PeriodPayments;

            Assert.AreEqual(10, payments.Count);

            string msg = "After Pay #1";
            paymentProcess.AddPayment("#1", new DateTime(2026, 1, 15), "09:00", 3000M);


            Assert.AreEqual(1, payments[0].period_no, msg);
            Assert.AreEqual(1000M, payments[0].amount, msg);
            Assert.AreEqual(1000M, payments[0].paid_amount, msg);
            Assert.AreEqual(0M, payments[0].balance_amount, msg);
            Assert.AreEqual(1, payments[0].Details.Count, msg);
            Assert.AreEqual("#1", payments[0].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[0].Details[0].amount, msg);

            Assert.AreEqual(2, payments[1].period_no, msg);
            Assert.AreEqual(1000M, payments[1].amount, msg);
            Assert.AreEqual(1000M, payments[1].paid_amount, msg);
            Assert.AreEqual(0M, payments[1].balance_amount, msg);
            Assert.AreEqual(1, payments[1].Details.Count, msg);
            Assert.AreEqual("#1", payments[1].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[1].Details[0].amount, msg);

            Assert.AreEqual(3, payments[2].period_no, msg);
            Assert.AreEqual(1000M, payments[2].amount, msg);
            Assert.AreEqual(1000M, payments[2].paid_amount, msg);
            Assert.AreEqual(0M, payments[2].balance_amount, msg);
            Assert.AreEqual("#1", payments[2].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[2].Details[0].amount, msg);

            Assert.AreEqual(4, payments[3].period_no, msg);
            Assert.AreEqual(1000M, payments[3].amount, msg);
            Assert.AreEqual(0M, payments[3].paid_amount, msg);
            Assert.AreEqual(1000M, payments[3].balance_amount, msg);
            Assert.AreEqual(0, payments[3].Details.Count, msg);

            msg = "After Pay #2";
            paymentProcess.AddPayment("#2", new DateTime(2026, 1, 18), "09:00", 500M);

            Assert.AreEqual(1, payments[0].period_no, msg);
            Assert.AreEqual(1000M, payments[0].amount, msg);
            Assert.AreEqual(1000M, payments[0].paid_amount, msg);
            Assert.AreEqual(0M, payments[0].balance_amount, msg);
            Assert.AreEqual(1, payments[0].Details.Count, msg);
            Assert.AreEqual("#1", payments[0].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[0].Details[0].amount, msg);

            Assert.AreEqual(2, payments[1].period_no, msg);
            Assert.AreEqual(1000M, payments[1].amount, msg);
            Assert.AreEqual(1000M, payments[1].paid_amount, msg);
            Assert.AreEqual(0M, payments[1].balance_amount, msg);
            Assert.AreEqual(1, payments[1].Details.Count, msg);
            Assert.AreEqual("#1", payments[1].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[1].Details[0].amount, msg);

            Assert.AreEqual(3, payments[2].period_no, msg);
            Assert.AreEqual(1000M, payments[2].amount, msg);
            Assert.AreEqual(1000M, payments[2].paid_amount, msg);
            Assert.AreEqual(0M, payments[2].balance_amount, msg);
            Assert.AreEqual("#1", payments[2].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[2].Details[0].amount, msg);

            Assert.AreEqual(4, payments[3].period_no, msg);
            Assert.AreEqual(1000M, payments[3].amount, msg);
            Assert.AreEqual(500M, payments[3].paid_amount, msg);
            Assert.AreEqual(500M, payments[3].balance_amount, msg);
            Assert.AreEqual("#2", payments[3].Details[0].doc_no, msg);
            Assert.AreEqual(500M, payments[3].Details[0].amount, msg);

            Assert.AreEqual(5, payments[4].period_no, msg);
            Assert.AreEqual(1000M, payments[4].amount, msg);
            Assert.AreEqual(0M, payments[4].paid_amount, msg);
            Assert.AreEqual(1000M, payments[4].balance_amount, msg);
            Assert.AreEqual(0, payments[4].Details.Count, msg);

            msg = "After Pay #3";
            paymentProcess.AddPayment("#3", new DateTime(2026, 1, 19), "09:00", 1000M);

            Assert.AreEqual(4, payments[3].period_no, msg);
            Assert.AreEqual(1000M, payments[3].amount, msg);
            Assert.AreEqual(1000M, payments[3].paid_amount, msg);
            Assert.AreEqual(0M, payments[3].balance_amount, msg);
            Assert.AreEqual(2, payments[3].Details.Count, msg);
            Assert.AreEqual("#2", payments[3].Details[0].doc_no, msg);
            Assert.AreEqual(500M, payments[3].Details[0].amount, msg);
            Assert.AreEqual("#3", payments[3].Details[1].doc_no, msg);
            Assert.AreEqual(500M, payments[3].Details[1].amount, msg);

            Assert.AreEqual(5, payments[4].period_no, msg);
            Assert.AreEqual(1000M, payments[4].amount, msg);
            Assert.AreEqual(500M, payments[4].paid_amount, msg);
            Assert.AreEqual(500M, payments[4].balance_amount, msg);
            Assert.AreEqual(1, payments[4].Details.Count, msg);
            Assert.AreEqual("#3", payments[4].Details[0].doc_no, msg);
            Assert.AreEqual(500M, payments[4].Details[0].amount, msg);

            Assert.AreEqual(6, payments[5].period_no, msg);
            Assert.AreEqual(1000M, payments[5].amount, msg);
            Assert.AreEqual(0M, payments[5].paid_amount, msg);
            Assert.AreEqual(1000M, payments[5].balance_amount, msg);
            Assert.AreEqual(0, payments[5].Details.Count, msg);

            msg = "After Pay #4";
            paymentProcess.AddPayment("#4", new DateTime(2026, 1, 20), "09:00", 1500M);

            Assert.AreEqual(5, payments[4].period_no, msg);
            Assert.AreEqual(1000M, payments[4].amount, msg);
            Assert.AreEqual(1000M, payments[4].paid_amount, msg);
            Assert.AreEqual(0M, payments[4].balance_amount, msg);
            Assert.AreEqual(2, payments[4].Details.Count, msg);
            Assert.AreEqual("#3", payments[4].Details[0].doc_no, msg);
            Assert.AreEqual(500M, payments[4].Details[0].amount, msg);
            Assert.AreEqual("#4", payments[4].Details[1].doc_no, msg);
            Assert.AreEqual(500M, payments[4].Details[1].amount, msg);

            Assert.AreEqual(6, payments[5].period_no, msg);
            Assert.AreEqual(1000M, payments[5].amount, msg);
            Assert.AreEqual(1000M, payments[5].paid_amount, msg);
            Assert.AreEqual(0M, payments[5].balance_amount, msg);
            Assert.AreEqual(1, payments[5].Details.Count, msg);
            Assert.AreEqual("#4", payments[5].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[5].Details[0].amount, msg);

            Assert.AreEqual(7, payments[6].period_no, msg);
            Assert.AreEqual(1000M, payments[6].amount, msg);
            Assert.AreEqual(0M, payments[6].paid_amount, msg);
            Assert.AreEqual(1000M, payments[6].balance_amount, msg);
            Assert.AreEqual(0, payments[6].Details.Count, msg);

            msg = "After Pay #5";
            paymentProcess.AddPayment("#5", new DateTime(2026, 1, 21), "09:00", 1000M);

            Assert.AreEqual(6, payments[5].period_no, msg);
            Assert.AreEqual(1000M, payments[5].amount, msg);
            Assert.AreEqual(1000M, payments[5].paid_amount, msg);
            Assert.AreEqual(0M, payments[5].balance_amount, msg);
            Assert.AreEqual(1, payments[5].Details.Count, msg);
            Assert.AreEqual("#4", payments[5].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[5].Details[0].amount, msg);

            Assert.AreEqual(7, payments[6].period_no, msg);
            Assert.AreEqual(1000M, payments[6].amount, msg);
            Assert.AreEqual(1000M, payments[6].paid_amount, msg);
            Assert.AreEqual(00M, payments[6].balance_amount, msg);
            Assert.AreEqual(1, payments[6].Details.Count, msg);
            Assert.AreEqual("#5", payments[6].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[6].Details[0].amount, msg);

            Assert.AreEqual(8, payments[7].period_no, msg);
            Assert.AreEqual(1000M, payments[7].amount, msg);
            Assert.AreEqual(0M, payments[7].paid_amount, msg);
            Assert.AreEqual(1000M, payments[7].balance_amount, msg);
            Assert.AreEqual(0, payments[7].Details.Count, msg);

            msg = "After Pay #6";
            paymentProcess.AddPayment("#6", new DateTime(2026, 1, 23), "09:00", 2000M);

            Assert.AreEqual(7, payments[6].period_no, msg);
            Assert.AreEqual(1000M, payments[6].amount, msg);
            Assert.AreEqual(1000M, payments[6].paid_amount, msg);
            Assert.AreEqual(00M, payments[6].balance_amount, msg);
            Assert.AreEqual(1, payments[6].Details.Count, msg);
            Assert.AreEqual("#5", payments[6].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[6].Details[0].amount, msg);

            Assert.AreEqual(8, payments[7].period_no, msg);
            Assert.AreEqual(1000M, payments[7].amount, msg);
            Assert.AreEqual(1000M, payments[7].paid_amount, msg);
            Assert.AreEqual(0M, payments[7].balance_amount, msg);
            Assert.AreEqual(1, payments[7].Details.Count, msg);
            Assert.AreEqual("#6", payments[7].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[7].Details[0].amount, msg);


            Assert.AreEqual(9, payments[8].period_no, msg);
            Assert.AreEqual(1000M, payments[8].amount, msg);
            Assert.AreEqual(1000M, payments[8].paid_amount, msg);
            Assert.AreEqual(0M, payments[8].balance_amount, msg);
            Assert.AreEqual(1, payments[8].Details.Count, msg);
            Assert.AreEqual("#6", payments[8].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[8].Details[0].amount, msg);

            Assert.AreEqual(10, payments[9].period_no, msg);
            Assert.AreEqual(1000M, payments[9].amount, msg);
            Assert.AreEqual(0M, payments[9].paid_amount, msg);
            Assert.AreEqual(1000M, payments[9].balance_amount, msg);
            Assert.AreEqual(0, payments[9].Details.Count, msg);

            msg = "After Pay #7";
            paymentProcess.AddPayment("#7", new DateTime(2026, 1, 24), "09:00", 1000M);

            Assert.AreEqual(1, payments[0].period_no, msg);
            Assert.AreEqual(1000M, payments[0].amount, msg);
            Assert.AreEqual(1000M, payments[0].paid_amount, msg);
            Assert.AreEqual(0M, payments[0].balance_amount, msg);
            Assert.AreEqual(1, payments[0].Details.Count, msg);
            Assert.AreEqual("#1", payments[0].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[0].Details[0].amount, msg);

            Assert.AreEqual(2, payments[1].period_no, msg);
            Assert.AreEqual(1000M, payments[1].amount, msg);
            Assert.AreEqual(1000M, payments[1].paid_amount, msg);
            Assert.AreEqual(0M, payments[1].balance_amount, msg);
            Assert.AreEqual(1, payments[1].Details.Count, msg);
            Assert.AreEqual("#1", payments[1].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[1].Details[0].amount, msg);

            Assert.AreEqual(3, payments[2].period_no, msg);
            Assert.AreEqual(1000M, payments[2].amount, msg);
            Assert.AreEqual(1000M, payments[2].paid_amount, msg);
            Assert.AreEqual(0M, payments[2].balance_amount, msg);
            Assert.AreEqual("#1", payments[2].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[2].Details[0].amount, msg);


            Assert.AreEqual(4, payments[3].period_no, msg);
            Assert.AreEqual(1000M, payments[3].amount, msg);
            Assert.AreEqual(1000M, payments[3].paid_amount, msg);
            Assert.AreEqual(0M, payments[3].balance_amount, msg);
            Assert.AreEqual(2, payments[3].Details.Count, msg);
            Assert.AreEqual("#2", payments[3].Details[0].doc_no, msg);
            Assert.AreEqual(500M, payments[3].Details[0].amount, msg);
            Assert.AreEqual("#3", payments[3].Details[1].doc_no, msg);
            Assert.AreEqual(500M, payments[3].Details[1].amount, msg);

            Assert.AreEqual(5, payments[4].period_no, msg);
            Assert.AreEqual(1000M, payments[4].amount, msg);
            Assert.AreEqual(1000M, payments[4].paid_amount, msg);
            Assert.AreEqual(0M, payments[4].balance_amount, msg);
            Assert.AreEqual(2, payments[4].Details.Count, msg);
            Assert.AreEqual("#3", payments[4].Details[0].doc_no, msg);
            Assert.AreEqual(500M, payments[4].Details[0].amount, msg);
            Assert.AreEqual("#4", payments[4].Details[1].doc_no, msg);
            Assert.AreEqual(500M, payments[4].Details[1].amount, msg);

            Assert.AreEqual(6, payments[5].period_no, msg);
            Assert.AreEqual(1000M, payments[5].amount, msg);
            Assert.AreEqual(1000M, payments[5].paid_amount, msg);
            Assert.AreEqual(0M, payments[5].balance_amount, msg);
            Assert.AreEqual(1, payments[5].Details.Count, msg);
            Assert.AreEqual("#4", payments[5].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[5].Details[0].amount, msg);

            Assert.AreEqual(7, payments[6].period_no, msg);
            Assert.AreEqual(1000M, payments[6].amount, msg);
            Assert.AreEqual(1000M, payments[6].paid_amount, msg);
            Assert.AreEqual(00M, payments[6].balance_amount, msg);
            Assert.AreEqual(1, payments[6].Details.Count, msg);
            Assert.AreEqual("#5", payments[6].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[6].Details[0].amount, msg);

            Assert.AreEqual(8, payments[7].period_no, msg);
            Assert.AreEqual(1000M, payments[7].amount, msg);
            Assert.AreEqual(1000M, payments[7].paid_amount, msg);
            Assert.AreEqual(0M, payments[7].balance_amount, msg);
            Assert.AreEqual(1, payments[7].Details.Count, msg);
            Assert.AreEqual("#6", payments[7].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[7].Details[0].amount, msg);


            Assert.AreEqual(9, payments[8].period_no, msg);
            Assert.AreEqual(1000M, payments[8].amount, msg);
            Assert.AreEqual(1000M, payments[8].paid_amount, msg);
            Assert.AreEqual(0M, payments[8].balance_amount, msg);
            Assert.AreEqual(1, payments[8].Details.Count, msg);
            Assert.AreEqual("#6", payments[8].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[8].Details[0].amount, msg);

            Assert.AreEqual(10, payments[9].period_no, msg);
            Assert.AreEqual(1000M, payments[9].amount, msg);
            Assert.AreEqual(1000M, payments[9].paid_amount, msg);
            Assert.AreEqual(0M, payments[9].balance_amount, msg);
            Assert.AreEqual(1, payments[9].Details.Count, msg);
            Assert.AreEqual("#7", payments[9].Details[0].doc_no, msg);
            Assert.AreEqual(1000M, payments[9].Details[0].amount, msg);
        }
    }
}