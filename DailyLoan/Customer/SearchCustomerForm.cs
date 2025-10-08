using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Customer
{
    public partial class SearchCustomerForm : Form
    {
        public SearchCustomerForm()
        {
            InitializeComponent();

            this.Load += SearchCustomerForm_Load;
        }

        private void SearchCustomerForm_Load(object sender, EventArgs e)
        {
            this._loadDataTimer.Start();
        }

        private void _loadDataTimer_Tick(object sender, EventArgs e)
        {
            this.searchCustomerControl1.SearchData();

        }
    }
}
