namespace DailyLoan.Loan
{
    partial class ChangeContractRouteForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._processButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._changeContractRouteScreenTop1 = new DailyLoan.Loan._changeContractRouteScreenTop();
            this.titlePanel1 = new DailyLoan.Control.TitlePanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._processButton);
            this.flowLayoutPanel1.Controls.Add(this._cancelButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 138);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(455, 32);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // _processButton
            // 
            this._processButton.Image = global::DailyLoan.Properties.Resources.flash;
            this._processButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._processButton.Location = new System.Drawing.Point(334, 3);
            this._processButton.Name = "_processButton";
            this._processButton.Size = new System.Drawing.Size(118, 27);
            this._processButton.TabIndex = 0;
            this._processButton.Text = "ประมวลผล";
            this._processButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._processButton.UseVisualStyleBackColor = true;
            this._processButton.Click += new System.EventHandler(this._processButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this._cancelButton.Image = global::DailyLoan.Properties.Resources.delete2;
            this._cancelButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._cancelButton.Location = new System.Drawing.Point(217, 3);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(111, 27);
            this._cancelButton.TabIndex = 1;
            this._cancelButton.Text = "ยกเลิก";
            this._cancelButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._cancelButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // _changeContractRouteScreenTop1
            // 
            this._changeContractRouteScreenTop1._isChange = false;
            this._changeContractRouteScreenTop1.BackColor = System.Drawing.Color.Transparent;
            this._changeContractRouteScreenTop1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._changeContractRouteScreenTop1.Location = new System.Drawing.Point(10, 10);
            this._changeContractRouteScreenTop1.Name = "_changeContractRouteScreenTop1";
            this._changeContractRouteScreenTop1.ReadOnly = false;
            this._changeContractRouteScreenTop1.Size = new System.Drawing.Size(435, 72);
            this._changeContractRouteScreenTop1.TabIndex = 3;
            // 
            // titlePanel1
            // 
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.Size = new System.Drawing.Size(455, 46);
            this.titlePanel1.TabIndex = 4;
            this.titlePanel1.Title = "เปลี่ยนสาย";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._changeContractRouteScreenTop1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 46);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(455, 92);
            this.panel1.TabIndex = 5;
            // 
            // ChangeContractRouteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(455, 170);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlePanel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ChangeContractRouteForm";
            this.Text = "เปลี่ยนสาย";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _processButton;
        private System.Windows.Forms.Button _cancelButton;
        private _changeContractRouteScreenTop _changeContractRouteScreenTop1;
        private System.Windows.Forms.Panel panel1;
        public Control.TitlePanel titlePanel1;
    }
}