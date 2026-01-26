using ClosedXML.Excel;
using DailyLoan.Data.Models;
using DailyLoan.Data.Repository;
using DailyLoan.Domain;
using DailyLoan.Loan;
using SMLControl.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Daily
{
    public partial class DailyControl : UserControl
    {
        // ContractPayRepository contractPaymentRepository = new ContractPayRepository();

        RoutePaymentRepository routePaymentRepository = new RoutePaymentRepository();

        const string DOC_PREFIX = "RP";
        const string DOC_FORMAT = "@YYMM######";

        public DailyControl()
        {
            InitializeComponent();

            DateTime defaultDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            this._dailyExportScreenTop._setDataDate("contract_date", defaultDate);
        }

        private void _exportDailyDataExcel_Click(object sender, EventArgs e)
        {
            this.exportDailyDataSheet();
        }

        private void exportDailyDataSheet()
        {
            string routeCode = this._dailyExportScreenTop._getDataStr("route");
            DateTime dueDate = this._dailyExportScreenTop._getDataDate("contract_date");
            string fileName = string.Format("{0}_{1}.xlsx", _dateUtil._convertDateToQuery(dueDate), routeCode);

            FileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = fileName;
            saveFileDialog.Filter = "Excel Files|*.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var workbook = new XLWorkbook())
                {
                    var worksheet = workbook.Worksheets.Add("DailyData");
                    worksheet.Cell(1, 1).Value = "วันที่";
                    worksheet.Cell(1, 2).Value = "สัญญา";
                    worksheet.Cell(1, 3).Value = "ลูกค้า";
                    worksheet.Cell(1, 4).Value = "จำนวนเงิน";
                    worksheet.Cell(1, 5).Value = "ยอดค้างชำระ";
                    worksheet.Cell(1, 6).Value = "ยอดชำระ";


                    for (int i = 0; i < this._dailyExportGrid._rowData.Count; i++)
                    {
                        worksheet.Cell(i + 2, 1).Value = this._dailyExportScreenTop._getDataDate("contract_date").ToString("yyyy-MM-dd");
                        worksheet.Cell(i + 2, 2).Value = this._dailyExportGrid._cellGet(i, "contract_no").ToString();
                        worksheet.Cell(i + 2, 3).Value = this._dailyExportGrid._cellGet(i, "customer").ToString();
                        worksheet.Cell(i + 2, 4).Value = Convert.ToDecimal(this._dailyExportGrid._cellGet(i, "amount"));
                        worksheet.Cell(i + 2, 5).Value = Convert.ToDecimal(this._dailyExportGrid._cellGet(i, "over_due_amount"));
                    }

                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exported successfully.", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void importDailyDataSheet()
        {
            this.clearPaymentScreen();

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xlsx;*.xls";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this._importFileNameLabel.Text = string.Format("File : {0}", openFileDialog.FileName);
                    using (var workbook = new XLWorkbook(openFileDialog.FileName))
                    {
                        var worksheet = workbook.Worksheet(1); // Assuming data is in the first worksheet
                        var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header row


                        foreach (var row in rows)
                        {
                            decimal amount = _numberUtils._decimalPhase(row.Cell(4).GetString());
                            decimal overDueAmount = _numberUtils._decimalPhase(row.Cell(5).GetString());
                            decimal payAmount = _numberUtils._decimalPhase(row.Cell(6).GetString());

                            int addRowIdx = this._dailyPaymentGrid._addRow();
                            this._dailyPaymentGrid._cellUpdate(addRowIdx, "contract_no", row.Cell(2).GetString(), false);
                            this._dailyPaymentGrid._cellUpdate(addRowIdx, "customer", row.Cell(3).GetString(), false);
                            this._dailyPaymentGrid._cellUpdate(addRowIdx, "amount", amount, false);
                            this._dailyPaymentGrid._cellUpdate(addRowIdx, "over_due_amount", overDueAmount, false);
                            this._dailyPaymentGrid._cellUpdate(addRowIdx, "pay_amount", payAmount, true);

                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error importing Excel file:\r\n" + ex.Message, "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _processDailySheetButton_Click(object sender, EventArgs e)
        {
            this.GetDailyData();
        }

        void GetDailyData()
        {
            this._dailyExportGrid._clear();

            string routeCode = this._dailyExportScreenTop._getDataStr("route");
            DateTime dueDate = this._dailyExportScreenTop._getDataDate("contract_date");

            //string query = @"select c.contract_no, (c.customer_code || '~' || cs.name_1) as customer, p.amount 
            //    from txn_contract_period as p
            //    join txn_contract as c on c.contract_no = p.contract_no
            //    join mst_customer as cs on cs.code =c.customer_code
            //    where c.route_code = '" + routeCode + "' and p.due_date = '" + _dateUtil._convertDateToQuery(dueDate) + "' ";


            string queryDailyDue = @"with contract_period_with_payment as (
	select c.contract_no, c.route_code, c.customer_code, cp.period_no, due_date, amount, coalesce(pay_amount, 0) as pay_amount
	from txn_contract_period as cp
	join txn_contract as c on cp.contract_no = c.contract_no
	left join txn_contract_period_payment as pay on pay.contract_no = cp.contract_no and cp.period_no = pay.period_no
    where c.contract_status = 0 
)
, period_balance as (
select contract_no, route_code, customer_code, period_no, due_date, amount, pay_amount
, (amount - pay_amount) as balance_amount
, (case when (due_date < date(now()) and ((amount - pay_amount) > 0)) then (amount - pay_amount) else 0 end) as over_due_amount 

from contract_period_with_payment
)

select due_date, contract_no, (customer_code || '~' ||  cust.name_1) as customer, balance_amount as amount  
,(select sum(over_due_amount) from period_balance as ovd where ovd.contract_no = pb.contract_no ) as over_due_amount
from period_balance as pb
join mst_customer as cust on cust.code = pb.customer_code
where route_code = @route_code and due_date = @due_date ";

            BizFlowControl.ExecuteParams parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@route_code", routeCode);
            parameters.Add("@due_date", dueDate);

            DataSet ds = App.DBConnection.QueryData(queryDailyDue, parameters);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                this._dailyExportGrid._loadFromDataTable(dt, dt.Select());
            }

        }

        private void _importDailySheetButton_Click(object sender, EventArgs e)
        {
            this.importDailyDataSheet();
        }

        void clearPaymentScreen()
        {
            this._importFileNameLabel.Text = "File :";
            this._dailyImportScreenTop._clear();
            this._dailyPaymentGrid._clear();
        }

        private void _processPaymentButton_Click(object sender, EventArgs e)
        {

            string checkPayScreenInput = this._dailyImportScreenTop._checkEmtryField();
            if (checkPayScreenInput != "")
            {
                MessageBox.Show("กรุณาระบุข้อมูลให้ครบถ้วน\r\n" + checkPayScreenInput, "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string confirmPaymentMessage = "คุณต้องการบันทึกข้อมูลการชำระเงินใช่หรือไม่?";

            var result = MessageBox.Show(confirmPaymentMessage, "ยืนยันการชำระเงิน", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    DateTime docDate = this._dailyImportScreenTop._getDataDate("contract_date");
                    string routeCode = this._dailyImportScreenTop._getDataStr("route");

                    //for (int row = 0; row < this._dailyPaymentGrid._rowData.Count; row++)
                    //{
                    //    string contractNo = this._dailyPaymentGrid._cellGet(row, "contract_no").ToString();
                    //    decimal payAmount = (decimal)this._dailyPaymentGrid._cellGet(row, "pay_amount");

                    //    if (payAmount > 0)
                    //    {
                    //        string docNo = contractPaymentRepository.NextDocNo(PayContractForm.DOC_PREFIX, docDate, PayContractForm.DOC_FORMAT);

                    //        Data.Models.ContractPay contractPay = new Data.Models.ContractPay();
                    //        contractPay.doc_no = docNo;
                    //        contractPay.doc_date = docDate;
                    //        contractPay.doc_time = docDate.ToString("HH:mm");
                    //        contractPay.contract_no = contractNo;
                    //        contractPay.total_amount = payAmount;

                    //        contractPaymentRepository.CreateContractPayment(contractPay);
                    //    }
                    //}


                    string routePaymentDocNo = routePaymentRepository.NextDocNo(DOC_PREFIX, docDate, DOC_FORMAT);

                    RoutePayment payment = new RoutePayment();
                    payment.doc_no = routePaymentDocNo;
                    payment.doc_date = docDate;
                    payment.doc_time = docDate.ToString("HH:mm");
                    payment.route_code = routeCode;
                    payment.Details = new List<RoutePaymentDetail>();

                    decimal totalPayment = 0M;
                    for (int row = 0; row < this._dailyPaymentGrid._rowData.Count; row++)
                    {

                        string contractNo = this._dailyPaymentGrid._cellGet(row, "contract_no").ToString();
                        decimal payAmount = (decimal)this._dailyPaymentGrid._cellGet(row, "pay_amount");

                        if (payAmount > 0)
                        {
                            RoutePaymentDetail detail = new RoutePaymentDetail();
                            detail.contract_no = contractNo;
                            detail.total_amount = payAmount;
                            totalPayment += payAmount;
                            payment.Details.Add(detail);
                        }
                    }

                    payment.total_route_amount = totalPayment;

                    routePaymentRepository.CreateRoutePayment(payment);

                    MessageBox.Show("บันทึกข้อมูลการชำระเงินเรียบร้อยแล้ว", "ชำระเงินสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ContractProcess contractProcess = new ContractProcess();
                    for (int row = 0; row < this._dailyPaymentGrid._rowData.Count; row++)
                    {
                        string contractNo = this._dailyPaymentGrid._cellGet(row, "contract_no").ToString();
                        contractProcess.StartProcessPayment(contractNo);
                    }

                    this.clearPaymentScreen();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("เกิดข้อผิดพลาดในการบันทึกข้อมูลการชำระเงิน\r\n" + ex.Message, "ชำระเงินไม่สำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
