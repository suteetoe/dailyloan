using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Report
{
    public class ReportViewer
    {
        //protected BizFlowControl.DBConnection connection;
        //protected PrintDocument reportDocument;

        //protected int page = 0;
        //protected int paperWidth = 850;
        //protected int paperHeight = 1100;
        //protected int leftMergin = 50;
        //protected int rightMergin = 50;
        //protected int topMergin = 50;
        //protected int bottomMergin = 50;
        //protected SizeF printArea = new SizeF();

        //protected System.Drawing.Font headerFont = new System.Drawing.Font("Angsana New", 16, FontStyle.Bold);
        //protected System.Drawing.Font detailFont = new System.Drawing.Font("Angsana New", 14);

        //public String ReportTitle { get; set; } = "รายงานXXX";
        //public String ConditionText { get; set; } = "";

        //public ReportViewer()
        //{
        //    this.connection = App.DBConnection;
        //    this.reportDocument = new PrintDocument();
        //    this.reportDocument.BeginPrint += ReportDocument_BeginPrint;
        //    this.reportDocument.PrintPage += ReportDocument_PrintPage;

        //}

        //private void ReportDocument_BeginPrint(object sender, PrintEventArgs e)
        //{
        //    this.page = 0;
        //    this.paperWidth = this.reportDocument.DefaultPageSettings.PaperSize.Width;
        //    this.paperHeight = this.reportDocument.DefaultPageSettings.PaperSize.Height;
        //    this.printArea = new SizeF(
        //        this.paperWidth - (this.leftMergin + this.rightMergin),
        //        this.paperHeight - (this.topMergin + this.bottomMergin)
        //        );
        //}

        //private void ReportDocument_PrintPage(object sender, PrintPageEventArgs e)
        //{
        //    // drwa report title
        //    this.page++;
        //    StartPrintReportPage(e.Graphics);
        //    DrawReportPage(e.Graphics, e);
        //}

        //protected virtual void StartPrintReportPage(Graphics g)
        //{
        //    float yPoint = this.topMergin;
        //    float headerHeight = DrawReportTitle(yPoint, g);

        //    if (ConditionText != "")
        //    {
        //        yPoint += headerHeight + 5;
        //        float conditionHeight = DrawReportCondition(yPoint, g);
        //    }

        //}

        //protected virtual float DrawReportTitle(float drawYPoint, Graphics g)
        //{
        //    SizeF sizeF = g.MeasureString(this.ReportTitle, headerFont);

        //    g.DrawString(this.ReportTitle,
        //        headerFont,
        //        Brushes.Black,
        //        (this.paperWidth - sizeF.Width) / 2,
        //        drawYPoint);

        //    return sizeF.Height;
        //}

        //protected virtual float DrawReportCondition(float drawYPoint, Graphics g)
        //{
        //    SizeF sizeF = g.MeasureString(this.ConditionText, detailFont);

        //    g.DrawString(this.ConditionText,
        //        detailFont,
        //        Brushes.Black,
        //        (this.paperWidth - sizeF.Width) / 2,
        //        drawYPoint);

        //    return sizeF.Height;
        //}

        //protected virtual void DrawReportPage(Graphics g, PrintPageEventArgs e)
        //{
        //    e.Graphics.DrawString("Report Viewer Base Class - Page " + this.page.ToString(),
        //        new System.Drawing.Font("Arial", 20),
        //        System.Drawing.Brushes.Black,
        //        e.MarginBounds.Left,
        //        e.MarginBounds.Top);

        //    e.HasMorePages = false;
        //}

        //protected virtual bool ShowCondition()
        //{
        //    return false;
        //}

        //protected virtual bool StartProcess()
        //{
        //    return false;
        //}

        //protected virtual void RenderReport()
        //{

        //    PrintPreviewDialog previewReport = new PrintPreviewDialog();

        //    previewReport.Document = this.reportDocument;
        //    (previewReport as Form).WindowState = FormWindowState.Maximized;
        //    previewReport.ShowDialog();
        //}

        //public void StartReport()
        //{
        //    bool isProcess = this.ShowCondition();

        //    if (!isProcess)
        //    {
        //        return;
        //    }

        //    bool processSuccess = this.StartProcess();
        //    if (processSuccess)
        //    {
        //        this.RenderReport();
        //    }
        //}
    }
}
