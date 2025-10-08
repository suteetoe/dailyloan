using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InactiveStockCleaner
{
    public partial class InactiveStockCleaner_Form : Form
    {
        private bool isLoggedIn = false;

        public InactiveStockCleaner_Form()
        {
            InitializeComponent();
        }

        private void InactiveStockCleaner_Form_Load(object sender, EventArgs e)
        {
            // เริ่มต้นที่ login tab
            mainTabControl.SelectedIndex = 0;
            // ปิดการใช้งาน process tab จนกว่าจะ login สำเร็จ
            processTabPage.Enabled = false;

            // เซ็ตค่า default สำหรับ database และ login textboxes
            SetDefaultValues();
            
            // เน้นที่ host textbox
            dbHostTextBox.Focus();
        }

        private void SetDefaultValues()
        {
            // เซ็ตค่า default จาก app.config (ไม่ต้องมี default text ตามที่ user ต้องการ)
            App.AppConfig = new AppConfig();
            App.AppConfig.LoadConfig();

            // ไม่เซ็ตค่า default ใน textbox ตามที่ user ต้องการ
            dbHostTextBox.Text = "";
            dbPortTextBox.Text = "";
            dbUserTextBox.Text = "";
            dbPasswordTextBox.Text = "";
            dbNameTextBox.Text = "";
        }

        private void InitDBConnection()
        {
            try
            {
                // อ่านค่าจาก textbox
                string host = dbHostTextBox.Text.Trim();
                string port = dbPortTextBox.Text.Trim();
                string user = dbUserTextBox.Text.Trim();
                string password = dbPasswordTextBox.Text.Trim();
                string databaseName = dbNameTextBox.Text.Trim();

                // สร้าง connection string จากค่าที่ผู้ใช้ใส่
                if (App.AppConfig == null)
                    App.AppConfig = new AppConfig();
                
                string connectionString = App.AppConfig.GetConnectionString(host, port, user, password, databaseName);
                
                App.DBConnection = new BizFlowControl.DBConnection(connectionString);
                App.DBConnection.TestConnect();
                
                statusLabel.Text = "เชื่อมต่อ Database สำเร็จ";
                statusLabel.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"ไม่สามารถเชื่อมต่อ Database: {ex.Message}";
                statusLabel.ForeColor = Color.Red;
                
                App.DBConnection = null;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F12)
            {
                // เปิด database setting form
                var dbForm = new DBSettingForm();
                if (dbForm.ShowDialog(this) == DialogResult.OK)
                {
                    // อัพเดต textbox ด้วยค่าใหม่
                    SetDefaultValues();
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            // เคลียร์ status label
            statusLabel.Text = "";

            // ตรวจสอบ database configuration input
            if (string.IsNullOrEmpty(dbHostTextBox.Text.Trim()))
            {
                statusLabel.Text = "กรุณาใส่ Database Host";
                statusLabel.ForeColor = Color.Red;
                dbHostTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(dbPortTextBox.Text.Trim()))
            {
                statusLabel.Text = "กรุณาใส่ Database Port";
                statusLabel.ForeColor = Color.Red;
                dbPortTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(dbUserTextBox.Text.Trim()))
            {
                statusLabel.Text = "กรุณาใส่ Database Username";
                statusLabel.ForeColor = Color.Red;
                dbUserTextBox.Focus();
                return;
            }

            if (string.IsNullOrEmpty(dbNameTextBox.Text.Trim()))
            {
                statusLabel.Text = "กรุณาใส่ Database Name";
                statusLabel.ForeColor = Color.Red;
                dbNameTextBox.Focus();
                return;
            }

            // เชื่อมต่อ database ด้วยค่าที่ผู้ใช้ใส่
            statusLabel.Text = "กำลังเชื่อมต่อ Database...";
            statusLabel.ForeColor = Color.Blue;
            Application.DoEvents();

            InitDBConnection();

            // ตรวจสอบการเชื่อมต่อ database
            if (App.DBConnection == null)
            {
                statusLabel.Text = "ไม่สามารถเชื่อมต่อ Database ได้";
                statusLabel.ForeColor = Color.Red;
                return;
            }

            // เข้าสู่ระบบสำเร็จ (ไม่ต้องมี user authentication)
            isLoggedIn = true;
            App.IsUserLoggedIn = true;
            
            statusLabel.Text = "เข้าสู่ระบบสำเร็จ!";
            statusLabel.ForeColor = Color.Green;
            
            // เปิดใช้งาน process tab
            processTabPage.Enabled = true;
            
            // เปลี่ยนไปที่ process tab
            mainTabControl.SelectedIndex = 1;
            
            // ปิดการใช้งาน login tab หลังจาก login สำเร็จ
            loginTabPage.Enabled = false;
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            // ตรวจสอบ database configuration input
            if (string.IsNullOrEmpty(dbHostTextBox.Text.Trim()) ||
                string.IsNullOrEmpty(dbPortTextBox.Text.Trim()) ||
                string.IsNullOrEmpty(dbUserTextBox.Text.Trim()) ||
                string.IsNullOrEmpty(dbNameTextBox.Text.Trim()))
            {
                statusLabel.Text = "กรุณาใส่ข้อมูล Database Configuration ให้ครบ";
                statusLabel.ForeColor = Color.Red;
                return;
            }

            statusLabel.Text = "กำลังทดสอบการเชื่อมต่อ...";
            statusLabel.ForeColor = Color.Blue;
            Application.DoEvents();

            try
            {
                // อ่านค่าจาก textbox
                string host = dbHostTextBox.Text.Trim();
                string port = dbPortTextBox.Text.Trim();
                string user = dbUserTextBox.Text.Trim();
                string password = dbPasswordTextBox.Text.Trim();
                string databaseName = dbNameTextBox.Text.Trim();

                // สร้าง connection string จากค่าที่ผู้ใช้ใส่
                if (App.AppConfig == null)
                    App.AppConfig = new AppConfig();
                
                string connectionString = App.AppConfig.GetConnectionString(host, port, user, password, databaseName);
                
                BizFlowControl.DBConnection testConnection = new BizFlowControl.DBConnection(connectionString);
                
                if (testConnection.TestConnect())
                {
                    bool isDatabaseExists = testConnection.DatabaseExists(databaseName);
                    if (isDatabaseExists)
                    {
                        statusLabel.Text = "ทดสอบการเชื่อมต่อสำเร็จ!";
                        statusLabel.ForeColor = Color.Green;
                    }
                    else
                    {
                        statusLabel.Text = $"ไม่พบ Database: {databaseName}";
                        statusLabel.ForeColor = Color.Orange;
                    }
                    testConnection.Disconnect();
                }
                else
                {
                    statusLabel.Text = "ไม่สามารถเชื่อมต่อ Database ได้";
                    statusLabel.ForeColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                statusLabel.Text = $"เกิดข้อผิดพลาด: {ex.Message}";
                statusLabel.ForeColor = Color.Red;
            }
        }
    }
}
