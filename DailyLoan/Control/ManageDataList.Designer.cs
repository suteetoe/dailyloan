namespace DailyLoan.Control
{
    partial class ManageDataList
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
            this.components = new System.ComponentModel.Container();
            this._goFirstPageButton = new System.Windows.Forms.ToolStripButton();
            this._nextPageButton = new System.Windows.Forms.ToolStripButton();
            this._dataListGrid = new SMLControl._myGrid();
            this._prevPageButton = new System.Windows.Forms.ToolStripButton();
            this._buttonSearch = new System.Windows.Forms.Button();
            this._goLastPageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._recordCountLabel = new System.Windows.Forms.ToolStripLabel();
            this._textSearchTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this._addButton = new System.Windows.Forms.ToolStripButton();
            this._deleteButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._saveButton = new System.Windows.Forms.ToolStripButton();
            this._cancelButton = new System.Windows.Forms.ToolStripButton();
            this.titlePanel = new DailyLoan.Control.TitlePanel();
            this._dataLoadingTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _goFirstPageButton
            // 
            this._goFirstPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._goFirstPageButton.Image = global::DailyLoan.Properties.Resources.navigate_left_twin_16;
            this._goFirstPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._goFirstPageButton.Name = "_goFirstPageButton";
            this._goFirstPageButton.Size = new System.Drawing.Size(23, 33);
            this._goFirstPageButton.Text = "หน้าแรก";
            this._goFirstPageButton.Click += new System.EventHandler(this._goFirstPageButton_Click);
            // 
            // _nextPageButton
            // 
            this._nextPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._nextPageButton.Image = global::DailyLoan.Properties.Resources.navigate_right_16;
            this._nextPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._nextPageButton.Name = "_nextPageButton";
            this._nextPageButton.Size = new System.Drawing.Size(23, 33);
            this._nextPageButton.Text = "หน้าถัดไป";
            this._nextPageButton.Click += new System.EventHandler(this._nextPageButton_Click);
            // 
            // _dataListGrid
            // 
            this._dataListGrid._extraWordShow = true;
            this._dataListGrid._selectRow = -1;
            this._dataListGrid.AllowImportDataToGrid = true;
            this._dataListGrid.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._dataListGrid.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._dataListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataListGrid.Font = new System.Drawing.Font("Tahoma", 9F);
            this._dataListGrid.IsEdit = false;
            this._dataListGrid.Location = new System.Drawing.Point(0, 0);
            this._dataListGrid.Margin = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this._dataListGrid.Name = "_dataListGrid";
            this._dataListGrid.Size = new System.Drawing.Size(407, 493);
            this._dataListGrid.TabIndex = 4;
            this._dataListGrid.TabStop = false;
            // 
            // _prevPageButton
            // 
            this._prevPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._prevPageButton.Image = global::DailyLoan.Properties.Resources.navigate_left_16;
            this._prevPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._prevPageButton.Name = "_prevPageButton";
            this._prevPageButton.Size = new System.Drawing.Size(23, 33);
            this._prevPageButton.Text = "หน้าก่อนหน้า";
            this._prevPageButton.Click += new System.EventHandler(this._prevPageButton_Click);
            // 
            // _buttonSearch
            // 
            this._buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSearch.Location = new System.Drawing.Point(291, 5);
            this._buttonSearch.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Size = new System.Drawing.Size(101, 27);
            this._buttonSearch.TabIndex = 2;
            this._buttonSearch.Text = "ค้นหา";
            this._buttonSearch.UseVisualStyleBackColor = true;
            this._buttonSearch.Click += new System.EventHandler(this._buttonSearch_Click);
            // 
            // _goLastPageButton
            // 
            this._goLastPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._goLastPageButton.Image = global::DailyLoan.Properties.Resources.navigate_right_twin_16;
            this._goLastPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._goLastPageButton.Name = "_goLastPageButton";
            this._goLastPageButton.Size = new System.Drawing.Size(23, 33);
            this._goLastPageButton.Text = "หน้าสุดท้าย";
            this._goLastPageButton.Click += new System.EventHandler(this._goLastPageButton_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._goFirstPageButton,
            this._prevPageButton,
            this._nextPageButton,
            this._goLastPageButton,
            this.toolStripSeparator1,
            this._recordCountLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 493);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(407, 36);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 36);
            // 
            // _recordCountLabel
            // 
            this._recordCountLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this._recordCountLabel.Name = "_recordCountLabel";
            this._recordCountLabel.Size = new System.Drawing.Size(41, 33);
            this._recordCountLabel.Text = "0 (0/0)";
            // 
            // _textSearchTextbox
            // 
            this._textSearchTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textSearchTextbox.Location = new System.Drawing.Point(73, 8);
            this._textSearchTextbox.Margin = new System.Windows.Forms.Padding(0, 5, 3, 3);
            this._textSearchTextbox.Name = "_textSearchTextbox";
            this._textSearchTextbox.Size = new System.Drawing.Size(213, 22);
            this._textSearchTextbox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._buttonSearch);
            this.panel1.Controls.Add(this._textSearchTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 39);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "ข้อความ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(787, 576);
            this.splitContainer1.SplitterDistance = 415;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._dataListGrid);
            this.panel3.Controls.Add(this.toolStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 42);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(407, 529);
            this.panel3.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 42);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(359, 529);
            this.panel2.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addButton,
            this._deleteButton,
            this.toolStripSeparator2,
            this._saveButton,
            this._cancelButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip2.Size = new System.Drawing.Size(359, 39);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // _addButton
            // 
            this._addButton.Image = global::DailyLoan.Properties.Resources.add;
            this._addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(45, 36);
            this._addButton.Text = "เพิ่ม";
            this._addButton.Click += new System.EventHandler(this._addButton_Click);
            // 
            // _deleteButton
            // 
            this._deleteButton.Image = global::DailyLoan.Properties.Resources.delete;
            this._deleteButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._deleteButton.Name = "_deleteButton";
            this._deleteButton.Size = new System.Drawing.Size(40, 36);
            this._deleteButton.Text = "ลบ";
            this._deleteButton.Click += new System.EventHandler(this._deleteButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // _saveButton
            // 
            this._saveButton.Image = global::DailyLoan.Properties.Resources.disk_blue;
            this._saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(55, 36);
            this._saveButton.Text = "บันทึก";
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Image = global::DailyLoan.Properties.Resources.delete2;
            this._cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(56, 36);
            this._cancelButton.Text = "ยกเลิก";
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // titlePanel
            // 
            this.titlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel.Location = new System.Drawing.Point(0, 0);
            this.titlePanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(787, 46);
            this.titlePanel.TabIndex = 0;
            this.titlePanel.Title = "Title";
            // 
            // _dataLoadingTimer
            // 
            this._dataLoadingTimer.Interval = 1000;
            this._dataLoadingTimer.Tick += new System.EventHandler(this._dataLoadingTimer_Tick);
            // 
            // ManageDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.titlePanel);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ManageDataList";
            this.Size = new System.Drawing.Size(787, 622);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripButton _goFirstPageButton;
        private System.Windows.Forms.ToolStripButton _nextPageButton;
        public SMLControl._myGrid _dataListGrid;
        private System.Windows.Forms.ToolStripButton _prevPageButton;
        private System.Windows.Forms.Button _buttonSearch;
        private System.Windows.Forms.ToolStripButton _goLastPageButton;
        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.TextBox _textSearchTextbox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        protected System.Windows.Forms.ToolStripButton _saveButton;
        private System.Windows.Forms.Panel panel3;
        protected TitlePanel titlePanel;
        public System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.ToolStripButton _addButton;
        private System.Windows.Forms.ToolStripLabel _recordCountLabel;
        protected System.Windows.Forms.Timer _dataLoadingTimer;
        protected System.Windows.Forms.ToolStripButton _cancelButton;
        protected System.Windows.Forms.ToolStripButton _deleteButton;
    }
}
