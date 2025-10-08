using System;
using System.Drawing;
using System.Windows.Forms;

namespace InactiveStockCleaner
{
    public partial class InactiveStockCleaner_Form : Form
    {
        public InactiveStockCleaner_Form()
        {
            InitializeComponent();
        }

        private void InactiveStockCleaner_Form_Load(object sender, EventArgs e)
        {
            // เริ่มต้นที่ login tab และปิด process tab
            mainTabControl.SelectedIndex = 0;
            processTabPage.Enabled = false;

            // โหลด configuration และเซ็ตค่า default
            InitializeAppConfig();
            SetDefaultValues();
            dbHostTextBox.Focus();
        }

        private void InitializeAppConfig()
        {
            App.AppConfig = new AppConfig();
            App.AppConfig.LoadConfig();
        }

        private void SetDefaultValues()
        {
            // เซ็ตค่า default ตามที่ user ต้องการ
            dbHostTextBox.Text = "192.168.2.236";
            dbPortTextBox.Text = "5432";
            dbUserTextBox.Text = "postgres";
            dbPasswordTextBox.Text = "sml";
            dbNameTextBox.Text = "pichian";
        }

        private bool CreateDatabaseConnection()
        {
            try
            {
                // อ่านค่าจาก textbox
                string host = dbHostTextBox.Text.Trim();
                string port = dbPortTextBox.Text.Trim();
                string user = dbUserTextBox.Text.Trim();
                string password = dbPasswordTextBox.Text.Trim();
                string databaseName = dbNameTextBox.Text.Trim();

                // สร้าง connection string และเชื่อมต่อ
                if (App.AppConfig == null)
                    InitializeAppConfig();
                
                string connectionString = App.AppConfig.GetConnectionString(host, port, user, password, databaseName);
                App.DBConnection = new BizFlowControl.DBConnection(connectionString);
                App.DBConnection.TestConnect();
                
                return true;
            }
            catch (Exception ex)
            {
                ShowStatus($"ไม่สามารถเชื่อมต่อ Database: {ex.Message}", Color.Red);
                App.DBConnection = null;
                return false;
            }
        }

        private void ShowStatus(string message, Color color)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = color;
        }

        private bool ValidateRequiredFields()
        {
            if (string.IsNullOrEmpty(dbHostTextBox.Text.Trim()))
            {
                ShowStatus("กรุณาใส่ Database Host", Color.Red);
                dbHostTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(dbPortTextBox.Text.Trim()))
            {
                ShowStatus("กรุณาใส่ Database Port", Color.Red);
                dbPortTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(dbUserTextBox.Text.Trim()))
            {
                ShowStatus("กรุณาใส่ Database Username", Color.Red);
                dbUserTextBox.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(dbNameTextBox.Text.Trim()))
            {
                ShowStatus("กรุณาใส่ Database Name", Color.Red);
                dbNameTextBox.Focus();
                return false;
            }

            return true;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                var dbForm = new DBSettingForm();
                dbForm.ShowDialog(this);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            ShowStatus("", Color.Black);

            // ตรวจสอบข้อมูลที่จำเป็น
            if (!ValidateRequiredFields())
                return;

            // แสดงสถานะกำลังเชื่อมต่อ
            ShowStatus("กำลังเชื่อมต่อ Database...", Color.Blue);
            Application.DoEvents();

            // เชื่อมต่อ database
            if (!CreateDatabaseConnection())
                return;

            // เข้าสู่ระบบสำเร็จ
            App.IsUserLoggedIn = true;
            ShowStatus("เข้าสู่ระบบสำเร็จ!", Color.Green);
            
            // เปิดใช้งาน process tab และไป process tab
            processTabPage.Enabled = true;
            mainTabControl.SelectedIndex = 1;
            loginTabPage.Enabled = false;
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            // ตรวจสอบข้อมูลที่จำเป็น
            if (!ValidateRequiredFields())
                return;

            ShowStatus("กำลังทดสอบการเชื่อมต่อ...", Color.Blue);
            Application.DoEvents();

            try
            {
                // สร้าง test connection
                string host = dbHostTextBox.Text.Trim();
                string port = dbPortTextBox.Text.Trim();
                string user = dbUserTextBox.Text.Trim();
                string password = dbPasswordTextBox.Text.Trim();
                string databaseName = dbNameTextBox.Text.Trim();

                if (App.AppConfig == null)
                    InitializeAppConfig();
                
                string connectionString = App.AppConfig.GetConnectionString(host, port, user, password, databaseName);
                var testConnection = new BizFlowControl.DBConnection(connectionString);
                
                if (testConnection.TestConnect())
                {
                    bool isDatabaseExists = testConnection.DatabaseExists(databaseName);
                    testConnection.Disconnect();
                    
                    if (isDatabaseExists)
                    {
                        ShowStatus("ทดสอบการเชื่อมต่อสำเร็จ!", Color.Green);
                    }
                    else
                    {
                        ShowStatus($"ไม่พบ Database: {databaseName}", Color.Orange);
                    }
                }
                else
                {
                    ShowStatus("ไม่สามารถเชื่อมต่อ Database ได้", Color.Red);
                }
            }
            catch (Exception ex)
            {
                ShowStatus($"เกิดข้อผิดพลาด: {ex.Message}", Color.Red);
            }
        }
    }
}
