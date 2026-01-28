using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Control
{
    public partial class SearchDataControl : UserControl
    {
        public int _pageNumber = 1;
        public int _totalPage = 1;
        public int _pageSize = 15;
        public int _totalRecord = 0;

        public int TotalRecord
        {
            get { return _totalRecord; }
            set
            {
                _totalRecord = value;
                UpdateRecordLabel();
            }
        }

        void UpdateRecordLabel()
        {
            int totalPage = (int)Math.Ceiling((double)this._totalRecord / this._pageSize);
            this._totalPage = totalPage;

            string recordCountText = string.Format("{0} ({1}/{2})", this._totalRecord, this._pageNumber, this._totalPage);
            this._recordCountLabel.Text = recordCountText;
        }

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

        public string GetFilterCommand()
        {
            string filterValue = this._textSearchTextbox.Text.Trim();
            if (filterValue.Length == 0)
            {
                return "";
            }

            string[] splitFilterWord = filterValue.Split(' ');
            List<string> filterCommandList = new List<string>();

            foreach (string filterWord in splitFilterWord)
            {
                List<string> columnFilterList = new List<string>();
                foreach (SMLControl._columnType column in this._searchResultGrid._columnList)
                {
                    if (column._isQuery)
                    {
                        if (column._type == 1)
                        {
                            columnFilterList.Add(string.Format("{0} ILIKE '%{1}%'", column._originalName, filterWord.Replace("'", "''")));
                        }
                    }
                }

                if (columnFilterList.Count > 0)
                {
                    filterCommandList.Add("(" + string.Join(" OR ", columnFilterList.ToArray()) + ")");
                }
            }

            return  string.Join(" AND ", filterCommandList.ToArray());
        }

        public event AfterSelectDataEventHandler AfterSelectData;
    }

    public delegate void AfterSelectDataEventHandler(SMLControl.GridRowData rowData);
}
