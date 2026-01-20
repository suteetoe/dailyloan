namespace DailyLoan.Daily
{
    partial class DailyControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titlePanel1 = new DailyLoan.Control.TitlePanel();
            this._dailyExportScreenTop = new DailyLoan.Daily._dailyScreenTop();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._processDailySheetButton = new System.Windows.Forms.ToolStripButton();
            this._exportDailyDataExcel = new System.Windows.Forms.ToolStripButton();
            this._dailyExportGrid = new DailyLoan.Daily._dailyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this._dailyPaymentGrid = new DailyLoan.Daily._dailyGrid();
            this._dailyImportScreenTop = new DailyLoan.Daily._dailyScreenTop();
            this.panel3 = new System.Windows.Forms.Panel();
            this._importFileNameLabel = new System.Windows.Forms.Label();
            this._processImportToolStrip = new System.Windows.Forms.ToolStrip();
            this._importDailySheetButton = new System.Windows.Forms.ToolStripButton();
            this._processPaymentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this._processImportToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel1
            // 
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.Size = new System.Drawing.Size(883, 48);
            this.titlePanel1.TabIndex = 3;
            this.titlePanel1.Title = "ใบรายวัน";
            // 
            // _dailyExportScreenTop
            // 
            this._dailyExportScreenTop._isChange = false;
            this._dailyExportScreenTop.BackColor = System.Drawing.Color.Transparent;
            this._dailyExportScreenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._dailyExportScreenTop.Location = new System.Drawing.Point(10, 10);
            this._dailyExportScreenTop.Name = "_dailyExportScreenTop";
            this._dailyExportScreenTop.Size = new System.Drawing.Size(738, 55);
            this._dailyExportScreenTop.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._processDailySheetButton,
            this._exportDailyDataExcel});
            this.toolStrip1.Location = new System.Drawing.Point(761, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 579);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _processDailySheetButton
            // 
            this._processDailySheetButton.AutoSize = false;
            this._processDailySheetButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this._processDailySheetButton.Image = global::DailyLoan.Properties.Resources.flash_32;
            this._processDailySheetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._processDailySheetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._processDailySheetButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this._processDailySheetButton.Name = "_processDailySheetButton";
            this._processDailySheetButton.Size = new System.Drawing.Size(97, 97);
            this._processDailySheetButton.Text = "ประมวลผล";
            this._processDailySheetButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._processDailySheetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._processDailySheetButton.Click += new System.EventHandler(this._processDailySheetButton_Click);
            // 
            // _exportDailyDataExcel
            // 
            this._exportDailyDataExcel.AutoSize = false;
            this._exportDailyDataExcel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this._exportDailyDataExcel.Image = global::DailyLoan.Properties.Resources.icons8_microsoft_excel_32;
            this._exportDailyDataExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._exportDailyDataExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exportDailyDataExcel.Margin = new System.Windows.Forms.Padding(0, 10, 0, 20);
            this._exportDailyDataExcel.Name = "_exportDailyDataExcel";
            this._exportDailyDataExcel.Size = new System.Drawing.Size(97, 97);
            this._exportDailyDataExcel.Text = "Export Excel";
            this._exportDailyDataExcel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._exportDailyDataExcel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exportDailyDataExcel.Click += new System.EventHandler(this._exportDailyDataExcel_Click);
            // 
            // _dailyExportGrid
            // 
            this._dailyExportGrid._extraWordShow = true;
            this._dailyExportGrid._selectRow = -1;
            this._dailyExportGrid.AllowImportDataToGrid = true;
            this._dailyExportGrid.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._dailyExportGrid.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._dailyExportGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dailyExportGrid.Font = new System.Drawing.Font("Tahoma", 9F);
            this._dailyExportGrid.IsEdit = false;
            this._dailyExportGrid.Location = new System.Drawing.Point(10, 65);
            this._dailyExportGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dailyExportGrid.Name = "_dailyExportGrid";
            this._dailyExportGrid.ShowTotal = true;
            this._dailyExportGrid.Size = new System.Drawing.Size(738, 504);
            this._dailyExportGrid.TabIndex = 6;
            this._dailyExportGrid.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._dailyExportGrid);
            this.panel1.Controls.Add(this._dailyExportScreenTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(758, 579);
            this.panel1.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 48);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(883, 612);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(875, 585);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ส่งออกข้อมูล";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this._processImportToolStrip);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(875, 585);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "นำเข้าข้อมูล";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._dailyPaymentGrid);
            this.panel2.Controls.Add(this._dailyImportScreenTop);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(758, 579);
            this.panel2.TabIndex = 9;
            // 
            // _dailyPaymentGrid
            // 
            this._dailyPaymentGrid._extraWordShow = true;
            this._dailyPaymentGrid._selectRow = -1;
            this._dailyPaymentGrid.AllowImportDataToGrid = true;
            this._dailyPaymentGrid.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._dailyPaymentGrid.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._dailyPaymentGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dailyPaymentGrid.Font = new System.Drawing.Font("Tahoma", 9F);
            this._dailyPaymentGrid.IsEdit = false;
            this._dailyPaymentGrid.Location = new System.Drawing.Point(10, 98);
            this._dailyPaymentGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dailyPaymentGrid.Name = "_dailyPaymentGrid";
            this._dailyPaymentGrid.ShowTotal = true;
            this._dailyPaymentGrid.Size = new System.Drawing.Size(738, 471);
            this._dailyPaymentGrid.TabIndex = 6;
            this._dailyPaymentGrid.TabStop = false;
            // 
            // _dailyImportScreenTop
            // 
            this._dailyImportScreenTop._isChange = false;
            this._dailyImportScreenTop.BackColor = System.Drawing.Color.Transparent;
            this._dailyImportScreenTop.Dock = System.Windows.Forms.DockStyle.Top;
            this._dailyImportScreenTop.Location = new System.Drawing.Point(10, 43);
            this._dailyImportScreenTop.Name = "_dailyImportScreenTop";
            this._dailyImportScreenTop.Size = new System.Drawing.Size(738, 55);
            this._dailyImportScreenTop.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._importFileNameLabel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(10, 10);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(738, 33);
            this.panel3.TabIndex = 7;
            // 
            // _importFileNameLabel
            // 
            this._importFileNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._importFileNameLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._importFileNameLabel.Location = new System.Drawing.Point(0, 0);
            this._importFileNameLabel.Name = "_importFileNameLabel";
            this._importFileNameLabel.Size = new System.Drawing.Size(738, 33);
            this._importFileNameLabel.TabIndex = 0;
            this._importFileNameLabel.Text = "File : ";
            this._importFileNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _processImportToolStrip
            // 
            this._processImportToolStrip.AutoSize = false;
            this._processImportToolStrip.Dock = System.Windows.Forms.DockStyle.Right;
            this._processImportToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this._processImportToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._importDailySheetButton,
            this._processPaymentButton});
            this._processImportToolStrip.Location = new System.Drawing.Point(761, 3);
            this._processImportToolStrip.Name = "_processImportToolStrip";
            this._processImportToolStrip.Size = new System.Drawing.Size(111, 579);
            this._processImportToolStrip.TabIndex = 6;
            this._processImportToolStrip.Text = "toolStrip3";
            // 
            // _importDailySheetButton
            // 
            this._importDailySheetButton.AutoSize = false;
            this._importDailySheetButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this._importDailySheetButton.ForeColor = System.Drawing.Color.Black;
            this._importDailySheetButton.Image = global::DailyLoan.Properties.Resources.document_into_32;
            this._importDailySheetButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._importDailySheetButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._importDailySheetButton.Margin = new System.Windows.Forms.Padding(0, 1, 0, 20);
            this._importDailySheetButton.Name = "_importDailySheetButton";
            this._importDailySheetButton.Size = new System.Drawing.Size(97, 97);
            this._importDailySheetButton.Text = "นำเข้าใบรายวัน";
            this._importDailySheetButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._importDailySheetButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._importDailySheetButton.Click += new System.EventHandler(this._importDailySheetButton_Click);
            // 
            // _processPaymentButton
            // 
            this._processPaymentButton.AutoSize = false;
            this._processPaymentButton.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this._processPaymentButton.Image = global::DailyLoan.Properties.Resources.notebook_preferences_32;
            this._processPaymentButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._processPaymentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._processPaymentButton.Margin = new System.Windows.Forms.Padding(0, 1, 0, 20);
            this._processPaymentButton.Name = "_processPaymentButton";
            this._processPaymentButton.Size = new System.Drawing.Size(97, 97);
            this._processPaymentButton.Text = "ปรับยอดชำระ";
            this._processPaymentButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._processPaymentButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._processPaymentButton.Click += new System.EventHandler(this._processPaymentButton_Click);
            // 
            // DailyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.titlePanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DailyControl";
            this.Size = new System.Drawing.Size(883, 660);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this._processImportToolStrip.ResumeLayout(false);
            this._processImportToolStrip.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private Control.TitlePanel titlePanel1;
        private _dailyScreenTop _dailyExportScreenTop;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _exportDailyDataExcel;
        private _dailyGrid _dailyExportGrid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip _processImportToolStrip;
        private System.Windows.Forms.ToolStripButton _importDailySheetButton;
        private System.Windows.Forms.ToolStripButton _processPaymentButton;
        private System.Windows.Forms.ToolStripButton _processDailySheetButton;
        private System.Windows.Forms.Panel panel2;
        private _dailyGrid _dailyPaymentGrid;
        private _dailyScreenTop _dailyImportScreenTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label _importFileNameLabel;
    }
}
