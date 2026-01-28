namespace DailyLoan.Control
{
    partial class SearchDataControl
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
            this._searchResultGrid = new SMLControl._myGrid();
            this.label1 = new System.Windows.Forms.Label();
            this._textSearchTextbox = new System.Windows.Forms.TextBox();
            this._buttonSearch = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._goFirstPageButton = new System.Windows.Forms.ToolStripButton();
            this._prevPageButton = new System.Windows.Forms.ToolStripButton();
            this._nextPageButton = new System.Windows.Forms.ToolStripButton();
            this._goLastPageButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._recordCountLabel = new System.Windows.Forms.ToolStripLabel();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this._searchResultGrid.Location = new System.Drawing.Point(0, 36);
            this._searchResultGrid.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this._searchResultGrid.Name = "_searchResultGrid";
            this._searchResultGrid.Size = new System.Drawing.Size(650, 487);
            this._searchResultGrid.TabIndex = 0;
            this._searchResultGrid.TabStop = false;
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
            // _textSearchTextbox
            // 
            this._textSearchTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._textSearchTextbox.Location = new System.Drawing.Point(63, 7);
            this._textSearchTextbox.Margin = new System.Windows.Forms.Padding(0, 5, 3, 3);
            this._textSearchTextbox.Name = "_textSearchTextbox";
            this._textSearchTextbox.Size = new System.Drawing.Size(492, 22);
            this._textSearchTextbox.TabIndex = 1;
            // 
            // _buttonSearch
            // 
            this._buttonSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonSearch.Location = new System.Drawing.Point(560, 6);
            this._buttonSearch.Margin = new System.Windows.Forms.Padding(0, 3, 3, 3);
            this._buttonSearch.Name = "_buttonSearch";
            this._buttonSearch.Size = new System.Drawing.Size(87, 25);
            this._buttonSearch.TabIndex = 2;
            this._buttonSearch.Text = "ค้นหา";
            this._buttonSearch.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._buttonSearch);
            this.panel1.Controls.Add(this._textSearchTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(650, 36);
            this.panel1.TabIndex = 2;
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 523);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(650, 33);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _goFirstPageButton
            // 
            this._goFirstPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._goFirstPageButton.Image = global::DailyLoan.Properties.Resources.navigate_left_twin_16;
            this._goFirstPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._goFirstPageButton.Name = "_goFirstPageButton";
            this._goFirstPageButton.Size = new System.Drawing.Size(23, 30);
            this._goFirstPageButton.Text = "หน้าแรก";
            this._goFirstPageButton.Click += new System.EventHandler(this._goFirstPageButton_Click);
            // 
            // _prevPageButton
            // 
            this._prevPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._prevPageButton.Image = global::DailyLoan.Properties.Resources.navigate_left_16;
            this._prevPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._prevPageButton.Name = "_prevPageButton";
            this._prevPageButton.Size = new System.Drawing.Size(23, 30);
            this._prevPageButton.Text = "หน้าก่อนหน้า";
            this._prevPageButton.Click += new System.EventHandler(this._prevPageButton_Click);
            // 
            // _nextPageButton
            // 
            this._nextPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._nextPageButton.Image = global::DailyLoan.Properties.Resources.navigate_right_16;
            this._nextPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._nextPageButton.Name = "_nextPageButton";
            this._nextPageButton.Size = new System.Drawing.Size(23, 30);
            this._nextPageButton.Text = "หน้าถัดไป";
            this._nextPageButton.Click += new System.EventHandler(this._nextPageButton_Click);
            // 
            // _goLastPageButton
            // 
            this._goLastPageButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this._goLastPageButton.Image = global::DailyLoan.Properties.Resources.navigate_right_twin_16;
            this._goLastPageButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._goLastPageButton.Name = "_goLastPageButton";
            this._goLastPageButton.Size = new System.Drawing.Size(23, 30);
            this._goLastPageButton.Text = "หน้าสุดท้าย";
            this._goLastPageButton.Click += new System.EventHandler(this._goLastPageButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 33);
            // 
            // _recordCountLabel
            // 
            this._recordCountLabel.Name = "_recordCountLabel";
            this._recordCountLabel.Size = new System.Drawing.Size(41, 30);
            this._recordCountLabel.Text = "0 (0/0)";
            // 
            // SearchDataControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._searchResultGrid);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "SearchDataControl";
            this.Size = new System.Drawing.Size(650, 556);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button _buttonSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _goFirstPageButton;
        private System.Windows.Forms.ToolStripButton _prevPageButton;
        private System.Windows.Forms.ToolStripButton _nextPageButton;
        private System.Windows.Forms.ToolStripButton _goLastPageButton;
        public SMLControl._myGrid _searchResultGrid;
        public System.Windows.Forms.TextBox _textSearchTextbox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel _recordCountLabel;
    }
}
