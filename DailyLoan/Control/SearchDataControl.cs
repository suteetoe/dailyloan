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
    public partial class SearchDataControl : UserControl
    {
        protected int _pageNumber = 1;
        public SearchDataControl()
        {
            InitializeComponent();
            this._searchResultGrid._isEdit = false;
            this._searchResultGrid._mouseClick += _searchResultGrid__mouseClick;
            // this._searchResultGrid._mouseDoubleClick += _searchResultGrid__mouseDoubleClick;
        }

        private void _searchResultGrid__mouseClick(object sender, SMLControl.GridCellEventArgs e)
        {
            if (e._row > -1 && e._row < this._searchResultGrid._rowData.Count)
            {
                SMLControl.GridRowData rowData = this._searchResultGrid._getRowData(e._row);
                if (this.AfterSelectData != null)
                {
                    this.AfterSelectData(rowData);
                }
            }
        }

        private void _searchResultGrid__mouseDoubleClick(object sender, SMLControl.GridCellEventArgs e)
        {
            if (e._row > -1 && e._row < this._searchResultGrid._rowData.Count)
            {
                SMLControl.GridRowData rowData = this._searchResultGrid._getRowData(e._row);
                if (this.AfterSelectData != null)
                {
                    this.AfterSelectData(rowData);
                }
            }
        }

        public event AfterSelectDataEventHandler AfterSelectData;
    }

    public delegate void AfterSelectDataEventHandler(SMLControl.GridRowData rowData);
}
