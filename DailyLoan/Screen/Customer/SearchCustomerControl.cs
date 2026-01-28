using DailyLoan.Data;
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
            string filter = this.GetFilterCommand();

            int rowPerPage = this._searchResultGrid._rowPerPage;
            int offset = (this._pageNumber - 1) * rowPerPage;

            Paginator paginator = new Paginator(this._pageNumber, this._pageSize);


            string queryRowCount = "SELECT COUNT(*) FROM mst_customer " + (filter.Length > 0 ? " WHERE " + filter : "");
            string queryQuery ="SELECT code, name_1, telephone from mst_customer " + (filter.Length > 0 ? " WHERE " + filter : "") + paginator.GetPaginationQuery();

            DataSet result = App.DBConnection.QueryData(queryQuery);
            if (result.Tables.Count > 0)
            {
                this._searchResultGrid._loadFromDataTable(result.Tables[0], result.Tables[0].Select());
            }
        }
    }
}

