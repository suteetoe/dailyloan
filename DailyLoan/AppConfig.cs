using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.SqlServer.Server;
using System.Runtime.CompilerServices;

namespace DailyLoan
{
    public class AppConfig
    {
        private string _dbHost = "";
        private string _dbPort = "";
        private string _dbUser = "";
        private string _dbPassword = "";
        private string _dbName = "";

        public AppConfig()
        {

        }

        public string DBHost { get { return this._dbHost; } }
        public string DBPort { get { return this._dbPort; } }
        public string DBUsername { get { return this._dbUser; } }
        public string DBPassword { get { return this._dbPassword; } }
        public string DBDatabaseName { get { return this._dbName; } }


        public void LoadConfig()
        {
            this._dbHost = System.Configuration.ConfigurationManager.AppSettings["DBHost"];
            this._dbPort = System.Configuration.ConfigurationManager.AppSettings["DBPort"];
            this._dbUser = System.Configuration.ConfigurationManager.AppSettings["DBUsername"];
            this._dbPassword = System.Configuration.ConfigurationManager.AppSettings["DBPassword"];
            this._dbName = System.Configuration.ConfigurationManager.AppSettings["DBDatabaesName"];
        }

        public String GetConnectionString()
        {
            return this.GetConnectionString(this._dbHost, this._dbPort, this._dbUser, this._dbPassword, this._dbName);
        }

        public string GetConnectionString(string host, string port, string user, string password, string databaseName)
        {
            string connectionString = string.Format("Host={0};Port={1};Database={4};Username={2};Password={3};"
                , host
                , port
                , user
                , password
                , databaseName
                );

            return connectionString;
        }

        public void ChangeConfig(string dbHost, string dbPort, string dbUser, string dbPassword, string dbName)
        {
            this._dbHost = dbHost;
            this._dbPort = dbPort;
            this._dbUser = dbUser;
            this._dbPassword = dbPassword;
            this._dbName = dbName;
        }
    }
}
