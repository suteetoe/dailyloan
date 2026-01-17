using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.Options
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
            this.loadData();
        }

        void loadData()
        {
            string query = "SELECT npl_period FROM sys_options";

            DataSet ds = App.DBConnection.QueryData(query);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                this._optionDetailScreen1._loadData(dt);
            }
        }

        private void _cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _saveButton_Click(object sender, EventArgs e)
        {
            var txn = App.DBConnection.CreateTransactionConnection();

            try
            {
                // delete 
                string deleteQuery = "DELETE FROM sys_options";
                txn.ExecuteCommand(deleteQuery);

                string periodNumber = this._optionDetailScreen1._getDataNumber("npl_period").ToString();


                // insert
                string insertQuery = "INSERT INTO sys_options (npl_period) VALUES (" + periodNumber + ");";

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
    }
}

