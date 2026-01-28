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

            // hide
            this._searchResultGrid.AddGridColumn(new SMLControl.GridIntegerColumn() { ColumnName = "is_npl", ColumnCode = "is_npl", WidthPercent = 20, IsQuery = false, IsHide = true });

            this._searchResultGrid._calcPersentWidthToScatter();

            this._searchResultGrid._beforeDisplayRow += _searchResultGrid__beforeDisplayRow;
        }

        private SMLControl.BeforeDisplayRowReturn _searchResultGrid__beforeDisplayRow(SMLControl._myGrid sender, int row, int columnNumber, string columnName, SMLControl.BeforeDisplayRowReturn senderRow, SMLControl._columnType columnType, System.Collections.ArrayList rowData)
        {
            string isNpl = rowData[sender._findColumnByName("is_npl")].ToString();

            if (isNpl == "1")
            {
                senderRow.newColor = System.Drawing.Color.Red;
            }

            return senderRow;
        }

        public void SearchData()
        {
            string filter = this.GetFilterCommand();

            this._pageSize = this._searchResultGrid._rowPerPage;
            //int offset = (this._pageNumber - 1) * rowPerPage;

            Paginator paginator = new Paginator(this._pageNumber, this._pageSize);


            string queryRowCount = "SELECT COUNT(*) FROM mst_customer " + (filter.Length > 0 ? " WHERE " + filter : "");

            int countResult = App.DBConnection.ExecuteScalar<int>(queryRowCount);

            string queryQuery = "SELECT code, name_1, telephone, view_customer_npl.is_npl " +
                " from mst_customer " +
                " left join view_customer_npl on view_customer_npl.customer_code = mst_customer.code "
                + (filter.Length > 0 ? " WHERE " + filter : "") + paginator.GetPaginationQuery();

            DataSet result = App.DBConnection.QueryData(queryQuery);
            if (result.Tables.Count > 0)
            {
                this._searchResultGrid._loadFromDataTable(result.Tables[0], result.Tables[0].Select());
            }

            this.TotalRecord = countResult;
        }
    }
}

