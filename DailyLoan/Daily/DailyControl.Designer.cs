namespace DailyLoan.Daily
{
    partial class DailyControl
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
            this._dailyScreenTop1 = new DailyLoan.Daily._dailyScreenTop();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this._dailyGrid1 = new DailyLoan.Daily._dailyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel1
            // 
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.Size = new System.Drawing.Size(883, 48);
            this.titlePanel1.TabIndex = 3;
            this.titlePanel1.Title = "ใบรายวัน";
            // 
            // _dailyScreenTop1
            // 
            this._dailyScreenTop1._isChange = false;
            this._dailyScreenTop1.BackColor = System.Drawing.Color.Transparent;
            this._dailyScreenTop1.Dock = System.Windows.Forms.DockStyle.Top;
            this._dailyScreenTop1.Location = new System.Drawing.Point(10, 10);
            this._dailyScreenTop1.Name = "_dailyScreenTop1";
            this._dailyScreenTop1.Size = new System.Drawing.Size(752, 35);
            this._dailyScreenTop1.TabIndex = 4;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(772, 48);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(111, 612);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripButton1.Image = global::DailyLoan.Properties.Resources.icons8_microsoft_excel_32;
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0, 10, 0, 20);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(97, 97);
            this.toolStripButton1.Text = "Create Excel";
            this.toolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripButton2.ForeColor = System.Drawing.Color.Red;
            this.toolStripButton2.Image = global::DailyLoan.Properties.Resources.icons8_microsoft_excel_32;
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Margin = new System.Windows.Forms.Padding(0, 1, 0, 20);
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(97, 97);
            this.toolStripButton2.Text = "Import Excel";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.AutoSize = false;
            this.toolStripButton3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.toolStripButton3.Image = global::DailyLoan.Properties.Resources.notebook_preferences_32;
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Margin = new System.Windows.Forms.Padding(0, 1, 0, 20);
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(97, 97);
            this.toolStripButton3.Text = "ปรับยอดชำระ";
            this.toolStripButton3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // _dailyGrid1
            // 
            this._dailyGrid1._extraWordShow = true;
            this._dailyGrid1._selectRow = -1;
            this._dailyGrid1.AllowImportDataToGrid = true;
            this._dailyGrid1.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this._dailyGrid1.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this._dailyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dailyGrid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this._dailyGrid1.Location = new System.Drawing.Point(10, 45);
            this._dailyGrid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dailyGrid1.Name = "_dailyGrid1";
            this._dailyGrid1.ShowTotal = true;
            this._dailyGrid1.Size = new System.Drawing.Size(752, 557);
            this._dailyGrid1.TabIndex = 6;
            this._dailyGrid1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._dailyGrid1);
            this.panel1.Controls.Add(this._dailyScreenTop1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 48);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(772, 612);
            this.panel1.TabIndex = 7;
            // 
            // DailyControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.titlePanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DailyControl";
            this.Size = new System.Drawing.Size(883, 660);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Control.TitlePanel titlePanel1;
        private _dailyScreenTop _dailyScreenTop1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private _dailyGrid _dailyGrid1;
        private System.Windows.Forms.Panel panel1;
    }
}
