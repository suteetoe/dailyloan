using System;
using System.Collections.Generic;
using System.Configuration;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Migration.data
{
    internal interface IDBMigrate
    {
        void Start();
    }

    public class MigrationDBHelper
    {
        public static string DoAddForeintKeyIfNotExists(string tableName, string keyName, string addKeyScript)
        {
            string sql =
                @"DO $$
                BEGIN

                    IF NOT EXISTS (
                        SELECT 1
                        FROM pg_constraint
                        WHERE conname = '{0}'
                        AND conrelid = '{1}'::regclass 
                    ) THEN	
                        {2}
                    END IF;
                END $$; ";

            string result = string.Format(sql, keyName, tableName, addKeyScript);
            return result;

        }
    }
}
