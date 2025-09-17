using DailyLoan.Daily;
using DailyLoan.Loan;
using System;
using System.Collections.Generic;
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

        LoanControl loanControl;
        DailyControl dailyContrl;


        public MainForm()
        {
            InitializeComponent();

            this._buttonAbout.Focus();
            this.FormClosing += MainForm_FormClosing;
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



        void DisplayInMainPanel(UserControl control)
        {
            control.Dock = DockStyle.Fill;

            this._mainPanel.Controls.Clear();
            this._mainPanel.Controls.Add(control);
        }

        private void _exitToolStripMenu_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void _buttonMenuContract_Click(object sender, EventArgs e)
        {
            if (loanControl == null)
            {
                this.loanControl = new LoanControl();
            }
            DisplayInMainPanel(this.loanControl);
        }

        private void buttonMenuDailySheet_Click(object sender, EventArgs e)
        {
            if (dailyContrl == null)
            {
                this.dailyContrl = new DailyControl();
            }

            DisplayInMainPanel(dailyContrl);

        }

        private void _buttonAbout_Click(object sender, EventArgs e)
        {
            DisplayInMainPanel(welcomeControl1);

        }
    }
}
