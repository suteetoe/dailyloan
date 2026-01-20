namespace DailyLoan.Loan
{
    partial class PayContractForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this._payButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._payAmountTextbox = new SMLControl._myNumberBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._payPeriodGrid1 = new DailyLoan.Loan._payPeriodGrid();
            this.panel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "จำนวนเงิน";
            // 
            // _payButton
            // 
            this._payButton.BackColor = System.Drawing.Color.LightGreen;
            this._payButton.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._payButton.Location = new System.Drawing.Point(444, 3);
            this._payButton.Name = "_payButton";
            this._payButton.Size = new System.Drawing.Size(137, 35);
            this._payButton.TabIndex = 2;
            this._payButton.Text = "ชำระเงิน";
            this._payButton.UseVisualStyleBackColor = false;
            this._payButton.Click += new System.EventHandler(this._payButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._payAmountTextbox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 496);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 103);
            this.panel1.TabIndex = 4;
            // 
            // _payAmountTextbox
            // 
            this._payAmountTextbox._column = 0;
            this._payAmountTextbox._default_color = System.Drawing.Color.Black;
            this._payAmountTextbox._defaultBackGround = System.Drawing.Color.White;
            this._payAmountTextbox._double = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._payAmountTextbox._emtry = true;
            this._payAmountTextbox._enterToTab = true;
            this._payAmountTextbox._format = "";
            this._payAmountTextbox._hiddenNumberValue = false;
            this._payAmountTextbox._icon = false;
            this._payAmountTextbox._iconNumber = 1;
            this._payAmountTextbox._isChange = true;
            this._payAmountTextbox._isGetData = false;
            this._payAmountTextbox._isQuery = true;
            this._payAmountTextbox._isSearch = false;
            this._payAmountTextbox._isTime = false;
            this._payAmountTextbox._labelName = "";
            this._payAmountTextbox._maxColumn = 0;
            this._payAmountTextbox._maxValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._payAmountTextbox._minValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._payAmountTextbox._name = null;
            this._payAmountTextbox._point = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this._payAmountTextbox._row = 0;
            this._payAmountTextbox._rowCount = 0;
            this._payAmountTextbox._textFirst = "";
            this._payAmountTextbox._textLast = "";
            this._payAmountTextbox._textSecond = "";
            this._payAmountTextbox._upperCase = false;
            this._payAmountTextbox.BackColor = System.Drawing.Color.Transparent;
            this._payAmountTextbox.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold);
            this._payAmountTextbox.IsUpperCase = false;
            this._payAmountTextbox.Location = new System.Drawing.Point(12, 47);
            this._payAmountTextbox.Margin = new System.Windows.Forms.Padding(0);
            this._payAmountTextbox.MaxLength = 0;
            this._payAmountTextbox.Name = "_payAmountTextbox";
            this._payAmountTextbox.ShowIcon = false;
            this._payAmountTextbox.Size = new System.Drawing.Size(563, 46);
            this._payAmountTextbox.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._payButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 599);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(584, 44);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // _payPeriodGrid1
            // 
            this._payPeriodGrid1._extraWordShow = true;
            this._payPeriodGrid1._selectRow = -1;
            this._payPeriodGrid1.AllowImportDataToGrid = true;
            this._payPeriodGrid1.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._payPeriodGrid1.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._payPeriodGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._payPeriodGrid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this._payPeriodGrid1.IsEdit = false;
            this._payPeriodGrid1.Location = new System.Drawing.Point(0, 0);
            this._payPeriodGrid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._payPeriodGrid1.Name = "_payPeriodGrid1";
            this._payPeriodGrid1.ShowTotal = true;
            this._payPeriodGrid1.Size = new System.Drawing.Size(584, 496);
            this._payPeriodGrid1.TabIndex = 6;
            this._payPeriodGrid1.TabStop = false;
            // 
            // PayContractForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 643);
            this.Controls.Add(this._payPeriodGrid1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "PayContractForm";
            this.Text = "ชำระเงิน";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button _payButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private _payPeriodGrid _payPeriodGrid1;
        private SMLControl._myNumberBox _payAmountTextbox;
    }
}