using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.LoanType
{
    public class SearchLoanTypeForm : Control.SearchDataForm
    {
        public SearchLoanTypeForm()
        {
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสประเภทเงินกู้", ColumnCode = "code", WidthPercent = 30 });
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ชื่อประเภทเงินกู้", ColumnCode = "name_1", WidthPercent = 70 });
            this.searchDataControl1._searchResultGrid._calcPersentWidthToScatter();

        }

        protected override void LoadData()
        {
            string queryList = "SELECT code, name_1 from mst_loan_type order by code";

            var result = App.DBConnection.QueryData(queryList);
            if (result.Tables.Count > 0)
            {
                this.searchDataControl1._searchResultGrid._loadFromDataTable(result.Tables[0], result.Tables[0].Select());
            }
        }
    }
}
