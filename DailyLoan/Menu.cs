using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan
{
    public class Router
    {
        public static Dictionary<String, UserControl> screenOpened = new Dictionary<string, UserControl>();
        public static void OpenMenu(MenuScreen openMenu)
        {
            if (screenOpened.ContainsKey(openMenu.ToString()))
            {
                UserControl openedScreen = screenOpened[openMenu.ToString()];

                if (ScreenOpening != null)
                {
                    ScreenOpening(openedScreen);
                }
            }
            else
            {

                UserControl openScreen = null;
                switch (openMenu)
                {
                    case MenuScreen.MENU_WELCOME:
                        openScreen = new WelcomeControl();
                        break;
                    case MenuScreen.MENU_EMPLOYEE:
                        openScreen = new Setup.Employee.EmployeeControl();
                        break;
                    case MenuScreen.MENU_ROUTE:
                        openScreen = new Setup.Route.RouteControl();
                        break;
                    case MenuScreen.MENU_HOLIDAY:
                        openScreen = new Setup.Holiday.HolidayControl();
                        break;
                    case MenuScreen.MENU_EXPENSE:
                        openScreen = new Expenses.ExpenseControl();
                        break;
                    case MenuScreen.MENU_LOAN:
                        openScreen = new Loan.LoanControl();
                        break;
                    case MenuScreen.MENU_REPORT:
                        openScreen = new Report.ReportMenu();
                        break;
                    case MenuScreen.MENU_SETUP:
                        openScreen = new Setup.SetupUserControl();
                        break;
                    case MenuScreen.MENU_CUSTOMER:
                        openScreen = new Customer.CustomerControl();
                        break;
                    case MenuScreen.MENU_DAILY:
                        openScreen = new Daily.DailyControl();
                        break;
                }

                if (openScreen != null)
                {
                    if (ScreenOpening != null)
                    {
                        screenOpened.Add(openMenu.ToString(), openScreen);
                        ScreenOpening(openScreen);
                    }
                }
            }
        }

        public static event LoadScreen ScreenOpening;
        public delegate void LoadScreen(UserControl screen);
    }

    public enum MenuScreen
    {
        MENU_WELCOME,
        MENU_SETUP,
        MENU_EMPLOYEE,
        MENU_ROUTE,
        MENU_HOLIDAY,
        MENU_EXPENSE,
        MENU_LOAN,
        MENU_REPORT,
        MENU_CUSTOMER,
        MENU_DAILY,
    }

}
