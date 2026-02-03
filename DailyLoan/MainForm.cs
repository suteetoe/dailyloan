using DailyLoan.Daily;
using DailyLoan.Loan;
using DailyLoan.Report;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            Router.ScreenOpening += Router_ScreenOpening;
            InitializeComponent();

            Router.OpenMenu(MenuScreen.MENU_WELCOME);

            this.Text = "โปรแกรมบริหารจัดการเงินกู้รายวัน"; //  (Version: " + App.AppVersion + ")
            this._versionLabel.Text = "Version: " + App.AppVersion;
            this.FormClosing += MainForm_FormClosing;
        }

        private void Router_ScreenOpening(UserControl screen)
        {
            DisplayInMainPanel(screen);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string __confirmExitMessage = "คุณต้องการจบโปรแกรม หรือไม่";
            if (MessageBox.Show(__confirmExitMessage, "ยืนยัน", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
            {
                e.Cancel = true;
            }
        }

        //private void _loanMenuButton_Click(object sender, EventArgs e)
        //{
        //    if (this.loanForm == null)
        //    {
        //        this.loanForm = new LoanForm();
        //        this.loanForm.FormBorderStyle = FormBorderStyle.FixedSingle;
        //        this.loanForm.WindowState = FormWindowState.Maximized;
        //        this.loanForm.Dock = DockStyle.Fill;
        //        this.loanForm.MdiParent = this;
        //        this.loanForm.FormClosed += (fs, fe) =>
        //        {
        //            this.loanForm = null;
        //        };
        //        this.loanForm.Show();
        //    }
        //    else
        //    {
        //        this.loanForm.Activate();
        //    }
        //    this.Invalidate();
        //}

        //private void _dailyMenuButton_Click(object sender, EventArgs e)
        //{
        //    if (this.dailyForm == null)
        //    {
        //        this.dailyForm = new DailyForm();
        //        this.dailyForm.FormBorderStyle = FormBorderStyle.FixedSingle;
        //        this.dailyForm.WindowState = FormWindowState.Maximized;
        //        this.dailyForm.Dock = DockStyle.Fill;
        //        this.dailyForm.MdiParent = this;
        //        this.dailyForm.FormClosed += (fs, fe) =>
        //        {
        //            this.dailyForm = null;
        //        };
        //        this.dailyForm.Show();
        //    }
        //    else
        //    {
        //        this.dailyForm.Activate();
        //    }
        //    this.Invalidate();
        //}



        void DisplayInMainPanel(UserControl screen)
        {
            screen.Dock = DockStyle.Fill;
            this._mainPanel.Controls.Clear();
            this._mainPanel.Controls.Add(screen);
        }

        private void _exitToolStripMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _loanMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_LOAN);
        }

        private void _dailyMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_DAILY);
        }

        private void _reportMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_REPORT);
        }

        private void _welcomeMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_WELCOME);
        }

        private void _customerMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_CUSTOMER);
        }

        private void _setupMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_SETUP);
        }

        private void _expenseMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_EXPENSE);

        }

        private void _paymentListMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_PAYMENT);

        }

        private void _routePaymentMenuButton_Click(object sender, EventArgs e)
        {
            Router.OpenMenu(MenuScreen.MENU_ROUTE_PAYMENT);

        }
    }
}
