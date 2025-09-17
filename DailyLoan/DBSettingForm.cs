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
    public partial class DBSettingForm : Form
    {
        public DBSettingForm()
        {
            InitializeComponent();

            this._dbHostTextbox.Text = App.AppConfig.DBHost;
            this._dbPortTextbox.Text = App.AppConfig.DBPort;
            this._dbUserNameTextbox.Text = App.AppConfig.DBUsername;
            this._dbPasswordTextbox.Text = App.AppConfig.DBPassword;
            this._dbDatabaseNameTextbox.Text = App.AppConfig.DBDatabaseName;
        }

        private void _testConnectionButton_Click(object sender, EventArgs e)
        {

            string host = this._dbHostTextbox.Text.Trim();
            string port = this._dbPortTextbox.Text.Trim();
            string user = this._dbUserNameTextbox.Text.Trim();
            string password = this._dbPasswordTextbox.Text.Trim();
            string databaseName = this._dbDatabaseNameTextbox.Text.Trim();

            string testConnectionString = App.AppConfig.GetConnectionString(host, port, user, password, "template1");
            BizFlowControl.DBConnection testConnection = new BizFlowControl.DBConnection(testConnectionString);

            try
            {
                if (testConnection.TestConnect())
                {
                    bool isDatabaseExists = testConnection.DatabaseExists(databaseName);
                    if (isDatabaseExists)
                    {                        
                        MessageBox.Show("Test connection success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Not found database : " + databaseName, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    testConnection.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connection database : " + host + "\r\n" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void _buttonSaveConnection_Click(object sender, EventArgs e)
        {
            string host = this._dbHostTextbox.Text.Trim();
            string port = this._dbPortTextbox.Text.Trim();
            string user = this._dbUserNameTextbox.Text.Trim();
            string password = this._dbPasswordTextbox.Text.Trim();
            string databaseName = this._dbDatabaseNameTextbox.Text.Trim();


            string testConnectionString = App.AppConfig.GetConnectionString(host, port, user, password, "template1");
            BizFlowControl.DBConnection testConnection = new BizFlowControl.DBConnection(testConnectionString);

            try
            {
                if (testConnection.TestConnect())
                {
                    bool isDatabaseExists = testConnection.DatabaseExists(databaseName);
                    if (isDatabaseExists)
                    {
                        App.AppConfig.ChangeConfig(host, port, user, password, databaseName);
                        MessageBox.Show("Save connection success", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Not found database : " + databaseName, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


                    }
                    testConnection.Disconnect();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot connection database : " + host + "\r\n" + ex.Message, "Failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
