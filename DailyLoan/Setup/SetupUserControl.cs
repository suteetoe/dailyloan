using DailyLoan.Screen.CompanyProfile;
using DailyLoan.Screen.Options;
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

            if ((int)App.LoggedUser.Role < 1)
            {
                this._systemUserButton.Visible = false;
            }
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

        private void _loanTypeMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_LOAN_TYPE);

        }

        private void _companySetup_Click(object sender, EventArgs e)
        {
            CompanyProfileForm companyProfileForm = new CompanyProfileForm();
            companyProfileForm.ShowDialog();
        }

        private void _optionSettingButton_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm();
            optionForm.ShowDialog();
        }

        private void _systemUserButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_SYSTEM_USER);
        }
    }
}
