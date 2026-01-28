using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.Route
{
    public class SearchRouteForm : Control.SearchDataForm
    {
        public SearchRouteForm()
        {
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสสาย", ColumnCode = "code", WidthPercent = 30 });
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ชื่อสาย", ColumnCode = "name_1", WidthPercent = 70 });
            this.searchDataControl1._searchResultGrid._calcPersentWidthToScatter();

        }

        //protected override void LoadData()
        //{
        //    string queryList = "SELECT code, name_1 from mst_route ";

        //    var result = App.DBConnection.QueryData(queryList);
        //    if (result.Tables.Count > 0)
        //    {
        //        this.searchDataControl1._searchResultGrid._loadFromDataTable(result.Tables[0], result.Tables[0].Select());
        //    }
        //}

        protected override string LoadDataListQuery()
        {
            string filter = this.searchDataControl1.GetFilterCommand();

            string queryList = "SELECT code, name_1 from mst_route " + (filter.Length > 0 ? " WHERE " + filter : "");
            return queryList;
        }

        protected override string SortField()
        {
            return " order by code ";
        }
    }
}
