namespace DailyLoan.Control
{
    partial class SearchDataForm
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
            this.components = new System.ComponentModel.Container();
            this.searchDataControl1 = new DailyLoan.Control.SearchDataControl();
            this._loadTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // searchDataControl1
            // 
            this.searchDataControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchDataControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.searchDataControl1.Location = new System.Drawing.Point(0, 0);
            this.searchDataControl1.Name = "searchDataControl1";
            this.searchDataControl1.Size = new System.Drawing.Size(419, 331);
            this.searchDataControl1.TabIndex = 0;
            // 
            // _loadTimer
            // 
            this._loadTimer.Interval = 1000;
            this._loadTimer.Tick += new System.EventHandler(this._loadTimer_Tick);
            // 
            // SearchDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 331);
            this.Controls.Add(this.searchDataControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SearchDataForm";
            this.Text = "SearchDataForm";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer _loadTimer;
        protected SearchDataControl searchDataControl1;
    }
}