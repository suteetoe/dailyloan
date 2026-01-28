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
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ลูกค้า", ColumnCode = "customer", WidthPercent = 70, IsQuery = false });

            // hide
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสลูกค้า", ColumnCode = "mst_customer.code", WidthPercent = 0, IsHide = true });
            this.searchDataControl1._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ชื่อลูกค้า", ColumnCode = "mst_customer.name_1", WidthPercent = 0, IsHide = true });


            this.searchDataControl1._searchResultGrid._calcPersentWidthToScatter();

        }

        //protected override void LoadData()TE
        //{


        //    var result = App.DBConnection.QueryData(queryList);
        //    if (result.Tables.Count > 0)
        //    {
        //        this.searchDataControl1._searchResultGrid._loadFromDataTable(result.Tables[0], result.Tables[0].Select());
        //    }
        //}

        protected override string LoadDataListQuery()
        {
            string filter = this.searchDataControl1.GetFilterCommand();

            string queryList = "SELECT contract_date, contract_no " +
                ", (mst_customer.code  || '~' || mst_customer.name_1) as customer " +
                " FROM " + Data.Models.Contract.TABLE_NAME +
                " JOIN mst_customer on  mst_customer.code = txn_contract.customer_code " +
                " " + (filter.Length > 0 ? " WHERE " + filter : "");

            return queryList;
        }

        protected override string SortField()
        {
            string sortField = " order by contract_date, contract_no ";
            return sortField;
        }
    }
}
