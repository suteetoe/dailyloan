using DailyLoan.Screen.Route;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Report
{
    public class report_ar_contract_payment : BizFlowControl.ReportRender
    {
        report_ar_contract_payment_condition conditionForm = new report_ar_contract_payment_condition();
        public const string REPORT_NAME = "รายงานการรับชำระเงิน";

        public report_ar_contract_payment()
        {
            this.ReportTitle = REPORT_NAME;

            this.detailFont = new System.Drawing.Font("Angsana New", 12);

            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "วันที่", ColumnWidth = 15, DataField = "doc_date" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เลขใบเสร็จ", ColumnWidth = 20, DataField = "doc_no" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เลขที่สัญญา", ColumnWidth = 20, DataField = "contract_no" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ลูกค้า", ColumnWidth = 25, DataField = "customer" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ยอดชำระ", ColumnWidth = 15, DataField = "amount", ContentAlignment = System.Drawing.ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เงินต้น", ColumnWidth = 15, DataField = "principle_amount", ContentAlignment = System.Drawing.ContentAlignment.MiddleRight });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "ดอกเบี้ย", ColumnWidth = 15, DataField = "interest_amount", ContentAlignment = System.Drawing.ContentAlignment.MiddleRight });

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
                    @" WITH contract_payment as (
                    select txn_payment.id, txn_payment.doc_date, txn_payment.doc_time, txn_payment.doc_no, txn_payment.contract_no
                    , txn_contract.customer_code
                    , mst_customer.name_1 as customer_name
                    , txn_payment.total_amount, txn_contract.route_code
                    , txn_contract.interest_rate
                    from txn_payment 
                    join txn_contract on txn_contract.contract_no = txn_payment.contract_no
                    join mst_customer on mst_customer.code = txn_contract.customer_code
                    union all
                    select d.id, p.doc_date, p.doc_time, d.doc_no, d.contract_no
                    , txn_contract.customer_code
                    , mst_customer.name_1  as customer_name
                    , d.total_amount, txn_contract.route_code 
                    , txn_contract.interest_rate
                    from txn_route_payment_detail  as d
                    join txn_route_payment as p on p.doc_no = d.doc_no
                    join txn_contract on txn_contract.contract_no = d.contract_no
                    join mst_customer on mst_customer.code = txn_contract.customer_code
                    )
                    select id, doc_date, doc_time, doc_no, contract_no, customer_code, customer_name, total_amount, interest_rate
                    from contract_payment 
                    where ( doc_date between @from_date and @to_date ) and route_code = @route_code
                    order by doc_date,doc_time, id

                ";

                BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@from_date", from_date);
                parameters.Add("@to_date", to_date);
                parameters.Add("@route_code", route);

                DataSet ds = App.DBConnection.QueryData(query, parameters);
                if (ds.Tables.Count > 0)
                {
                    decimal sum_total_amount = 0;
                    decimal sum_total_principle = 0;
                    decimal sum_total_interest = 0;


                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        var row = new BizFlowControl.ReportDataRow();

                        decimal total_amount = Convert.ToDecimal(dr["total_amount"]);
                        row["doc_no"] = dr["doc_no"];
                        row["doc_date"] = Convert.ToDateTime(dr["doc_date"]).ToString("dd/MM/yyyy");
                        row["contract_no"] = dr["contract_no"];
                        row["customer"] = dr["customer_name"]; // string.Format("{0} {1}", dr["customer_code"], dr["customer_name"]);
                        row["amount"] = total_amount.ToString("#,##0.00");

                        decimal interest_rate = Convert.ToDecimal(dr["interest_rate"]);
                        decimal interest_amount = Math.Round((total_amount * interest_rate) / (100 + interest_rate), 2);
                        decimal principle_amount = total_amount - interest_amount;
                        row["principle_amount"] = principle_amount.ToString("#,##0.00");
                        row["interest_amount"] = interest_amount.ToString("#,##0.00");

                        //row["total_interest"] = Convert.ToDecimal(dr["total_interest"]).ToString("#,##0.00");
                        //row["outstanding_amount"] = Convert.ToDecimal(dr["outstanding_amount"]).ToString("#,##0.00");
                        this.ReportData.Add(row);

                        sum_total_amount += total_amount;
                        sum_total_principle += principle_amount;
                        sum_total_interest += interest_amount;
                    }

                    // total row

                    var totalRow = new BizFlowControl.ReportDataRow();
                    totalRow.IsTotalRow = true;
                    totalRow["customer"] = "รวมทั้งสิ้น";
                    totalRow["amount"] = sum_total_amount.ToString("#,##0.00");
                    totalRow["principle_amount"] = sum_total_principle.ToString("#,##0.00");
                    totalRow["interest_amount"] = sum_total_interest.ToString("#,##0.00");
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

    public class report_ar_contract_payment_condition : ConditionReportForm
    {
        public report_ar_contract_payment_condition()
        {
            this.titlePanel1.Title = report_ar_contract_payment.REPORT_NAME;
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
