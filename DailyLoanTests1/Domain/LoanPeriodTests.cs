using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyLoan.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using DailyLoan.Data.Models;
using System.Runtime.InteropServices.ComTypes;

namespace DailyLoan.Domain.Tests
{
    [TestClass()]
    public class LoanPeriodTests
    {
        [TestMethod()]
        public void CalcPeriodAmountTest()
        {
            LoanPeriod loanPeriod = new LoanPeriod(24000, 20, 1200, new DateTime(), PeriodType.Day);
            loanPeriod.CalcPeriodAmount();

            decimal totalPayAmount = 0M;
            foreach (var payPeriod in loanPeriod.PayPeriods)
            {
                totalPayAmount += payPeriod.PayAmount;
            }
            Assert.AreEqual(24000M, totalPayAmount);

        }

        [TestMethod()]
        public void CalcPeriodAmountMonFriTest()
        {
            DateTime startDate = new DateTime(2026, 1, 1); // Thursday
            LoanPeriod loanPeriod = new LoanPeriod(24000, 20, 1200, startDate, PeriodType.Day);
            loanPeriod.ProcessDay = ProcessDay.MON_FRI;
            loanPeriod.CalcPeriodAmount();


            DateTime expectedDate = startDate;
            foreach (var payPeriod in loanPeriod.PayPeriods)
            {
                // skip Saturday and Sunday
                while (expectedDate.DayOfWeek == DayOfWeek.Saturday || expectedDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    expectedDate = expectedDate.AddDays(1);
                }

                Assert.AreEqual(expectedDate, payPeriod.PayDueDate);
                expectedDate = expectedDate.AddDays(1);
            }
        }

        [TestMethod()]
        public void CalcPeriodAmountMonSatTest()
        {
            DateTime startDate = new DateTime(2026, 1, 1); // Thursday
            LoanPeriod loanPeriod = new LoanPeriod(24000, 20, 1200, startDate, PeriodType.Day);
            loanPeriod.ProcessDay = ProcessDay.MON_SAT;
            loanPeriod.CalcPeriodAmount();


            DateTime expectedDate = startDate;
            foreach (var payPeriod in loanPeriod.PayPeriods)
            {
                // skip Sunday
                while (expectedDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    expectedDate = expectedDate.AddDays(1);
                }

                Assert.AreEqual(expectedDate, payPeriod.PayDueDate);
                expectedDate = expectedDate.AddDays(1);
            }
        }

        [TestMethod()]
        public void CalcPeriodAmountHolidayTest()
        {
            DateTime startDate = new DateTime(2026, 1, 1); // Thursday
            LoanPeriod loanPeriod = new LoanPeriod(24000, 20, 1200, startDate, PeriodType.Day);
            loanPeriod.ProcessDay = ProcessDay.MON_FRI;
            List<DateTime> holiday = new List<DateTime>()
            {
                new DateTime(2026,1,5), // Monday
                new DateTime(2026,1,12) // Monday
            };

            loanPeriod.AddHolidays(holiday.ToArray());
            loanPeriod.CalcPeriodAmount();


            DateTime expectedDate = startDate;
            foreach (var payPeriod in loanPeriod.PayPeriods)
            {
                // skip Saturday and Sunday and holidays
                while (expectedDate.DayOfWeek == DayOfWeek.Saturday || expectedDate.DayOfWeek == DayOfWeek.Sunday || holiday.Contains(expectedDate))
                {
                    expectedDate = expectedDate.AddDays(1);
                }

                Assert.AreEqual(expectedDate, payPeriod.PayDueDate);
                expectedDate = expectedDate.AddDays(1);
            }

        }

        [TestMethod()]
        public void DiffContractPeriodDateTest()
        {
            List<DateTime> holiday = new List<DateTime>()
            {
                new DateTime(2025,12,30),
                new DateTime(2025,12,31),
                new DateTime(2026,1,1),
                new DateTime(2026,1,2),
                new DateTime(2026,1,3),
                new DateTime(2026,1,4),
            };

            List<ContractPeriod> oldContractPeriod = new List<ContractPeriod>();
            oldContractPeriod.Add(new ContractPeriod() { period_no = 1, due_date = new DateTime(2025, 12, 26) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 2, due_date = new DateTime(2025, 12, 27) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 3, due_date = new DateTime(2025, 12, 29) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 4, due_date = new DateTime(2025, 12, 30) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 5, due_date = new DateTime(2025, 12, 31) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 6, due_date = new DateTime(2026, 1, 5) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 7, due_date = new DateTime(2026, 1, 6) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 8, due_date = new DateTime(2026, 1, 7) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 9, due_date = new DateTime(2026, 1, 8) });
            oldContractPeriod.Add(new ContractPeriod() { period_no = 10, due_date = new DateTime(2026, 1, 9) });



            LoanPeriod loanPeriod = new LoanPeriod(12000, 10, 1200, new DateTime(2025, 12, 26), PeriodType.Day);
            loanPeriod.ProcessDay = ProcessDay.MON_SAT;
            loanPeriod.AddHolidays(holiday.ToArray());
            loanPeriod.CalcPeriodAmount();

            var diffPeriod = loanPeriod.DiffContractPeriodDate(oldContractPeriod.ToArray());

            Assert.AreEqual(7, diffPeriod.Count);

            Assert.AreEqual(new DateTime(2026, 1, 12), diffPeriod[6].PayDueDate);


            List<DateTime> holiday2 = new List<DateTime>()
            {
                new DateTime(2026,1,1),
                new DateTime(2026,1,2),
                new DateTime(2026,1,3),
                new DateTime(2026,1,4),
            };
            LoanPeriod loanPeriod2 = new LoanPeriod(12000, 10, 1200, new DateTime(2025, 12, 26), PeriodType.Day);
            loanPeriod2.ProcessDay = ProcessDay.MON_SAT;
            loanPeriod2.AddHolidays(holiday2.ToArray());
            loanPeriod2.CalcPeriodAmount();

            var diffPeriod2 = loanPeriod2.DiffContractPeriodDate(oldContractPeriod.ToArray());

            Assert.AreEqual(0, diffPeriod2.Count);

        }
    }
}