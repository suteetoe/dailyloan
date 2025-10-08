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
    public partial class DBSettingForm : Form
    {
        public DBSettingForm()
        {
            InitializeComponent();

            if (App.AppConfig != null)
            {
                this.dbHostTextBox.Text = App.AppConfig.DBHost;
                this.dbPortTextBox.Text = App.AppConfig.DBPort;
                this.dbUserTextBox.Text = App.AppConfig.DBUsername;
                this.dbPasswordTextBox.Text = App.AppConfig.DBPassword;
                this.dbNameTextBox.Text = App.AppConfig.DBDatabaseName;
            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            string host = this.dbHostTextBox.Text.Trim();
            string port = this.dbPortTextBox.Text.Trim();
            string user = this.dbUserTextBox.Text.Trim();
            string password = this.dbPasswordTextBox.Text.Trim();
            string databaseName = this.dbNameTextBox.Text.Trim();

            if (App.AppConfig == null)
                App.AppConfig = new AppConfig();

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

        private void saveButton_Click(object sender, EventArgs e)
        {
            string host = this.dbHostTextBox.Text.Trim();
            string port = this.dbPortTextBox.Text.Trim();
            string user = this.dbUserTextBox.Text.Trim();
            string password = this.dbPasswordTextBox.Text.Trim();
            string databaseName = this.dbNameTextBox.Text.Trim();

            if (App.AppConfig == null)
                App.AppConfig = new AppConfig();

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
                        this.DialogResult = DialogResult.OK;
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

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}