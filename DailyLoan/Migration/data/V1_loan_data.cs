using BizFlowControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Migration.data
{
    public class V1_loan_data : IDBMigrate
    {
        BizFlowControl.DBConnection connection;

        public V1_loan_data(BizFlowControl.DBConnection dbConnection)
        {
            this.connection = dbConnection;
        }

        public void Start()
        {
            // create table loan data
            TransactionConnection transactionConnection = this.connection.CreateTransactionConnection();
            try
            {
                string create_table_loan_data =
                    @"CREATE TABLE IF NOT EXISTS txn_contract (
                      id SERIAL,
                      contract_no varchar(100) PRIMARY KEY NOT NULL,
                      contract_date date NOT NULL,
                      route_code varchar(100),
                      customer_code varchar(100) NOT NULL,
                      product_group int NOT NULL,
                      loan_type varchar(100) NOT NULL,
                      description text DEFAULT '',
                      principle_amount numeric NOT NULL,
                      interest_rate numeric NOT NULL,
                      total_interest numeric NOT NULL,
                      income_other numeric DEFAULT 0,
                      num_of_period int NOT NULL,
                      amount_per_period numeric NOT NULL,
                      first_period_date date NOT NULL,
                      create_by int NOT NULL
                    );";
                transactionConnection.ExecuteCommand(create_table_loan_data);

                string create_table_txn_contract_period =
                    @"CREATE TABLE IF NOT EXISTS txn_contract_period (
                      id SERIAL PRIMARY KEY NOT NULL,
                      contract_no varchar(100),
                      period_no int4 NOT NULL,
                      due_date date NOT NULL,
                      amount numeric NOT NULL
                    );";
                transactionConnection.ExecuteCommand(create_table_txn_contract_period);

                string create_table_txn_payment =
                    @"CREATE TABLE IF NOT EXISTS txn_payment(
                      id SERIAL,
                      doc_no varchar(100) PRIMARY KEY,
                      doc_date date NOT NULL,
                      cust_code varchar(100),
                      contract_no varchar(100) NOT NULL,
                      total_amount numeric,
                      create_by int NOT NULL
                    );";
                transactionConnection.ExecuteCommand(create_table_txn_payment);

                string create_table_txn_route_payment =
                    @"CREATE TABLE IF NOT EXISTS txn_route_payment(
                      id SERIAL,
                      doc_no varchar(100) PRIMARY KEY,
                      route_code varchar(100),
                      doc_date date NOT NULL,
                      contract_no varchar(100) NOT NULL,
                      total_amount numeric,
                      create_by int NOT NULL
                    );";
                transactionConnection.ExecuteCommand(create_table_txn_route_payment);


                string create_table_txn_contract_period_payment =
                    @"CREATE TABLE IF NOT EXISTS txn_contract_period_payment (
                      id SERIAL PRIMARY KEY NOT NULL,
                      contract_no varchar(100),
                      period_no int4,
                      pay_doc_no varchar(100),
                      pay_principal_amount numeric,
                      pay_interest_amount numeric
                    );";
                transactionConnection.ExecuteCommand(create_table_txn_contract_period_payment);

                string create_foreign_key_contract_route_code = MigrationDBHelper.DoAddForeintKeyIfNotExists(
                    "txn_contract",
                    "fk_txn_contract_route_code",
                    "ALTER TABLE txn_contract ADD CONSTRAINT fk_txn_contract_route_code FOREIGN KEY (route_code) REFERENCES mst_route (code);");
                transactionConnection.ExecuteCommand(create_foreign_key_contract_route_code);

                string create_foreign_key_txn_contract_customer_code = MigrationDBHelper.DoAddForeintKeyIfNotExists(
                    "txn_contract",
                    "fk_txn_contract_customer_code",
                    "ALTER TABLE txn_contract ADD CONSTRAINT fk_txn_contract_customer_code FOREIGN KEY(customer_code) REFERENCES mst_customer(code);");
                transactionConnection.ExecuteCommand(create_foreign_key_txn_contract_customer_code);


                string create_foreign_key_txn_contract_period_code = MigrationDBHelper.DoAddForeintKeyIfNotExists(
                    "txn_contract_period",
                    "fk_txn_contract_period_contract_no",
                    "ALTER TABLE txn_contract_period ADD CONSTRAINT fk_txn_contract_period_contract_no FOREIGN KEY(contract_no) REFERENCES txn_contract(contract_no);");
                transactionConnection.ExecuteCommand(create_foreign_key_txn_contract_period_code);

                string create_foreign_key_txn_payment_contract_no = MigrationDBHelper.DoAddForeintKeyIfNotExists(
                    "txn_payment",
                    "fk_txn_payment_contract_no",
                    "ALTER TABLE txn_payment ADD CONSTRAINT fk_txn_payment_contract_no FOREIGN KEY(contract_no) REFERENCES txn_contract(contract_no);");
                transactionConnection.ExecuteCommand(create_foreign_key_txn_payment_contract_no);

                string create_foreign_key_txn_payment_customer_code = MigrationDBHelper.DoAddForeintKeyIfNotExists(
                    "txn_payment",
                    "fk_txn_payment_cust_code",
                    "ALTER TABLE txn_payment ADD CONSTRAINT fk_txn_payment_cust_code FOREIGN KEY(cust_code) REFERENCES mst_customer(code);");
                transactionConnection.ExecuteCommand(create_foreign_key_txn_payment_customer_code);


                string create_foreign_key_txn_route_payment_contract_no = MigrationDBHelper.DoAddForeintKeyIfNotExists(
                    "txn_route_payment",
                    "fk_txn_route_payment_contract_no",
                    "ALTER TABLE txn_route_payment ADD CONSTRAINT fk_txn_route_payment_contract_no FOREIGN KEY(contract_no) REFERENCES txn_contract(contract_no);");
                transactionConnection.ExecuteCommand(create_foreign_key_txn_route_payment_contract_no);

                string create_foreign_key_txn_contract_period_payment_contract_no = MigrationDBHelper.DoAddForeintKeyIfNotExists(
                    "txn_contract_period_payment",
                    "fk_txn_contract_period_payment_contract_no",
                    "ALTER TABLE txn_contract_period_payment ADD CONSTRAINT fk_txn_contract_period_payment_contract_no FOREIGN KEY(contract_no) REFERENCES txn_contract(contract_no);");
                transactionConnection.ExecuteCommand(create_foreign_key_txn_contract_period_payment_contract_no);




                transactionConnection.CommitTransaction();
            }
            catch
            {
                transactionConnection.RollbackTransaction();
                throw;
            }
        }
    }
}
