using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Loan
{
    public class SearchContractForm : Control.SearchDataForm
    {
        public SearchContractForm()
        {
            this.Text = "ค้นหาสัญญา";
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridDateColumn() { ColumnName = "วันที่", ColumnCode = "contract_date", WidthPercent = 30 });
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "เลขที่สัญญา", ColumnCode = "contract_no", WidthPercent = 70 });
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ลูกค้า", ColumnCode = "customer", WidthPercent = 70 });
            this.searchDataControl1._searchResultGrid._calcPersentWidthToScatter();

        }

        protected override void LoadData()
        {
            string queryList = "SELECT contract_date, contract_no " +
                ", (select code || '~' || name_1 from mst_customer where mst_customer.code = txn_contract.customer_code ) as customer  from " + Data.Models.Contract.TABLE_NAME;

            var result = App.DBConnection.QueryData(queryList);
            if (result.Tables.Count > 0)
            {
                this.searchDataControl1._searchResultGrid._loadFromDataTable(result.Tables[0], result.Tables[0].Select());
            }
        }

    }
}
