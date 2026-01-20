namespace DailyLoan.Loan
{
    partial class LoanControl
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
            this._loanScreenTop1 = new DailyLoan.Loan._loanScreenTop();
            this.titlePanel1 = new DailyLoan.Control.TitlePanel();
            this.ToolStrip1 = new System.Windows.Forms.ToolStrip();
            this._searchContractButton = new System.Windows.Forms.ToolStripButton();
            this._newContractButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._payButton = new System.Windows.Forms.ToolStripButton();
            this._saveContractButton = new System.Windows.Forms.ToolStripButton();
            this._discardButton = new System.Windows.Forms.ToolStripButton();
            this._paymentPeriodGrid1 = new DailyLoan.Loan._contractPeriodGrid();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._labelTotalBalance = new System.Windows.Forms.Label();
            this._labelTotalPaid = new System.Windows.Forms.Label();
            this._labelTotalLoan = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ToolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _loanScreenTop1
            // 
            this._loanScreenTop1._isChange = false;
            this._loanScreenTop1.BackColor = System.Drawing.Color.Transparent;
            this._loanScreenTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this._loanScreenTop1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._loanScreenTop1.Location = new System.Drawing.Point(0, 0);
            this._loanScreenTop1.LockScreen = false;
            this._loanScreenTop1.Name = "_loanScreenTop1";
            this._loanScreenTop1.Size = new System.Drawing.Size(608, 400);
            this._loanScreenTop1.TabIndex = 4;
            // 
            // titlePanel1
            // 
            this.titlePanel1.BackColor = System.Drawing.Color.AliceBlue;
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel1.ForeColor = System.Drawing.Color.DarkBlue;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.Size = new System.Drawing.Size(1024, 48);
            this.titlePanel1.TabIndex = 7;
            this.titlePanel1.Title = "สัญญากู้เงิน";
            // 
            // ToolStrip1
            // 
            this.ToolStrip1.AutoSize = false;
            this.ToolStrip1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStrip1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._searchContractButton,
            this._newContractButton,
            this.toolStripSeparator1,
            this._payButton,
            this._saveContractButton,
            this._discardButton});
            this.ToolStrip1.Location = new System.Drawing.Point(0, 615);
            this.ToolStrip1.Name = "ToolStrip1";
            this.ToolStrip1.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.ToolStrip1.Size = new System.Drawing.Size(1024, 89);
            this.ToolStrip1.TabIndex = 8;
            this.ToolStrip1.Text = "toolStrip1";
            // 
            // _searchContractButton
            // 
            this._searchContractButton.AutoSize = false;
            this._searchContractButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._searchContractButton.Image = global::DailyLoan.Properties.Resources.document_view_32;
            this._searchContractButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._searchContractButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._searchContractButton.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this._searchContractButton.Name = "_searchContractButton";
            this._searchContractButton.Size = new System.Drawing.Size(87, 87);
            this._searchContractButton.Text = "ค้นหา";
            this._searchContractButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._searchContractButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._searchContractButton.Click += new System.EventHandler(this._searchContractButton_Click);
            // 
            // _newContractButton
            // 
            this._newContractButton.AutoSize = false;
            this._newContractButton.Image = global::DailyLoan.Properties.Resources.add_32;
            this._newContractButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._newContractButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._newContractButton.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this._newContractButton.Name = "_newContractButton";
            this._newContractButton.Size = new System.Drawing.Size(87, 87);
            this._newContractButton.Text = "สร้าง";
            this._newContractButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._newContractButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._newContractButton.Click += new System.EventHandler(this._newContractButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 89);
            // 
            // _payButton
            // 
            this._payButton.AutoSize = false;
            this._payButton.Image = global::DailyLoan.Properties.Resources.money2_32;
            this._payButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._payButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._payButton.Margin = new System.Windows.Forms.Padding(10, 1, 10, 2);
            this._payButton.Name = "_payButton";
            this._payButton.Size = new System.Drawing.Size(97, 97);
            this._payButton.Text = "ชำระเงิน";
            this._payButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._payButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._payButton.Click += new System.EventHandler(this._payButton_Click);
            // 
            // _saveContractButton
            // 
            this._saveContractButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._saveContractButton.AutoSize = false;
            this._saveContractButton.Image = global::DailyLoan.Properties.Resources.disk_blue_32;
            this._saveContractButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._saveContractButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveContractButton.Name = "_saveContractButton";
            this._saveContractButton.Size = new System.Drawing.Size(87, 87);
            this._saveContractButton.Text = "บันทึก";
            this._saveContractButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._saveContractButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._saveContractButton.ToolTipText = "บันทึก";
            this._saveContractButton.Click += new System.EventHandler(this._saveContractButton_Click);
            // 
            // _discardButton
            // 
            this._discardButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._discardButton.AutoSize = false;
            this._discardButton.Image = global::DailyLoan.Properties.Resources.delete2_32;
            this._discardButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._discardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._discardButton.Name = "_discardButton";
            this._discardButton.Size = new System.Drawing.Size(87, 87);
            this._discardButton.Text = "ยกเลิก";
            this._discardButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._discardButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._discardButton.ToolTipText = "ยกเลิก";
            this._discardButton.Click += new System.EventHandler(this._discardButton_Click);
            // 
            // _paymentPeriodGrid1
            // 
            this._paymentPeriodGrid1._extraWordShow = true;
            this._paymentPeriodGrid1._selectRow = -1;
            this._paymentPeriodGrid1.AllowImportDataToGrid = true;
            this._paymentPeriodGrid1.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._paymentPeriodGrid1.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._paymentPeriodGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._paymentPeriodGrid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this._paymentPeriodGrid1.IsEdit = false;
            this._paymentPeriodGrid1.Location = new System.Drawing.Point(5, 0);
            this._paymentPeriodGrid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._paymentPeriodGrid1.Name = "_paymentPeriodGrid1";
            this._paymentPeriodGrid1.ShowTotal = true;
            this._paymentPeriodGrid1.Size = new System.Drawing.Size(382, 547);
            this._paymentPeriodGrid1.TabIndex = 5;
            this._paymentPeriodGrid1.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(10, 10);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this._paymentPeriodGrid1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.splitContainer1.Size = new System.Drawing.Size(1004, 547);
            this.splitContainer1.SplitterDistance = 613;
            this.splitContainer1.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this._loanScreenTop1);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.panel3.Size = new System.Drawing.Size(613, 547);
            this.panel3.TabIndex = 7;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._labelTotalBalance);
            this.panel2.Controls.Add(this._labelTotalPaid);
            this.panel2.Controls.Add(this._labelTotalLoan);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(608, 117);
            this.panel2.TabIndex = 6;
            // 
            // _labelTotalBalance
            // 
            this._labelTotalBalance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._labelTotalBalance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._labelTotalBalance.ForeColor = System.Drawing.Color.Red;
            this._labelTotalBalance.Location = new System.Drawing.Point(404, 80);
            this._labelTotalBalance.Name = "_labelTotalBalance";
            this._labelTotalBalance.Size = new System.Drawing.Size(182, 19);
            this._labelTotalBalance.TabIndex = 5;
            this._labelTotalBalance.Text = "0.00";
            this._labelTotalBalance.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _labelTotalPaid
            // 
            this._labelTotalPaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._labelTotalPaid.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._labelTotalPaid.ForeColor = System.Drawing.Color.Green;
            this._labelTotalPaid.Location = new System.Drawing.Point(404, 47);
            this._labelTotalPaid.Name = "_labelTotalPaid";
            this._labelTotalPaid.Size = new System.Drawing.Size(182, 19);
            this._labelTotalPaid.TabIndex = 4;
            this._labelTotalPaid.Text = "0.00";
            this._labelTotalPaid.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _labelTotalLoan
            // 
            this._labelTotalLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._labelTotalLoan.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._labelTotalLoan.ForeColor = System.Drawing.Color.Blue;
            this._labelTotalLoan.Location = new System.Drawing.Point(404, 18);
            this._labelTotalLoan.Name = "_labelTotalLoan";
            this._labelTotalLoan.Size = new System.Drawing.Size(182, 19);
            this._labelTotalLoan.TabIndex = 3;
            this._labelTotalLoan.Text = "9,999,999,999.00";
            this._labelTotalLoan.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(98, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 19);
            this.label3.TabIndex = 2;
            this.label3.Text = "ยอดค้างชำระ :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(86, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "ยอดที่ชำระแล้ว :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(3, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "รวมยอดที่ต้องชำระทั้งหมด :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(1024, 567);
            this.panel1.TabIndex = 9;
            // 
            // LoanControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlePanel1);
            this.Controls.Add(this.ToolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "LoanControl";
            this.Size = new System.Drawing.Size(1024, 704);
            this.ToolStrip1.ResumeLayout(false);
            this.ToolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private _loanScreenTop _loanScreenTop1;
        private Control.TitlePanel titlePanel1;
        private System.Windows.Forms.ToolStrip ToolStrip1;
        private System.Windows.Forms.ToolStripButton _searchContractButton;
        private System.Windows.Forms.ToolStripButton _newContractButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton _saveContractButton;
        private _contractPeriodGrid _paymentPeriodGrid1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripButton _payButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label _labelTotalLoan;
        private System.Windows.Forms.Label _labelTotalBalance;
        private System.Windows.Forms.Label _labelTotalPaid;
        private System.Windows.Forms.ToolStripButton _discardButton;
    }
}
