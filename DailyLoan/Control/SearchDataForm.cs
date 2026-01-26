using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Control
{
    public partial class SearchDataForm : Form
    {
        public SearchDataForm()
        {
            InitializeComponent();

            this.Load += SearchDataForm_Load;
            this.searchDataControl1.AfterSelectData += SearchDataControl1_AfterSelectData;
        }

        private void SearchDataControl1_AfterSelectData(SMLControl.GridRowData rowData)
        {
            if (this.AfterSelectData != null)
            {
                this.AfterSelectData(rowData);
            }
        }

        private void SearchDataForm_Load(object sender, EventArgs e)
        {
            this._loadTimer.Start();
        }

        private void _loadTimer_Tick(object sender, EventArgs e)
        {
            _loadTimer.Stop();
            LoadData();
        }

        protected virtual void LoadData()
        {

        }

        public string getSortQuery()
        {
            return "";
        }

        public event AfterSelectDataEventHandler AfterSelectData;

    }

}
