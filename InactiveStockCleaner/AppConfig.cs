using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InactiveStockCleaner
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
            this._dbHost = ConfigurationManager.AppSettings["DBHost"] ?? "192.168.2.212";
            this._dbPort = ConfigurationManager.AppSettings["DBPort"] ?? "5432";
            this._dbUser = ConfigurationManager.AppSettings["DBUsername"] ?? "postgres";
            this._dbPassword = ConfigurationManager.AppSettings["DBPassword"] ?? "sml";
            this._dbName = ConfigurationManager.AppSettings["DBDatabaesName"] ?? "dailyloan";
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