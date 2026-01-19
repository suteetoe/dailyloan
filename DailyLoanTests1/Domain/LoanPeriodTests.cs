using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyLoan.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

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

    }
}