using DailyLoan.Data;
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
        //protected int _rowPerPage = 15;
        //protected int _pageNumber = 1;
        //protected int _recordCount = 0;

        //public int RecordCount
        //{
        //    get { return _recordCount; }
        //    set {
        //        _recordCount = value;
        //    }
        //}

        public SearchDataForm()
        {
            InitializeComponent();

            this.Load += SearchDataForm_Load;
            this.searchDataControl1._textSearchTextbox.KeyPress += _textSearchTextbox_KeyPress;
            this.searchDataControl1._buttonSearch.Click += _buttonSearch_Click;
            this.searchDataControl1.OnLoadDataList += SearchDataControl1_OnLoadDataList;
            this.searchDataControl1.AfterSelectData += SearchDataControl1_AfterSelectData;
        }

        private void SearchDataControl1_OnLoadDataList()
        {
            this.LoadData();
        }

        private void _textSearchTextbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            ReStartLoadTimer();
        }

        void ReStartLoadTimer()
        {
            this._loadTimer.Stop();
            this._loadTimer.Start();
        }

        private void _buttonSearch_Click(object sender, EventArgs e)
        {
            this._loadTimer.Stop();
            this.StartLoadData();
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
            StartLoadData();
        }

        void StartLoadData()
        {
            this.searchDataControl1._pageSize = this.searchDataControl1._searchResultGrid._rowPerPage;
            LoadData();
        }

        protected virtual void LoadData()
        {
            string loadDataQuery = this.LoadDataListQuery();
            if (loadDataQuery.Length > 0)
            {
                try
                {
                    string countRecordQuery = "SELECT COUNT(*) AS total_record FROM (" + loadDataQuery + ") AS temp_table";
                    int recordCount = App.DBConnection.ExecuteScalar<int>(countRecordQuery);



                    Paginator paginator = new Paginator(this.searchDataControl1._pageNumber, this.searchDataControl1._pageSize);
                    string sortQuery = this.SortField();

                    string paginatedQuery = loadDataQuery + " " + sortQuery + " " + paginator.GetPaginationQuery();

                    var dataSet = App.DBConnection.QueryData(paginatedQuery);
                    if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                    {
                        this.searchDataControl1._searchResultGrid._loadFromDataTable(dataSet.Tables[0], dataSet.Tables[0].Select());
                    }
                    else
                    {
                        this.searchDataControl1._searchResultGrid._clear();
                    }
                    this.searchDataControl1.TotalRecord = recordCount;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Load Data Error : " + ex.Message);
                }
            }
        }

        protected virtual string LoadDataListQuery()
        {
            return "";
        }

        protected virtual string SortField()
        {
            return "";
        }

        public event AfterSelectDataEventHandler AfterSelectData;

    }

}
