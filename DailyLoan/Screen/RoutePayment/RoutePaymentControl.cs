using DailyLoan.Control;
using DailyLoan.Data.Repository;
using DailyLoan.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.RoutePayment
{
    public class RoutePaymentControl : Control.ManageDataList
    {
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private _routePaymentDetailGrid _routePaymentDetailGrid1;
        private _routePaymentDetailScreen _routePaymentDetailScreen1;
        RoutePaymentRepository routePaymentRepository = new RoutePaymentRepository();
        ContractProcess contractProcess = new ContractProcess();

        public RoutePaymentControl()
        {
            InitializeComponent();
            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);
            this._dataListGrid.AddGridColumn(new SMLControl.GridDateColumn() { WidthPercent = 15, ColumnCode = "doc_date", ColumnName = "วันที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "doc_no", ColumnName = "เลขที่เอกสาร" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 20, ColumnCode = "route", ColumnName = "สาย", IsQuery = false });
            this._dataListGrid.AddGridColumn(new SMLControl.GridDecimalColumn() { WidthPercent = 15, ColumnCode = "total_route_amount", ColumnName = "จำนวนเงิน", Format = numberFormat });

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสสาย", ColumnCode = "mst_route.code", WidthPercent = 0, IsHide = true });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ชื่อสาย", ColumnCode = "mst_route.name_1", WidthPercent = 0, IsHide = true });

            this._dataListGrid._calcPersentWidthToScatter();
            this._dataListGrid.Invalidate();

            this._addButton.Visible = false;
            this._saveButton.Visible = false;
            this._cancelButton.Visible = false;

            bool visibleDeletebutton = false;
            if ((int)App.LoggedUser.Role > 0)
            {
                visibleDeletebutton = true;
            }

            this._deleteButton.Visible = visibleDeletebutton;
        }

        protected override void ClearScreen()
        {
            this._routePaymentDetailScreen1._clear();
            this._routePaymentDetailGrid1._clear();
        }

        protected override string LoadDataListQuery()
        {
            string filter = this.GetFilterCommand();

            string query =
                @"
SELECT doc_date, doc_no,(txn_route_payment.route_code || '~' || mst_route.name_1 )as route, total_route_amount 
, mst_route.code, mst_route.name_1

FROM txn_route_payment
join mst_route on mst_route.code = txn_route_payment.route_code " + 
                (filter.Length > 0 ? " WHERE " + filter : "");
            return query;
        }

        protected override string SortField()
        {
            return " order by doc_date ";
        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            string doc_no = selectedRow["doc_no"].ToString();

            var routePayment = routePaymentRepository.GetRoutePaymentByDocNo(doc_no);
            if (routePayment != null)
            {
                this._routePaymentDetailScreen1.LoadData(routePayment);
                this._routePaymentDetailGrid1.LoadRoutePayment(routePayment);
                return true;
            }

            return false;
        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                string doc_no = rowSelected["doc_no"];
                var payment = routePaymentRepository.GetRoutePaymentByDocNo(doc_no);
                if (payment == null)
                {
                    MessageBox.Show("ไม่พบข้อมูลที่ต้องการลบ", "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                routePaymentRepository.DeleteRoutePayment(payment.doc_no);

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (var item in payment.Details)
                {
                    contractProcess.StartProcessPayment(item.contract_no);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้\n" + ex.Message, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }

        private void InitializeComponent()
        {
            this._routePaymentDetailScreen1 = new DailyLoan.Screen.RoutePayment._routePaymentDetailScreen();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this._routePaymentDetailGrid1 = new DailyLoan.Screen.RoutePayment._routePaymentDetailGrid();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Title = "รายการชำระเงินสาย";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Controls.Add(this._routePaymentDetailScreen1);
            // 
            // _dataLoadingTimer
            // 
            this._dataLoadingTimer.Enabled = true;
            // 
            // _routePaymentDetailScreen1
            // 
            this._routePaymentDetailScreen1._isChange = false;
            this._routePaymentDetailScreen1.BackColor = System.Drawing.Color.Transparent;
            this._routePaymentDetailScreen1.Dock = System.Windows.Forms.DockStyle.Top;
            this._routePaymentDetailScreen1.Location = new System.Drawing.Point(0, 0);
            this._routePaymentDetailScreen1.Name = "_routePaymentDetailScreen1";
            this._routePaymentDetailScreen1.ReadOnly = false;
            this._routePaymentDetailScreen1.Size = new System.Drawing.Size(359, 52);
            this._routePaymentDetailScreen1.TabIndex = 8;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(359, 477);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this._routePaymentDetailGrid1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(351, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "รายละเอียด";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // _routePaymentDetailGrid1
            // 
            this._routePaymentDetailGrid1._extraWordShow = true;
            this._routePaymentDetailGrid1._selectRow = -1;
            this._routePaymentDetailGrid1.AllowImportDataToGrid = true;
            this._routePaymentDetailGrid1.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._routePaymentDetailGrid1.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._routePaymentDetailGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._routePaymentDetailGrid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this._routePaymentDetailGrid1.IsEdit = false;
            this._routePaymentDetailGrid1.Location = new System.Drawing.Point(3, 3);
            this._routePaymentDetailGrid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._routePaymentDetailGrid1.Name = "_routePaymentDetailGrid1";
            this._routePaymentDetailGrid1.ShowTotal = true;
            this._routePaymentDetailGrid1.Size = new System.Drawing.Size(345, 444);
            this._routePaymentDetailGrid1.TabIndex = 0;
            this._routePaymentDetailGrid1.TabStop = false;
            // 
            // RoutePaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "RoutePaymentControl";
            this.panel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
