using Microsoft.VisualStudio.TestTools.UnitTesting;
using BizFlowControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizFlowControl.Tests
{

    

    [TestClass()]
    public class DBConnectionTests
    {
        [TestMethod()]
        public void DBConnectionTest()
        {
            string connectionString = "Host=192.168.2.212;Port=5432;Database={0};Username=postgres;Password=sml;";

            DBConnection dbConnection = new DBConnection(String.Format(connectionString, "template1"));

           bool testConnectResult =  dbConnection.TestConnect();

            Assert.IsTrue(testConnectResult);

            bool isConnected = dbConnection.Connected;

            Assert.IsTrue(isConnected);

            dbConnection.Disconnect();
        }


        [TestMethod()]
        public void DatabaseAlreadyTest()
        {
            string connectionString = "Host=192.168.2.212;Port=5432;Database={0};Username=postgres;Password=sml;";

            DBConnection dbConnection = new DBConnection(String.Format(connectionString, "template1"));

            bool testConnectResult = dbConnection.TestConnect();
            Assert.IsTrue(testConnectResult);
            Assert.IsTrue(dbConnection.Connected);


            bool dbExists = dbConnection.DatabaseExists("rayong");

            dbConnection.Disconnect();
        }

        [TestMethod()]
        public void CreateDatabaseTest()
        {
            string connectionString = "Host=192.168.2.212;Port=5432;Database={0};Username=postgres;Password=sml;";

            DBConnection dbConnection = new DBConnection(String.Format(connectionString, "template1"));

            bool testConnectResult = dbConnection.TestConnect();
            Assert.IsTrue(testConnectResult);
            Assert.IsTrue(dbConnection.Connected);


            bool canCreateDB = dbConnection.CreateDatabase("dailyloan");
            Assert.IsTrue(canCreateDB);

            dbConnection.Disconnect();
        }


    }
}