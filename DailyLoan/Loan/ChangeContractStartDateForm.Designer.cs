namespace DailyLoan.Loan
{
    partial class ChangeContractStartDateForm
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
            this._changeContractStartDateScreenTop1 = new DailyLoan.Loan._changeContractStartDateScreenTop();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this._processButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._changeContractStartDateGrid1 = new DailyLoan.Loan._changeContractStartDateGrid();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _changeContractStartDateScreenTop1
            // 
            this._changeContractStartDateScreenTop1._isChange = false;
            this._changeContractStartDateScreenTop1.BackColor = System.Drawing.Color.Transparent;
            this._changeContractStartDateScreenTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this._changeContractStartDateScreenTop1.Location = new System.Drawing.Point(0, 0);
            this._changeContractStartDateScreenTop1.Name = "_changeContractStartDateScreenTop1";
            this._changeContractStartDateScreenTop1.ReadOnly = false;
            this._changeContractStartDateScreenTop1.Size = new System.Drawing.Size(547, 70);
            this._changeContractStartDateScreenTop1.TabIndex = 0;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this._processButton);
            this.flowLayoutPanel2.Controls.Add(this._cancelButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 447);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(547, 34);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // _processButton
            // 
            this._processButton.Image = global::DailyLoan.Properties.Resources.flash;
            this._processButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._processButton.Location = new System.Drawing.Point(406, 3);
            this._processButton.Name = "_processButton";
            this._processButton.Size = new System.Drawing.Size(138, 29);
            this._processButton.TabIndex = 0;
            this._processButton.Text = "บันทึก";
            this._processButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._processButton.UseVisualStyleBackColor = true;
            this._processButton.Click += new System.EventHandler(this._processButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this._cancelButton.Image = global::DailyLoan.Properties.Resources.delete2;
            this._cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._cancelButton.Location = new System.Drawing.Point(271, 3);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(129, 29);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "ยกเลิก";
            this._cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _changeContractStartDateGrid1
            // 
            this._changeContractStartDateGrid1._extraWordShow = true;
            this._changeContractStartDateGrid1._selectRow = -1;
            this._changeContractStartDateGrid1.AllowImportDataToGrid = true;
            this._changeContractStartDateGrid1.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._changeContractStartDateGrid1.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._changeContractStartDateGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._changeContractStartDateGrid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this._changeContractStartDateGrid1.IsEdit = false;
            this._changeContractStartDateGrid1.Location = new System.Drawing.Point(0, 70);
            this._changeContractStartDateGrid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._changeContractStartDateGrid1.Name = "_changeContractStartDateGrid1";
            this._changeContractStartDateGrid1.Size = new System.Drawing.Size(547, 377);
            this._changeContractStartDateGrid1.TabIndex = 4;
            this._changeContractStartDateGrid1.TabStop = false;
            // 
            // ChangeContractStartDateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 481);
            this.Controls.Add(this._changeContractStartDateGrid1);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this._changeContractStartDateScreenTop1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChangeContractStartDateForm";
            this.Text = "ChangeContractStartDateForm";
            this.flowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private _changeContractStartDateScreenTop _changeContractStartDateScreenTop1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button _processButton;
        private System.Windows.Forms.Button _cancelButton;
        private _changeContractStartDateGrid _changeContractStartDateGrid1;
    }
}