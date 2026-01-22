using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Report
{
    public class report_ar_balance : BizFlowControl.ReportRender
    {
        report_ar_balance_condition conditionForm = new report_ar_balance_condition();

        public const string REPORT_NAME = "รายงานลูกหนี้และยอดคงเหลือทั้งหมด";
        public report_ar_balance()
        {
            this.ReportTitle = REPORT_NAME;

            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "วันที่", ColumnWidth = 7, DataField = "contract_date" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เลขที่สัญญา", ColumnWidth = 8, DataField = "contract_no" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ลูกค้า", ColumnWidth = 25, DataField = "address" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เบอร์โทร", ColumnWidth = 15, DataField = "address" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เงินต้น", ColumnWidth = 15, DataField = "principle_amount" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ดอกเบี้ย", ColumnWidth = 15, DataField = "total_interest" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ยอดค้างชำระ", ColumnWidth = 15, DataField = "outstanding_amount" });

        }

        protected override bool ShowCondition()
        {
            DialogResult result = conditionForm.ShowDialog();
            if (result == DialogResult.Yes)
            {

                return true;
            }
            return false;
        }

        protected override bool StartProcess()
        {
            try
            {


                DateTime from_date = this.conditionForm._conditionScreen._getDataDate("from_date");
                DateTime to_date = this.conditionForm._conditionScreen._getDataDate("to_date");
                string route = this.conditionForm._conditionScreen._getDataStr("route_code");

                this.ConditionText = string.Format("จากวันที่ทำสัญญา {0} ถึงวันที่ทำสัญญา {1} สาย {2}",
                    from_date.ToString("dd/MM/yyyy"),
                    to_date.ToString("dd/MM/yyyy"),
                    route);

                string query =
                    @"select  ct.contract_no, ct.contract_date, ct.customer_code, cust.name_1, ct.principle_amount, ct.total_interest, 0 as outstanding_amount, ct.route_code
                from txn_contract as ct
                join mst_customer as cust on cust.code = ct.customer_code
                where ( ct.contract_date between @from_date and @to_date ) and route_code = @route_code
                ";

                BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@from_date", from_date);
                parameters.Add("@to_date", to_date);
                parameters.Add("@route_code", route);

                DataSet ds = App.DBConnection.QueryData(query, parameters);
                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        var row = new BizFlowControl.ReportDataRow();
                        row["contract_no"] = dr["contract_no"];
                        row["contract_date"] = Convert.ToDateTime(dr["contract_date"]).ToString("dd/MM/yyyy");
                        row["address"] = string.Format("{0} {1}", dr["customer_code"], dr["name_1"]);
                        row["principle_amount"] = Convert.ToDecimal(dr["principle_amount"]).ToString("#,##0.00");
                        row["total_interest"] = Convert.ToDecimal(dr["total_interest"]).ToString("#,##0.00");
                        row["outstanding_amount"] = Convert.ToDecimal(dr["outstanding_amount"]).ToString("#,##0.00");
                        this.ReportData.Add(row);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }


     
    }

    public class report_ar_balance_condition : ConditionReportForm
    {
        public report_ar_balance_condition()
        {
            this.titlePanel1.Title = report_ar_balance.REPORT_NAME;
            this._conditionScreen._maxColumn = 2;
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "from_date", FieldName = "จากวันที่ทำสัญญา" });
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 1, FieldCode = "to_date", FieldName = "ถึงวันที่ทำสัญญา" });
            this._conditionScreen.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, ColumnSpan = 2, FieldCode = "route_code", FieldName = "สาย", IsSearch = true, IsAutoUpper = true });

            DateTime firstDateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this._conditionScreen._setDataDate("from_date", firstDateMonth);

            DateTime endDateMonth = firstDateMonth.AddMonths(1).AddDays(-1);
            this._conditionScreen._setDataDate("to_date", endDateMonth);

        }
    }
}
