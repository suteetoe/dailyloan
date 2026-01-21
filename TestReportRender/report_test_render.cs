using BizFlowControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReportRender
{
    public class report_test_render : BizFlowControl.ReportRender
    {
        public report_test_render()
        {
            this.ReportTitle = "รายงานทดสอบการพิมพ์รายงาน";

            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "Code", ColumnWidth = 15, DataField = "code" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "Name", ColumnWidth = 25, DataField = "name" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "Address", ColumnWidth = 40, DataField = "address" });
            this.ReportColumns.Add(new BizFlowControl.ReportColumn() { HeaderText = "Telephone", ColumnWidth = 20, DataField = "telephonse" });
        }

        protected override bool ShowCondition()
        {
            return true;
        }

        protected override bool StartProcess()
        {
            try
            {
                this.ConditionText = "เงื่อนไขการพิมพ์รายงานทดสอบ";

                // Simulate data processing here 200 row
                for (int i = 1; i <= 200; i++)
                {
                    var row = new ReportDataRow();
                    row["code"] = "C" + i.ToString("000");
                    row["name"] = "Customer " + i;
                    row["address"] = "Address of Customer " + i;
                    row["telephonse"] = "012-345-6789";
                    this.ReportData.Add(row);
                }

                // add total row
                var totalRow = new ReportDataRow();
                totalRow["code"] = "";
                totalRow["name"] = "Total Customers: " + (this.ReportData.Count).ToString();
                totalRow["address"] = "";
                totalRow["telephonse"] = "";
                totalRow.IsTotalRow = true;
                this.ReportData.Add(totalRow);


                return true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in StartProcess: " + ex.Message);
                return false;
            }

        }
    }
}
