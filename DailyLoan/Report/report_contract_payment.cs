using DailyLoan.Loan;
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
    public class report_contract_payment : BizFlowControl.ReportRender
    {
        report_contract_payment_condition conditionForm = new report_contract_payment_condition();

        public const string REPORT_NAME = "รายงานการชำระเงินสัญญา";

        public report_contract_payment()
        {
            this.ReportTitle = REPORT_NAME;
            this.detailFont = new System.Drawing.Font("Angsana New", 12);

            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "วันที่", ColumnWidth = 10, DataField = "doc_date" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "เลขที่เอกสาร", ColumnWidth = 15, DataField = "doc_no" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "สาย", ColumnWidth = 15, DataField = "route_code" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "จำนวนเงิน", ColumnWidth = 10, DataField = "total_amount", ContentAlignment = ContentAlignment.MiddleRight });

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
                string contract_no = this.conditionForm._conditionScreen._getDataStr("contract_no");
                this.ConditionText = string.Format("เลขที่สัญญา: {0}", contract_no);

                string query =
                    @"WITH contract_payment as (
                        select id, doc_date, doc_time, doc_no, contract_no, total_amount, '-' as route_code from txn_payment where contract_no = @contract_no
                        union all
                        select d.id, p.doc_date, p.doc_time, d.doc_no, d.contract_no, d.total_amount, p.route_code from txn_route_payment_detail  as d
                        join txn_route_payment as p on p.doc_no = d.doc_no
                        where d.contract_no = @contract_no
                    )
                    select id, doc_date, doc_time, doc_no, contract_no, total_amount, route_code
                    from contract_payment 
                    order by doc_date,doc_time, id";

                BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@contract_no", contract_no);

                DataSet ds = App.DBConnection.QueryData(query, parameters);
                if (ds.Tables.Count > 0)
                {
                    decimal totalPayAmount = 0;

                    DataTable dt = ds.Tables[0];
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {

                        DataRow dr = ds.Tables[0].Rows[i];
                        var row = new BizFlowControl.ReportDataRow();

                        decimal totalAmount = Convert.ToDecimal(dr["total_amount"]);

                        row["doc_date"] = Convert.ToDateTime(dr["doc_date"]).ToString("dd/MM/yyyy");
                        row["doc_no"] = dr["doc_no"].ToString();
                        row["route_code"] = dr["route_code"].ToString();
                        row["total_amount"] = totalAmount.ToString("#,##0.00");

                        totalPayAmount += totalAmount;
                        this.ReportData.Add(row);


                    }

                    var totalRow = new BizFlowControl.ReportDataRow();
                    totalRow.IsTotalRow = true;
                    totalRow["doc_no"] = "รวมทั้งสิ้น";
                    totalRow["total_amount"] = totalPayAmount.ToString("#,##0.00");
                    this.ReportData.Add(totalRow);
                }

                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return false;
        }

    }

    public class report_contract_payment_condition : ConditionReportForm
    {
        public report_contract_payment_condition()
        {
            this.titlePanel1.Title = report_contract_payment.REPORT_NAME;

            this._conditionScreen._maxColumn = 2;
            this._conditionScreen.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, ColumnSpan = 2, FieldCode = "contract_no", FieldName = "เลขที่สัญญา", IsSearch = true, IsAutoUpper = true, Required = true });

            this._conditionScreen._textBoxSearch += _conditionScreen__textBoxSearch;
        }

        private void _conditionScreen__textBoxSearch(object sender, string name)
        {
            if (name.Equals("contract_no"))
            {
                SearchContractForm searchContractForm = new SearchContractForm();
                searchContractForm.AfterSelectData += (rowData) =>
                {
                    this._conditionScreen._setDataStr("contract_no", rowData["contract_no"].ToString());
                    searchContractForm.Close();
                };

                this._conditionScreen.StartSearchForm(searchContractForm, "contract_no");

            }
        }
    }
}
