using DailyLoan.Control;
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

namespace DailyLoan.Screen.Customer
{
    public partial class SearchCustomerForm : Form
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public event AfterSelectDataEventHandler AfterSelectData;

        public SearchCustomerForm()
        {
            InitializeComponent();

            this.Load += SearchCustomerForm_Load;
            this.searchCustomerControl1._buttonSearch.Click += _buttonSearch_Click;
            this.searchCustomerControl1._textSearchTextbox.KeyPress += _textSearchTextbox_KeyPress;
            this.searchCustomerControl1.AfterSelectData += SearchCustomerControl1_AfterSelectData;
        }

        private void _buttonSearch_Click(object sender, EventArgs e)
        {
            this._loadDataTimer.Stop();
            this.searchCustomerControl1.SearchData();
        }

        private void _textSearchTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ReStartLoadTimer();
        }

        void ReStartLoadTimer()
        {
            this._loadDataTimer.Stop();
            this._loadDataTimer.Start();

        }

        private void SearchCustomerControl1_AfterSelectData(SMLControl.GridRowData rowData)
        {
            if (this.AfterSelectData != null)
            {
                this.AfterSelectData(rowData);
            }
        }

        private void SearchCustomerForm_Load(object sender, EventArgs e)
        {
            this._loadDataTimer.Start();
        }

        private void _loadDataTimer_Tick(object sender, EventArgs e)
        {
            this._loadDataTimer.Stop();
            this.searchCustomerControl1.SearchData();

            Console.WriteLine("Load Data");
        }

        private void _saveNewCustomerButton_Click(object sender, EventArgs e)
        {
            string requireText = this._customerDataScreen1._checkEmtryField();
            if (requireText != "")
            {
                MessageBox.Show(requireText, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var customerData = this._customerDataScreen1.GetCustomerModel();
            _customerRepository.CreateCustomer(customerData);

            MessageBox.Show("บันทึกข้อมูลลูกค้าเรียบร้อยแล้ว", "บันทึกข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (this.AfterSelectData != null)
            {
                SMLControl.GridRowData rowData = new SMLControl.GridRowData();
                rowData.Add("code", customerData.code);

                this.AfterSelectData(rowData);
            }
        }
    }
}
