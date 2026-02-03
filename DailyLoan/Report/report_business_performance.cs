using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Report
{
    public class report_business_performance : BizFlowControl.ReportRender
    {
        report_business_performance_condition conditionForm = new report_business_performance_condition();
        public const string REPORT_NAME = "รายงานผลการดำเนินการ";

        public report_business_performance()
        {
            this.ReportTitle = REPORT_NAME;
            this.detailFont = new System.Drawing.Font("Angsana New", 12);
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "รายการ", ColumnWidth = 70, DataField = "detail" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "มูลค่า", ColumnWidth = 30, DataField = "amount", ContentAlignment = System.Drawing.ContentAlignment.MiddleRight });

        }

        protected override bool ShowCondition()
        {
            var result = conditionForm.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.Yes)
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

                this.ConditionText = string.Format("จากวันที่ {0} ถึงวันที่ {1}",
                    from_date.ToString("dd/MM/yyyy"),
                    to_date.ToString("dd/MM/yyyy"));

                string query =
                    @"
                    WITH contract_payment AS (
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
                    , contract_sale AS (
	                    select contract_date, contract_no, customer_code, principle_amount
	                    from txn_contract
                    )
                    , expense as (
	                    select doc_date, total_amount
	                    from txn_expense
                    )

                    select 
	                    coalesce((select sum(total_amount) from contract_payment where doc_date between @from_date and @to_date ), 0) as total_contract_payment
	                    , coalesce((select sum(principle_amount) from contract_sale where contract_date between @from_date and @to_date ), 0) as total_sale
	                    , coalesce((select sum(total_amount) from expense where doc_date between @from_date and @to_date ), 0) as total_expense
                    ";

                BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@from_date", from_date);
                parameters.Add("@to_date", to_date);

                DataSet ds = App.DBConnection.QueryData(query, parameters);
                if (ds.Tables.Count > 0)
                {
                    DataTable table = ds.Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        decimal total_payment = Convert.ToDecimal(table.Rows[0]["total_contract_payment"]);
                        decimal total_new_contract = Convert.ToDecimal(table.Rows[0]["total_sale"]);
                        decimal total_expense = Convert.ToDecimal(table.Rows[0]["total_expense"]);
                        //
                        var rowPayment = new BizFlowControl.ReportDataRow();
                        rowPayment["detail"] = "รายได้จากการเก็บเงินงวด";
                        rowPayment["amount"] = total_payment.ToString("#,##0.00");
                        this.ReportData.Add(rowPayment);

                        //
                        var rowSale = new BizFlowControl.ReportDataRow();
                        rowSale["detail"] = "หัก การขายสัญญา";
                        rowSale["amount"] = total_new_contract.ToString("#,##0.00");
                        this.ReportData.Add(rowSale);

                        //
                        var rowExpense = new BizFlowControl.ReportDataRow();
                        rowExpense["detail"] = "หัก ค่าใช้จ่ายในการดำเนินงาน";
                        rowExpense["amount"] = total_expense.ToString("#,##0.00");
                        this.ReportData.Add(rowExpense);

                        // net profit
                        var rowNetProfit = new BizFlowControl.ReportDataRow();
                        rowNetProfit.IsTotalRow = true;
                        rowNetProfit["detail"] = "กำไร(ขาดทุน)สุทธิ";
                        decimal net_profit = total_payment - (total_new_contract + total_expense);

                        rowNetProfit["amount"] = net_profit.ToString("#,##0.00");
                        this.ReportData.Add(rowNetProfit);

                    }
                }


                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error: " + ex.Message);
                return false;
            }
        }
    }

    public class report_business_performance_condition : ConditionReportForm
    {
        public report_business_performance_condition()
        {
            this.titlePanel1.Title = report_business_performance.REPORT_NAME;
            this._conditionScreen._maxColumn = 2;
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "from_date", FieldName = "จากวันที่", Required = true });
            this._conditionScreen.AddDateField(new SMLControl.DateField() { Row = 0, Column = 1, FieldCode = "to_date", FieldName = "ถึงวันที่", Required = true });


            DateTime firstDateMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            this._conditionScreen._setDataDate("from_date", firstDateMonth);

            DateTime endDateMonth = firstDateMonth.AddMonths(1).AddDays(-1);
            this._conditionScreen._setDataDate("to_date", endDateMonth);

        }
    }
}
