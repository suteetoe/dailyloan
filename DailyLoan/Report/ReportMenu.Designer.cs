namespace DailyLoan.Report
{
    partial class ReportMenu
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // titlePanel1
            // 
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.Size = new System.Drawing.Size(618, 48);
            this.titlePanel1.TabIndex = 0;
            this.titlePanel1.Title = "Title";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(618, 476);
            this.panel1.TabIndex = 1;
            // 
            // ReportMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlePanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "ReportMenu";
            this.Size = new System.Drawing.Size(618, 524);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.TitlePanel titlePanel1;
        private System.Windows.Forms.Panel panel1;
    }
}
