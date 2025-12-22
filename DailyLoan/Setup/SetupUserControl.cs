using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Setup
{
    public partial class SetupUserControl : UserControl
    {
        public SetupUserControl()
        {
            InitializeComponent();
        }

        private void _holidayMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_HOLIDAY);
        }

        private void _routeMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_ROUTE);

        }

        private void _employeeMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_EMPLOYEE);

        }
    }
}
