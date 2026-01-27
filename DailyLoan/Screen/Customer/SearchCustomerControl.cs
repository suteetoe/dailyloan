using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.Customer
{
    public class SearchCustomerControl : Control.SearchDataControl
    {
        public SearchCustomerControl()
        {
            this._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสลูกค้า", ColumnCode = "code", WidthPercent = 20 });
            this._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ชื่อลูกค้า", ColumnCode = "name_1", WidthPercent = 60 });
            this._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "โทรศัพท์", ColumnCode = "telephone", WidthPercent = 20 });
            this._searchResultGrid._calcPersentWidthToScatter();

        }

        public void SearchData()
        {
            string filter = "";
            string filterTextbox = this.GetFilterCommand();

            int rowPerPage = this._searchResultGrid._rowPerPage;
            int offset = (this._pageNumber - 1) * rowPerPage;

            string queryRowCount = "SELECT COUNT(*) FROM mst_customer " + filter;
            string queryQuery = string.Format("SELECT code, name_1, telephone from mst_customer {0} LIMIT {1} OFFSET {2} ", filterTextbox, rowPerPage, offset);

            DataSet result = App.DBConnection.QueryData(queryQuery);
            if (result.Tables.Count > 0)
            {
                this._searchResultGrid._loadFromDataTable(result.Tables[0], result.Tables[0].Select());
            }
        }
    }
}

