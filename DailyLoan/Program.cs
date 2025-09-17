using System;
using System.Collections.Generic;
using System.Linq;
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
            SMLControl._myGlobal._isDesignMode = false;

            App.AppConfig = new AppConfig();
            App.AppConfig.LoadConfig();

            Application.Run(new LoginForm());

            if (App.IsUserLoggedIn)
            {
                Application.Run(new MainForm());
            }
            Application.Exit();
            // Application.Run(new MainForm());
        }
    }
}
