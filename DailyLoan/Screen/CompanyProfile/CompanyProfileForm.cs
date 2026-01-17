using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.CompanyProfile
{
    public partial class CompanyProfileForm : Form
    {
        public CompanyProfileForm()
        {
            InitializeComponent();

            this.loadData();
        }

        void loadData()
        {
            // select

            string query = "SELECT company_name, address, telephone FROM sys_company_profile";
            DataSet ds = App.DBConnection.QueryData(query);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                this._companyProfileDetailScreen1._loadData(dt);
            }

        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            var txn = App.DBConnection.CreateTransactionConnection();

            try
            {
                // delete 
                string deleteQuery = "DELETE FROM sys_company_profile";
                txn.ExecuteCommand(deleteQuery);

                // insert
                string insertQuery = "INSERT INTO sys_company_profile (company_name, address, telephone) VALUES ("
                    + "'" + this._companyProfileDetailScreen1._getDataStr("company_name") + "', "
                    + "'" + this._companyProfileDetailScreen1._getDataStr("address") + "', "
                    + "'" + this._companyProfileDetailScreen1._getDataStr("telephone") + "'"
                    + ");";

                txn.ExecuteCommand(insertQuery);
                txn.CommitTransaction();
            }
            catch (Exception ex)
            {
                txn.RollbackTransaction();
                MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูล \n" + ex.Message, "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("บันทึกข้อมูลเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
