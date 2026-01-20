using Microsoft.VisualStudio.TestTools.UnitTesting;
using DailyLoan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Tests
{
    [TestClass()]
    public class AutoRunningTests
    {
        [TestMethod()]
        public void NextRunningTest()
        {
            DateTime runningDate = new DateTime(2026, 1, 21);
            AutoRunning autoRun = new AutoRunning("MM", "@YYMM######", runningDate);


            string __newRunningWithEmptyData = autoRun.NextRunning("");
            Assert.AreEqual("MM2601000001", __newRunningWithEmptyData);

            string __newRunning = autoRun.NextRunning("MM2601000123");
            Assert.AreEqual("MM2601000124", __newRunning);


        }


        [TestMethod()]
        public void NextRunningBuddhistTest()
        {
            DateTime runningDate = new DateTime(2026, 1, 21);
            AutoRunning autoRun = new AutoRunning("MM", "@ปปดด######", runningDate);


            string __newRunningWithEmptyData = autoRun.NextRunning("");
            Assert.AreEqual("MM6901000001", __newRunningWithEmptyData);

            string __newRunning = autoRun.NextRunning("MM6901000123");
            Assert.AreEqual("MM6901000124", __newRunning);


        }
    }
}