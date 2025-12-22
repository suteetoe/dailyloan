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
            this._goFirstPageButton = new System.Windows.Forms.ToolStripButton();
            this._nextPageButton = new System.Windows.Forms.ToolStripButton();
            this._dataListGrid = new SMLControl._myGrid();
            this._prevPageButton = new System.Windows.Forms.ToolStripButton();
            this._buttonSearch = new System.Windows.Forms.Button();
            this._goLastPageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._textSearchTextbox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // _nextPageButton
            // 
            this._nextPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._nextPageButton.Image = global::DailyLoan.Properties.Resources.navigate_right_16;
            this._nextPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._nextPageButton.Name = "_nextPageButton";
            this._nextPageButton.Size = new System.Drawing.Size(23, 30);
            this._nextPageButton.Text = "toolStripButton3";
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
            this._dataListGrid.Location = new System.Drawing.Point(0, 36);
            this._dataListGrid.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this._dataListGrid.Name = "_dataListGrid";
            this._dataListGrid.Size = new System.Drawing.Size(675, 509);
            this._dataListGrid.TabIndex = 4;
            this._dataListGrid.TabStop = false;
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
            // _buttonSearch
            // 
            this._buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSearch.Location = new System.Drawing.Point(575, 5);
            this._buttonSearch.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Size = new System.Drawing.Size(87, 25);
            this._buttonSearch.TabIndex = 2;
            this._buttonSearch.Text = "ค้นหา";
            this._buttonSearch.UseVisualStyleBackColor = true;
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
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 545);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(675, 33);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _textSearchTextbox
            // 
            this._textSearchTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textSearchTextbox.Location = new System.Drawing.Point(63, 7);
            this._textSearchTextbox.Margin = new System.Windows.Forms.Padding(0, 5, 3, 3);
            this._textSearchTextbox.Name = "_textSearchTextbox";
            this._textSearchTextbox.Size = new System.Drawing.Size(509, 20);
            this._textSearchTextbox.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._buttonSearch);
            this.panel1.Controls.Add(this._textSearchTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(675, 36);
            this.panel1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "ข้อความ :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // ManageDataList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._dataListGrid);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ManageDataList";
            this.Size = new System.Drawing.Size(675, 578);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
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
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}
