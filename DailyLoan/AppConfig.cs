using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.SqlServer.Server;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;

namespace DailyLoan
{
    public class AppConfig
    {

        public AppConfig()
        {

        }

        public string DBHost { get; set; }
        public string DBPort { get; set; }
        public string DBUsername { get; set; }
        public string DBPassword { get; set; }
        public string DBDatabaseName { get; set; }


        public void LoadConfig()
        {
            if (this.findTempConfig())
            {
                this.LoadTempConfig();
                return;
            }

            this.DBHost = System.Configuration.ConfigurationManager.AppSettings["DBHost"];
            this.DBPort = System.Configuration.ConfigurationManager.AppSettings["DBPort"];
            this.DBUsername = System.Configuration.ConfigurationManager.AppSettings["DBUsername"];
            this.DBPassword = System.Configuration.ConfigurationManager.AppSettings["DBPassword"];
            this.DBDatabaseName = System.Configuration.ConfigurationManager.AppSettings["DBDatabaesName"];

        }

        public String GetConnectionString()
        {
            return this.GetConnectionString(this.DBHost, this.DBPort, this.DBUsername, this.DBPassword, this.DBDatabaseName);
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
            this.DBHost = dbHost;
            this.DBPort = dbPort;
            this.DBUsername = dbUser;
            this.DBPassword = dbPassword;
            this.DBDatabaseName = dbName;
        }

        bool findTempConfig()
        {
            string tempPath = System.IO.Path.GetTempPath();
            string configFilePath = System.IO.Path.Combine(tempPath, "DailyLoan.config");
            bool isConfigExists = System.IO.File.Exists(configFilePath);
            return isConfigExists;
        }


        public void WriteTempConfig()
        {
            string configContent = JsonConvert.SerializeObject(this, Formatting.Indented);

            // serialize this object to temp dir
            string tempPath = System.IO.Path.GetTempPath();
            string configFilePath = System.IO.Path.Combine(tempPath, "DailyLoan.config");
            System.IO.StreamWriter writer = new System.IO.StreamWriter(configFilePath, false, Encoding.UTF8);
            writer.Write(configContent);
            writer.Close();


        }

        void LoadTempConfig()
        {
            // deserialize this object from temp dir
            string tempPath = System.IO.Path.GetTempPath();
            string configFilePath = System.IO.Path.Combine(tempPath, "DailyLoan.config");

            if (System.IO.File.Exists(configFilePath))
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(configFilePath, Encoding.UTF8);

                string content = reader.ReadToEnd();
                AppConfig tempConfig = JsonConvert.DeserializeObject<AppConfig>(content);
                this.DBHost = tempConfig.DBHost;
                this.DBPort = tempConfig.DBPort;
                this.DBUsername = tempConfig.DBUsername;
                this.DBPassword = tempConfig.DBPassword;
                this.DBDatabaseName = tempConfig.DBDatabaseName;

                reader.Close();

            }

        }
    }
}
