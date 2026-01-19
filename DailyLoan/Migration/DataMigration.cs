using DailyLoan.Migration.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Migration
{
    public class DataMigration
    {
        BizFlowControl.DBConnection connection;
        List<data.IDBMigrate> migrations = new List<data.IDBMigrate>();

        public DataMigration(BizFlowControl.DBConnection dbConnection)
        {
            this.connection = dbConnection;
            InitializeMigration();
        }

        void InitializeMigration()
        {
            // create table
            this.migrations.Add(new data.V0_Initial(this.connection));
            this.migrations.Add(new data.V1_loan_data(this.connection));
        }

        public void StartMigration()
        {
            // get last version

            // migrate data
            for (int i = 0; i < this.migrations.Count; i++)
            {
                this.migrations[i].Start();
            }

        }
    }
}
