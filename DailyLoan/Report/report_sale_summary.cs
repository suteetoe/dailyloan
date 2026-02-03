using DailyLoan.Screen.Route;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Report
{
    public class report_sale_summary : BizFlowControl.ReportRender
    {
        report_sale_summary_condition conditionForm = new report_sale_summary_condition();
        public const string REPORT_NAME = "รายงานยอดขาย";

        public report_sale_summary()
        {
            this.ReportTitle = REPORT_NAME;
            // this.Landscape = true;

            this.detailFont = new System.Drawing.Font("Angsana New", 12);

            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "วันที่", ColumnWidth = 10, DataField = "contract_date" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เลขที่สัญญา", ColumnWidth = 15, DataField = "contract_no" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ลูกค้า", ColumnWidth = 18, DataField = "customer" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เงินต้น", ColumnWidth = 12, DataField = "principle_amount", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "จำนวนงวด", ColumnWidth = 12, DataField = "num_of_period", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ดอกเบี้ย", ColumnWidth = 12, DataField = "total_interest", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เริ่มต้นชำระ", ColumnWidth = 10, DataField = "first_period_date" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "สิ้นสุด", ColumnWidth = 10, DataField = "last_period_date" });


        }

        protected override bool ShowCondition()
        {
            DialogResult result = conditionForm.ShowDialog();
            if (result == DialogResult.Yes)
            {
                string requireField = this.conditionForm._conditionScreen._checkEmtryField();
                if (requireField.Length > 0)
                {
                    MessageBox.Show("กรุณาระบุข้อมูลให้ครบถ้วน\r\n" + requireField, "รายงานลูกหนี้และยอดคงเหลือทั้งหมด", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
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

                this.ConditionText = string.Format("จากวันที่ {0} ถึงวันที่ {1} สาย {2}",
                    from_date.ToString("dd/MM/yyyy"),
                    to_date.ToString("dd/MM/yyyy"),
                    route);

                string query =
                    @"select contract_date, contract_no, route_code, (name_1) as customer
, principle_amount, num_of_period, total_interest, first_period_date, last_period_date

from txn_contract 
join mst_customer on mst_customer.code = txn_contract.customer_code
where contract_date between @from_date and @to_date AND route_code = @route_code order by contract_date, contract_no
                ";

                BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@from_date", from_date);
                parameters.Add("@to_date", to_date);
                parameters.Add("@route_code", route);

                DataSet ds = App.DBConnection.QueryData(query, parameters);
                if (ds.Tables.Count > 0)
                {
                    decimal totalPrincipleAmount = 0M;
                    decimal totalInterestAmount = 0M;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        var row = new BizFlowControl.ReportDataRow();
                        row["contract_no"] = dr["contract_no"];
                        row["contract_date"] = Convert.ToDateTime(dr["contract_date"]).ToString("dd/MM/yyyy");
                        row["customer"] = dr["customer"];//  string.Format("{0} {1}", dr["customer_code"], );
                        row["principle_amount"] = Convert.ToDecimal(dr["principle_amount"]).ToString("#,##0.00");
                        row["num_of_period"] = Convert.ToInt16(dr["num_of_period"]).ToString("#,##0.00");
                        row["total_interest"] = Convert.ToDecimal(dr["total_interest"]).ToString("#,##0.00");
                        row["first_period_date"] = Convert.ToDateTime(dr["first_period_date"]).ToString("dd/MM/yyyy");
                        row["last_period_date"] = Convert.ToDateTime(dr["last_period_date"]).ToString("dd/MM/yyyy");

                        totalPrincipleAmount += Convert.ToDecimal(dr["principle_amount"]);
                        totalInterestAmount += Convert.ToDecimal(dr["total_interest"]);

                        this.ReportData.Add(row);
                    }

                    // total row
                    var totalRow = new BizFlowControl.ReportDataRow();
                    totalRow.IsTotalRow = true;
                    totalRow["customer"] = "รวมทั้งสิ้น";
                    totalRow["principle_amount"] = totalPrincipleAmount.ToString("#,##0.00");
                    totalRow["total_interest"] = totalInterestAmount.ToString("#,##0.00");

                    this.ReportData.Add(totalRow);

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


    public class report_sale_summary_condition : ConditionReportForm
    {
        public report_sale_summary_condition()
        {
            this.titlePanel1.Title = report_sale_summary.REPORT_NAME;
            this._conditionScreen._maxColumn = 2;
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "from_date", FieldName = "จากวันที่", Required = true });
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 1, FieldCode = "to_date", FieldName = "ถึงวันที่", Required = true });
            this._conditionScreen.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, ColumnSpan = 2, FieldCode = "route_code", FieldName = "สาย", IsSearch = true, IsAutoUpper = true, Required = true });

            DateTime firstDateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this._conditionScreen._setDataDate("from_date", firstDateMonth);

            DateTime endDateMonth = firstDateMonth.AddMonths(1).AddDays(-1);
            this._conditionScreen._setDataDate("to_date", endDateMonth);

            this._conditionScreen._textBoxSearch += _conditionScreen__textBoxSearch;

        }

        private void _conditionScreen__textBoxSearch(object sender, string name)
        {
            if (name.Equals("route_code"))
            {
                SearchRouteForm searchRouteForm = new SearchRouteForm();
                searchRouteForm.AfterSelectData += (rowData) =>
                {
                    this._conditionScreen._setDataStr("route_code", rowData["code"].ToString());

                    searchRouteForm.Close();
                };
                this._conditionScreen.StartSearchForm(searchRouteForm, "route_code");
            }
        }
    }
}
