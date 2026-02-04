using DailyLoan.Screen.Route;
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

            this.detailFont = new System.Drawing.Font("Angsana New", 12);

            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "วันที่", ColumnWidth = 10, DataField = "contract_date" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เลขที่สัญญา", ColumnWidth = 15, DataField = "contract_no" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ลูกค้า", ColumnWidth = 25, DataField = "customer" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เงินต้น", ColumnWidth = 10, DataField = "principle_amount", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ดอกเบี้ย", ColumnWidth = 10, DataField = "total_interest", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "รวม", ColumnWidth = 10, DataField = "total_contract_amount", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ชำระแล้ว", ColumnWidth = 10, DataField = "total_pay_amount", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ยอดค้างชำระ", ColumnWidth = 10, DataField = "outstanding_amount", ContentAlignment = ContentAlignment.MiddleRight });

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

                string contractDateConditionText = "";
                string contractDateFilter = "";
                if (from_date.Year > 1900 && to_date.Year > 1900)
                {
                    contractDateConditionText = string.Format(
                        "จากวันที่ทำสัญญา {0} ถึงวันที่ทำสัญญา {1} ", 
                        from_date.ToString("dd/MM/yyyy"),
                        to_date.ToString("dd/MM/yyyy"));

                    contractDateFilter = " AND ( ct.contract_date between @from_date and @to_date ) ";
                }
                this.ConditionText = contractDateConditionText + string.Format("สาย {0}", route);

                string query =
                    @"select  ct.contract_no, ct.contract_date, ct.customer_code, cust.name_1, ct.principle_amount, ct.total_interest, total_contract_amount, total_pay_amount, (total_contract_amount - total_pay_amount) as outstanding_amount, ct.route_code
                from txn_contract as ct
                join mst_customer as cust on cust.code = ct.customer_code
                where route_code = @route_code " + contractDateFilter + @"
                order by ct.contract_date, ct.contract_no
                ";

                BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
                if (from_date.Year > 1900 && to_date.Year > 1900)
                {
                    parameters.Add("@from_date", from_date);
                    parameters.Add("@to_date", to_date);
                }
                parameters.Add("@route_code", route);

                DataSet ds = App.DBConnection.QueryData(query, parameters);
                if (ds.Tables.Count > 0)
                {

                    decimal totalContractAmount = 0M;
                    decimal totalPaidAmount = 0M;
                    decimal totalBalanceAmount = 0M;
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        var row = new BizFlowControl.ReportDataRow();
                        row["contract_no"] = dr["contract_no"];
                        row["contract_date"] = Convert.ToDateTime(dr["contract_date"]).ToString("dd/MM/yyyy");
                        row["customer"] = dr["name_1"];//  string.Format("{0} {1}", dr["customer_code"], );
                        row["principle_amount"] = Convert.ToDecimal(dr["principle_amount"]).ToString("#,##0.00");
                        row["total_interest"] = Convert.ToDecimal(dr["total_interest"]).ToString("#,##0.00");
                        row["total_contract_amount"] = Convert.ToDecimal(dr["total_contract_amount"]).ToString("#,##0.00");
                        row["total_pay_amount"] = Convert.ToDecimal(dr["total_pay_amount"]).ToString("#,##0.00");
                        row["outstanding_amount"] = Convert.ToDecimal(dr["outstanding_amount"]).ToString("#,##0.00");

                        totalContractAmount += Convert.ToDecimal(dr["total_contract_amount"]);
                        totalPaidAmount += Convert.ToDecimal(dr["total_pay_amount"]);
                        totalBalanceAmount += Convert.ToDecimal(dr["outstanding_amount"]);

                        this.ReportData.Add(row);
                    }

                    // total row
                    var totalRow = new BizFlowControl.ReportDataRow();
                    totalRow.IsTotalRow = true;
                    totalRow["customer"] = "รวมทั้งสิ้น";
                    totalRow["total_contract_amount"] = totalContractAmount.ToString("#,##0.00");
                    totalRow["total_pay_amount"] = totalPaidAmount.ToString("#,##0.00");
                    totalRow["outstanding_amount"] = totalBalanceAmount.ToString("#,##0.00");
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

    public class report_ar_balance_condition : ConditionReportForm
    {
        public report_ar_balance_condition()
        {
            this.titlePanel1.Title = report_ar_balance.REPORT_NAME;
            this._conditionScreen._maxColumn = 2;
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "from_date", FieldName = "จากวันที่ทำสัญญา" });
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 1, FieldCode = "to_date", FieldName = "ถึงวันที่ทำสัญญา" });
            this._conditionScreen.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, ColumnSpan = 2, FieldCode = "route_code", FieldName = "สาย", IsSearch = true, IsAutoUpper = true, Required = true });

            //DateTime firstDateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //this._conditionScreen._setDataDate("from_date", firstDateMonth);

            //DateTime endDateMonth = firstDateMonth.AddMonths(1).AddDays(-1);
            //this._conditionScreen._setDataDate("to_date", endDateMonth);

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
