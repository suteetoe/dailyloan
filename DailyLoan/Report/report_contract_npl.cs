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
    public class report_contract_npl : BizFlowControl.ReportRender
    {
        report_contract_npl_condition conditionForm = new report_contract_npl_condition();

        public const string REPORT_NAME = "รายงานประมาณการหนี้สงสัยจะสูญ (NPL)";

        public report_contract_npl()
        {
            this.ReportTitle = REPORT_NAME;
            this.detailFont = new System.Drawing.Font("Angsana New", 12);

            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เลขที่สัญญา", ColumnWidth = 15, DataField = "contract_no" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ลูกค้า", ColumnWidth = 15, DataField = "customer" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เงินต้น", ColumnWidth = 12, DataField = "principle_amount", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ดอกเบี้ย", ColumnWidth = 12, DataField = "total_interest", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "รวม", ColumnWidth = 12, DataField = "total_contract_amount", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "งวดสุดท้าย", ColumnWidth = 12, DataField = "last_period_date", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "จ่ายแล้ว", ColumnWidth = 12, DataField = "total_pay_amount", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เกินกำหนด(วัน)", ColumnWidth = 12, DataField = "over_due_days", ContentAlignment = ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ค้างชำระ", ColumnWidth = 12, DataField = "balance_amount", ContentAlignment = ContentAlignment.MiddleRight });


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
                string route = this.conditionForm._conditionScreen._getDataStr("route_code");

                this.ConditionText = string.Format("สาย: {0}",
                   (route.Length > 0 ? route : "ทั้งหมด"));

                string routeFilter = " route_code = @route_code ";

                string query =
                    @"WITH contract_npl as (
	                    SELECT txn_contract.contract_no,
	                    txn_contract.route_code,
	                    txn_contract.customer_code,
	                    txn_contract.last_period_date,
	                    txn_contract.principle_amount, 
	                    txn_contract.total_interest,
	                    txn_contract.total_contract_amount, 
	                    date(now()) - txn_contract.last_period_date AS over_due_days,
	                    txn_contract.total_pay_amount, 
	                    txn_contract.total_contract_amount - txn_contract.total_pay_amount AS balance_amount
	                    FROM txn_contract, sys_options
	                    WHERE txn_contract.contract_status = 0 " + (route.Length > 0 ? " AND " + routeFilter : "") + @"
	                    AND (txn_contract.total_contract_amount - txn_contract.total_pay_amount) > 0::numeric 
	                    AND (date(now()) - txn_contract.last_period_date) > sys_options.npl_period
	                    ORDER BY txn_contract.last_period_date

                    )
                    SELECT
	                    contract_no, route_code, customer_code, mst_customer.name_1, principle_amount
	                    , total_interest, total_contract_amount, total_pay_amount
	                    , last_period_date, over_due_days, balance_amount
                    FROM contract_npl
                    JOIN mst_customer on mst_customer.code = contract_npl.customer_code
                    order by contract_no
                    ";

                BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
                if (route.Length > 0)
                {
                    parameters.Add("@route_code", route);
                }

                DataSet ds = App.DBConnection.QueryData(query, parameters);
                if (ds.Tables.Count > 0)
                {
                    decimal totalBalanceAmount = 0M;

                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        var row = new BizFlowControl.ReportDataRow();
                        row["contract_no"] = dr["contract_no"];
                        row["customer"] = dr["name_1"];//  string.Format("{0} {1}", dr["customer_code"], );
                        row["principle_amount"] = Convert.ToDecimal(dr["principle_amount"]).ToString("#,##0.00");
                        row["total_interest"] = Convert.ToDecimal(dr["total_interest"]).ToString("#,##0.00");
                        row["total_contract_amount"] = Convert.ToDecimal(dr["total_contract_amount"]).ToString("#,##0.00");
                        row["last_period_date"] = Convert.ToDateTime(dr["last_period_date"]).ToString("dd/MM/yyyy");
                        row["total_pay_amount"] = Convert.ToDecimal(dr["total_pay_amount"]).ToString("#,##0.00");
                        row["over_due_days"] = dr["over_due_days"].ToString();
                        row["balance_amount"] = Convert.ToDecimal(dr["balance_amount"]).ToString("#,##0.00");

                        totalBalanceAmount += Convert.ToDecimal(dr["balance_amount"]);

                        this.ReportData.Add(row);
                    }

                    // total row
                    var totalRow = new BizFlowControl.ReportDataRow();
                    totalRow.IsTotalRow = true;
                    totalRow["customer"] = "รวมทั้งสิ้น";
                    totalRow["balance_amount"] = totalBalanceAmount.ToString("#,##0.00");
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


    public class report_contract_npl_condition : ConditionReportForm
    {
        public report_contract_npl_condition()
        {
            this.titlePanel1.Title = report_contract_npl.REPORT_NAME;
            this._conditionScreen._maxColumn = 2;
            this._conditionScreen.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, ColumnSpan = 2, FieldCode = "route_code", FieldName = "สาย", IsSearch = true, IsAutoUpper = true });

        }

    }
}
