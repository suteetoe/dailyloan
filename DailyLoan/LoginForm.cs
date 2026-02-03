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
            this._versionLabel.Text = "Version: " + App.AppVersion;
        }

        private void _loginButton_Click(object sender, EventArgs e)
        {
            

            string userCode = this.userCodeTextbox.Text.Trim();
            string password = this.passwordTextbox.Text.Trim();
            try
            {
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
                App.LoggedUser = user;

                
                
                MessageBox.Show("ยินดีต้อนรับ " + user.Name + " เข้าสู่ระบบ\r\nระดับพนักงาน : " + user.Role.ToString(), "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close();
            }
            catch(BizFlowControl.DBException dbException)
            {
                if (dbException.ErrorCode == BizFlowControl.DBException.ERROR_CODE_NOT_CONNECTED)
                {
                    MessageBox.Show("ไม่สามารถเชื่อมต่อฐานข้อมูลได้\r\nโปรดตรวจสอบการตั้งค่าฐานข้อมูล", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการเข้าสู่ระบบ\r\n" + dbException.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("เกิดข้อผิดพลาดในการเข้าสู่ระบบ\r\n" + ex.Message, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
