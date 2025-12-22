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

            bool testConnectResult = dbConnection.TestConnect();

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

        [TestMethod()]
        public void DatabaseQueryTransactionTest()
        {
            string connectionString = "Host=192.168.2.212;Port=5432;Database={0};Username=postgres;Password=sml;";

            DBConnection dbConnection = new DBConnection(String.Format(connectionString, "dailyloan"));

            bool testConnectResult = dbConnection.TestConnect();
            Assert.IsTrue(testConnectResult);
            Assert.IsTrue(dbConnection.Connected);

            // create table txn_demo if not exists

            dbConnection.ExecuteCommand(@"CREATE TABLE IF NOT EXISTS txn_demo (
                  id SERIAL,
                  doc_no varchar(100) PRIMARY KEY NOT NULL,
                  doc_date date,
                  remark text
                );");


            // clear txn_demo table
            dbConnection.ExecuteCommand("TRUNCATE TABLE txn_demo;");


            TransactionConnection transactionConnection = dbConnection.CreateTransactionConnection();

            try
            {
                transactionConnection.ExecuteCommand("INSERT INTO txn_demo (doc_no, doc_date, remark) VALUES ('DOCNO001', '2025-12-01', '') ");
                transactionConnection.ExecuteCommand("INSERT INTO txn_demo (doc_no, doc_date, remark) VALUES ('DOCNO002', '2025-12-01', '') ");

                transactionConnection.CommitTransaction();
            }
            catch (DBException ex)
            {
                throw ex;
            }

            // try insert duplicate primary key

            try
            {
                transactionConnection.ExecuteCommand("INSERT INTO txn_demo (doc_no, doc_date, remark) VALUES ('DOCNO001', '2025-12-01', '') ");
                Assert.Fail("Expected DBException was not thrown.");
            }
            catch (DBException ex)
            {
                Assert.AreEqual("23505", ex.ErrorCode);
            }

            dbConnection.Disconnect();
        }

    }
}