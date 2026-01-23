namespace TestReportRender
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.test_sml_screen1 = new TestReportRender.test_sml_screen();
            this.test_grid1 = new TestReportRender.test_grid();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // test_sml_screen1
            // 
            this.test_sml_screen1._isChange = false;
            this.test_sml_screen1.BackColor = System.Drawing.Color.Transparent;
            this.test_sml_screen1.Dock = System.Windows.Forms.DockStyle.Top;
            this.test_sml_screen1.Location = new System.Drawing.Point(0, 25);
            this.test_sml_screen1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.test_sml_screen1.Name = "test_sml_screen1";
            this.test_sml_screen1.Size = new System.Drawing.Size(1266, 306);
            this.test_sml_screen1.TabIndex = 2;
            // 
            // test_grid1
            // 
            this.test_grid1._extraWordShow = true;
            this.test_grid1._selectRow = -1;
            this.test_grid1.AllowImportDataToGrid = true;
            this.test_grid1.ColumnBackground = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(251)))), ((int)(((byte)(252)))));
            this.test_grid1.ColumnBackgroundEnd = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(227)))));
            this.test_grid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.test_grid1.Font = new System.Drawing.Font("Tahoma", 9F);
            this.test_grid1.Location = new System.Drawing.Point(0, 25);
            this.test_grid1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.test_grid1.Name = "test_grid1";
            this.test_grid1.ShowTotal = true;
            this.test_grid1.Size = new System.Drawing.Size(1266, 770);
            this.test_grid1.TabIndex = 3;
            this.test_grid1.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1266, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(126, 22);
            this.toolStripButton1.Text = "Test Render Report";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1266, 795);
            this.Controls.Add(this.test_sml_screen1);
            this.Controls.Add(this.test_grid1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private test_sml_screen test_sml_screen1;
        private test_grid test_grid1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}

