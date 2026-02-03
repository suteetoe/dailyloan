using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            GetVersion();
            SMLControl._myGlobal._isDesignMode = false;

            App.AppConfig = new AppConfig();
            App.AppConfig.LoadConfig();
            App.InitDBConnection();
            bool isDBConnected = false;

            try
            {
                isDBConnected = App.DBConnection != null && App.DBConnection.TestConnect();
            }
            catch
            {
                isDBConnected = false;
            }

            if (isDBConnected == true)
            {
                try
                {
                    Migration.DataMigration dataMigration = new Migration.DataMigration(App.DBConnection);
                    dataMigration.StartMigration();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Data migration error: " + ex.Message.ToString());
                }
            }

            Application.Run(new LoginForm());

            if (App.IsUserLoggedIn)
            {
                Application.Run(new MainForm());
            }
            Application.Exit();
            // Application.Run(new MainForm());
        }

        static void GetVersion()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            App.AppVersion = assembly.GetName().Version.ToString();
        }
    }
}
