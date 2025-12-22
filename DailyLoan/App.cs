using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan
{
    public class App
    {
        public static BizFlowControl.DBConnection DBConnection = null;
        public static bool IsUserLoggedIn = false;
        public static int UserId = -1;
        public static User LoggedUser = null;
        public static AppConfig AppConfig;

        public static void InitDBConnection()
        {
            try
            {
                if (DBConnection != null)
                {
                    DBConnection.Disconnect();
                }

                App.DBConnection = new BizFlowControl.DBConnection(App.AppConfig.GetConnectionString());
                App.DBConnection.TestConnect();
            }
            catch
            {
            }
        }
    }
}
