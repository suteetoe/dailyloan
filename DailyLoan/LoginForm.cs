using DailyLoan.Data.Repository;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void _loginButton_Click(object sender, EventArgs e)
        {

            string userCode = this.userCodeTextbox.Text.Trim();
            string password = this.passwordTextbox.Text.Trim();

            UserRepository userRepo = new UserRepository();
            var user = userRepo.FindUserByUserCode(userCode);

            if (user == null)
            {
                MessageBox.Show("Invalid user code", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (user.Password != password)
            {
                MessageBox.Show("Invalid password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            App.UserId = user.Id;
            App.IsUserLoggedIn = true;

            MessageBox.Show("ยินดีต้อนรับ " + user.Name + " เข้าสู่ระบบ\r\nระดับพนักงาน : " + user.Role.ToString(), "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                DBSettingForm dbForm = new DBSettingForm();
                dbForm.ShowDialog(this);
                App.InitDBConnection();

                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

       
    }
}
