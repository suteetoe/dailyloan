namespace DailyLoan.Setup.Holiday
{
    partial class HolidayControl_old
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._searchResultGrid = new SMLControl._myGrid();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this._goFirstPageButton = new System.Windows.Forms.ToolStripButton();
            this._prevPageButton = new System.Windows.Forms.ToolStripButton();
            this._nextPageButton = new System.Windows.Forms.ToolStripButton();
            this._goLastPageButton = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._addButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._saveButton = new System.Windows.Forms.ToolStripButton();
            this._cancelButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel1
            // 
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.Size = new System.Drawing.Size(1052, 50);
            this.titlePanel1.TabIndex = 0;
            this.titlePanel1.Title = "กำหนดวันหยุด";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "ปี :";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(44, 6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(450, 22);
            this.comboBox1.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 50);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._searchResultGrid);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(1052, 810);
            this.splitContainer1.SplitterDistance = 505;
            this.splitContainer1.TabIndex = 4;
            // 
            // _searchResultGrid
            // 
            this._searchResultGrid._extraWordShow = true;
            this._searchResultGrid._selectRow = -1;
            this._searchResultGrid.AllowImportDataToGrid = true;
            this._searchResultGrid.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._searchResultGrid.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._searchResultGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this._searchResultGrid.Font = new System.Drawing.Font("Tahoma", 9F);
            this._searchResultGrid.Location = new System.Drawing.Point(3, 38);
            this._searchResultGrid.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this._searchResultGrid.Name = "_searchResultGrid";
            this._searchResultGrid.Size = new System.Drawing.Size(497, 734);
            this._searchResultGrid.TabIndex = 5;
            this._searchResultGrid.TabStop = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._goFirstPageButton,
            this._prevPageButton,
            this._nextPageButton,
            this._goLastPageButton});
            this.toolStrip2.Location = new System.Drawing.Point(3, 772);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(497, 33);
            this.toolStrip2.TabIndex = 6;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // _goFirstPageButton
            // 
            this._goFirstPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._goFirstPageButton.Image = global::DailyLoan.Properties.Resources.navigate_left_twin_16;
            this._goFirstPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._goFirstPageButton.Name = "_goFirstPageButton";
            this._goFirstPageButton.Size = new System.Drawing.Size(23, 30);
            this._goFirstPageButton.Text = "toolStripButton1";
            // 
            // _prevPageButton
            // 
            this._prevPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._prevPageButton.Image = global::DailyLoan.Properties.Resources.navigate_left_16;
            this._prevPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._prevPageButton.Name = "_prevPageButton";
            this._prevPageButton.Size = new System.Drawing.Size(23, 30);
            this._prevPageButton.Text = "toolStripButton2";
            // 
            // _nextPageButton
            // 
            this._nextPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._nextPageButton.Image = global::DailyLoan.Properties.Resources.navigate_right_16;
            this._nextPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._nextPageButton.Name = "_nextPageButton";
            this._nextPageButton.Size = new System.Drawing.Size(23, 30);
            this._nextPageButton.Text = "toolStripButton3";
            // 
            // _goLastPageButton
            // 
            this._goLastPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._goLastPageButton.Image = global::DailyLoan.Properties.Resources.navigate_right_twin_16;
            this._goLastPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._goLastPageButton.Name = "_goLastPageButton";
            this._goLastPageButton.Size = new System.Drawing.Size(23, 30);
            this._goLastPageButton.Text = "toolStripButton4";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 35);
            this.panel1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._addButton,
            this.toolStripSeparator1,
            this._saveButton,
            this._cancelButton});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(535, 35);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _addButton
            // 
            this._addButton.Image = global::DailyLoan.Properties.Resources.add;
            this._addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._addButton.Name = "_addButton";
            this._addButton.Size = new System.Drawing.Size(45, 32);
            this._addButton.Text = "เพิ่ม";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // _saveButton
            // 
            this._saveButton.Image = global::DailyLoan.Properties.Resources.disk_blue;
            this._saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(55, 32);
            this._saveButton.Text = "บันทึก";
            // 
            // _cancelButton
            // 
            this._cancelButton.Image = global::DailyLoan.Properties.Resources.delete;
            this._cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(56, 32);
            this._cancelButton.Text = "ยกเลิก";
            // 
            // HolidayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.titlePanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "HolidayControl";
            this.Size = new System.Drawing.Size(1052, 860);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.TitlePanel titlePanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _saveButton;
        public SMLControl._myGrid _searchResultGrid;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton _goFirstPageButton;
        private System.Windows.Forms.ToolStripButton _prevPageButton;
        private System.Windows.Forms.ToolStripButton _nextPageButton;
        private System.Windows.Forms.ToolStripButton _goLastPageButton;
        private System.Windows.Forms.ToolStripButton _addButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _cancelButton;
    }
}
