using BizFlowControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Migration.data
{
    public class V0_Initial : IDBMigrate
    {
        BizFlowControl.DBConnection connection;

        public V0_Initial(BizFlowControl.DBConnection dbConnection)
        {
            this.connection = dbConnection;
        }

        public void Start()
        {
            // create table employee if not exists
            TransactionConnection transactionConnection = this.connection.CreateTransactionConnection();
            try
            {
                string create_table_sys_users = 
                    @"CREATE TABLE IF NOT EXISTS sys_users (
                      id SERIAL PRIMARY KEY NOT NULL,
                      name_1 varchar(255) NOT NULL,
                      user_code varchar(255) NOT NULL,
                      user_password varchar(255) NOT NULL,
                      user_role int2 DEFAULT 0
                    );";
                transactionConnection.ExecuteCommand(create_table_sys_users);

                string create_table_sys_company_profile = 
                    @"CREATE TABLE IF NOT EXISTS sys_company_profile (
                      company_name varchar(250) NOT NULL,
                      address text DEFAULT '',
                      telephone varchar(100) DEFAULT ''
                    );";
                transactionConnection.ExecuteCommand(create_table_sys_company_profile);

                string create_table_sys_options =
                    @"CREATE TABLE IF NOT EXISTS sys_options (
                      npl_period int
                    );";
                transactionConnection.ExecuteCommand(create_table_sys_options);

                string create_table_mst_holiday =
                    @"CREATE TABLE IF NOT EXISTS mst_holiday (
                      id SERIAL,
                      year int4 NOT NULL,
                      date_holiday date NOT NULL,
                      remark text DEFAULT '',
                      is_on_edit smallint DEFAULT 0,
                      PRIMARY KEY (year, date_holiday)
                    );
                    ";
                transactionConnection.ExecuteCommand(create_table_mst_holiday);

                string create_table_mst_employee =
                    @"CREATE TABLE IF NOT EXISTS mst_employee (
                      id SERIAL,
                      code varchar(100) PRIMARY KEY,
                      name_1 varchar(255) NOT NULL,
                      is_on_edit smallint DEFAULT 0
                    );
                    ";
                transactionConnection.ExecuteCommand(create_table_mst_employee);

                string create_table_mst_customer =
                    @"CREATE TABLE IF NOT EXISTS mst_customer (
                      id SERIAL,
                      code varchar(100) PRIMARY KEY,
                      name_1 varchar(255) NOT NULL,
                      address text DEFAULT '',
                      telephone varchar(100) DEFAULT '',
                      is_on_edit smallint DEFAULT 0
                    );";
                transactionConnection.ExecuteCommand(create_table_mst_customer);

                string create_table_mst_route =
                    @"CREATE TABLE IF NOT EXISTS mst_route (
                      id SERIAL,
                      code varchar(100) PRIMARY KEY,
                      name_1 varchar(500) NOT NULL,
                      remark text DEFAULT '',
                      is_on_edit smallint DEFAULT 0
                    );";
                transactionConnection.ExecuteCommand(create_table_mst_route);

                string create_table_mst_loan_type =
                    @"CREATE TABLE IF NOT EXISTS mst_loan_type (
                      id SERIAL,
                      code varchar(100) PRIMARY KEY,
                      name_1 varchar(500) NOT NULL,
                      working_day varchar(500),
                      working_holiday_type smallint DEFAULT 0,
                      is_on_edit smallint DEFAULT 0
                    );";
                transactionConnection.ExecuteCommand(create_table_mst_loan_type);

                transactionConnection.CommitTransaction();

            }
            catch (Exception ex)
            {
                transactionConnection.RollbackTransaction();
                throw ex;
            }
            finally
            {

            }
        }
    }
}
