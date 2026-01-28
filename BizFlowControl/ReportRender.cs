using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BizFlowControl
{
    public class ReportRender
    {
        protected PrintDocument reportDocument;

        protected int page = 0;
        protected int paperWidth = 850;
        protected int paperHeight = 1100;
        protected int leftMergin = 50;
        protected int rightMergin = 50;
        protected int topMergin = 50;
        protected int bottomMergin = 50;
        protected SizeF printArea = new SizeF();

        protected System.Drawing.Font headerFont = new System.Drawing.Font("Angsana New", 16, FontStyle.Bold);
        protected System.Drawing.Font detailFont = new System.Drawing.Font("Angsana New", 14);

        public String ReportTitle { get; set; } = "รายงานXXX";
        public String ConditionText { get; set; } = "";

        protected List<ReportColumn> ReportColumns = new List<ReportColumn>();
        protected List<ReportDataRow> ReportData = new List<ReportDataRow>();

        protected int dataRowIndex = -1;

        public ReportRender()
        {
            this.reportDocument = new PrintDocument();
            this.reportDocument.BeginPrint += ReportDocument_BeginPrint;
            this.reportDocument.PrintPage += ReportDocument_PrintPage;

        }

        private void ReportDocument_BeginPrint(object sender, PrintEventArgs e)
        {
            this.dataRowIndex = 0;
            this.page = 0;
            this.paperWidth = this.reportDocument.DefaultPageSettings.PaperSize.Width;
            this.paperHeight = this.reportDocument.DefaultPageSettings.PaperSize.Height;
            this.printArea = new SizeF(
                this.paperWidth - (this.leftMergin + this.rightMergin),
                this.paperHeight - (this.topMergin + this.bottomMergin)
                );
        }

        private void ReportDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // drwa report title
            this.page++;
            StartPrintReportPage(e);

        }

        protected virtual void StartPrintReportPage(PrintPageEventArgs e)
        {
            float yPoint = this.topMergin;
            float sectionHeight = DrawReportTitle(yPoint, e.Graphics);
            yPoint += sectionHeight;

            if (ConditionText != "")
            {
                sectionHeight = DrawReportCondition(yPoint, e.Graphics);
                yPoint += sectionHeight;
            }

            DrawReportPage(yPoint, e);
        }

        protected virtual float DrawReportTitle(float drawYPoint, Graphics g)
        {
            SizeF sizeF = g.MeasureString(this.ReportTitle, headerFont);

            g.DrawString(this.ReportTitle,
                headerFont,
                Brushes.Black,
                (this.paperWidth - sizeF.Width) / 2,
                drawYPoint);

            return sizeF.Height;
        }

        protected virtual float DrawReportCondition(float drawYPoint, Graphics g)
        {
            SizeF sizeF = g.MeasureString(this.ConditionText, detailFont);

            g.DrawString(this.ConditionText,
                detailFont,
                Brushes.Black,
                (this.paperWidth - sizeF.Width) / 2,
                drawYPoint);

            return sizeF.Height;
        }

        protected virtual void DrawReportPage(float drawYPoint, PrintPageEventArgs e)
        {
            float currentYPoint = drawYPoint;
            float sectionHeight = DrawHeaderColumn(currentYPoint, e.Graphics);
            currentYPoint += sectionHeight;

            bool nextPage = false;

            float maxYPoint = this.paperHeight - this.bottomMergin;

            bool canDrawMore = true;
            while (canDrawMore)
            {
                if (dataRowIndex >= ReportData.Count)
                {
                    // no more data
                    canDrawMore = false;
                    nextPage = false;
                    break;
                }

                ReportDataRow row = ReportData[dataRowIndex];
                float rowHeight = MeasureRowHeight(row, e.Graphics);

                if (currentYPoint + rowHeight > maxYPoint)
                {                    
                    nextPage = true;
                    break;
                }
                else
                {
                    // draw report row
                    DrawReportDataRow(currentYPoint, row, e.Graphics);
                    currentYPoint += rowHeight;

                    // next row
                    dataRowIndex++;
                }
               
            }

            // draw last line
            Pen linePenDashDot = new Pen(Color.Black);
            linePenDashDot.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            e.Graphics.DrawLine(linePenDashDot, leftMergin, currentYPoint, paperWidth - rightMergin, currentYPoint);

            e.HasMorePages = nextPage;
        }

        protected virtual float DrawHeaderColumn(float drawYPoint, Graphics g)
        {
            Pen linePenDashDot = new Pen(Color.Black);
            linePenDashDot.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

            g.DrawLine(linePenDashDot, leftMergin, drawYPoint, paperWidth - rightMergin, drawYPoint);

            float headerHeight = 0f;
            for (int i = 0; i < ReportColumns.Count; i++)
            {
                ReportColumn column = ReportColumns[i];
                // draw column header text
                SizeF headerSize = g.MeasureString(column.HeaderText, detailFont);

                if (headerHeight < headerSize.Height)
                {
                    headerHeight = headerSize.Height;
                }

                g.DrawString(column.HeaderText,
                    detailFont,
                    Brushes.Black,
                    leftMergin + ReportColumns.Take(i).Sum(c => c.ColumnWidth / 100 * printArea.Width),
                    drawYPoint + 5);

            }

            g.DrawLine(linePenDashDot, leftMergin, drawYPoint + headerHeight + 5, paperWidth - rightMergin, drawYPoint + headerHeight + 5);

            return headerHeight;
        }

        protected virtual float DrawReportDataRow(float drawYPoint, ReportDataRow row, Graphics g)
        {
            if (row.IsTotalRow)
            {
                // draw line top
                Pen linePenBold = new Pen(Color.Black);
                linePenBold.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                g.DrawLine(linePenBold, leftMergin, drawYPoint, paperWidth - rightMergin, drawYPoint);

            }

            for (int i = 0; i < ReportColumns.Count; i++)
            {
                ReportColumn column = ReportColumns[i];

                StringFormat format = new StringFormat();
                if (column.ContentAlignment == ContentAlignment.MiddleRight)
                {
                    format.Alignment = StringAlignment.Far;
                }
                else if (column.ContentAlignment == ContentAlignment.MiddleCenter)
                {
                    format.Alignment = StringAlignment.Center;
                }
                else
                {
                    format.Alignment = StringAlignment.Near;
                }
                string dataText = GetRowDataText(row, column);

                g.DrawString(dataText,
                    detailFont,
                    Brushes.Black,
                    leftMergin + ReportColumns.Take(i).Sum(c => c.ColumnWidth / 100 * printArea.Width),
                    drawYPoint + 5, format);
            }

            return drawYPoint;
        }

        string GetRowDataText(ReportDataRow row, ReportColumn column)
        {
            string dataField = column.DataField;
            string format = column.Format;
            object dataValue = row.ContainsKey(dataField) ? row[dataField] : null;

            string dataText = "";
            if (dataValue != null)
            {
                if (format != null && format != "")
                {
                    if (dataValue is IFormattable)
                    {
                        dataText = ((IFormattable)dataValue).ToString(format, null);
                    }
                    else
                    {
                        dataText = dataValue.ToString();
                    }
                }
                else
                {
                    dataText = dataValue.ToString();
                }
            }

            return dataText;
        }

        float MeasureRowHeight(ReportDataRow row, Graphics g)
        {
            float rowHeight = 0f;

            for (int i = 0; i < ReportColumns.Count; i++)
            {
                ReportColumn column = ReportColumns[i];

                string dataText = GetRowDataText(row, column);
                SizeF dataSize = g.MeasureString(dataText, detailFont);
                if (rowHeight < dataSize.Height)
                {
                    rowHeight = dataSize.Height;
                }
            }

            return rowHeight;
        }


     

        protected virtual bool ShowCondition()
        {
            return false;
        }

        protected virtual bool StartProcess()
        {
            return false;
        }

        protected virtual void RenderReport()
        {

            PrintPreviewDialog previewReport = new PrintPreviewDialog();
            (previewReport as Form).Text = this.ReportTitle;
            previewReport.Document = this.reportDocument;
            (previewReport as Form).WindowState = FormWindowState.Maximized;
            previewReport.ShowDialog();
        }

        public void StartReport()
        {
            bool isProcess = this.ShowCondition();

            if (!isProcess)
            {
                return;
            }

            bool processSuccess = this.StartProcess();
            if (processSuccess)
            {
                this.RenderReport();
            }
        }

    }

    public class ReportColumn
    {
        public string HeaderText { get; set; }
        public float ColumnWidth { get; set; }
        public string DataField { get; set; }
        public string Format { get; set; }

        public ContentAlignment ContentAlignment { get; set; } = ContentAlignment.MiddleLeft;
    }

    public class ReportDataRow : Dictionary<string, object>
    {
        public Boolean IsTotalRow { get; set; } = false;
    }

}
