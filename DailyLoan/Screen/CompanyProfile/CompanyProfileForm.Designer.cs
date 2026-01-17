namespace DailyLoan.Screen.CompanyProfile
{
    partial class CompanyProfileForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyProfileForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this._saveButton = new System.Windows.Forms.ToolStripButton();
            this._cancelButton = new System.Windows.Forms.ToolStripButton();
            this._companyProfileDetailScreen1 = new DailyLoan.Screen.CompanyProfile._companyProfileDetailScreen();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveButton,
            this._cancelButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(509, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // _saveButton
            // 
            this._saveButton.Image = global::DailyLoan.Properties.Resources.disk_blue;
            this._saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._saveButton.Name = "_saveButton";
            this._saveButton.Size = new System.Drawing.Size(55, 22);
            this._saveButton.Text = "บันทึก";
            this._saveButton.Click += new System.EventHandler(this._saveButton_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.Image = global::DailyLoan.Properties.Resources.delete2;
            this._cancelButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(56, 22);
            this._cancelButton.Text = "ยกเลิก";
            this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
            // 
            // _companyProfileDetailScreen1
            // 
            this._companyProfileDetailScreen1._isChange = false;
            this._companyProfileDetailScreen1.BackColor = System.Drawing.Color.Transparent;
            this._companyProfileDetailScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._companyProfileDetailScreen1.Location = new System.Drawing.Point(0, 25);
            this._companyProfileDetailScreen1.Name = "_companyProfileDetailScreen1";
            this._companyProfileDetailScreen1.Size = new System.Drawing.Size(509, 243);
            this._companyProfileDetailScreen1.TabIndex = 1;
            // 
            // CompanyProfileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 268);
            this.Controls.Add(this._companyProfileDetailScreen1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompanyProfileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "กำหนดค่าบริษัท";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton _saveButton;
        private System.Windows.Forms.ToolStripButton _cancelButton;
        private _companyProfileDetailScreen _companyProfileDetailScreen1;
    }
}