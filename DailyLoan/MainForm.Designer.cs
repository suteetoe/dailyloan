namespace DailyLoan
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._exitToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._sidebarPanel = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this._buttonMenuContract = new System.Windows.Forms.Button();
            this.buttonMenuDailySheet = new System.Windows.Forms.Button();
            this.buttonMenuReport = new System.Windows.Forms.Button();
            this._buttonAbout = new System.Windows.Forms.Button();
            this._mainPanel = new System.Windows.Forms.Panel();
            this.welcomeControl1 = new DailyLoan.WelcomeControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this._sidebarPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this._mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this._exitToolStripMenu});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(89, 6);
            // 
            // _exitToolStripMenu
            // 
            this._exitToolStripMenu.Name = "_exitToolStripMenu";
            this._exitToolStripMenu.Size = new System.Drawing.Size(92, 22);
            this._exitToolStripMenu.Text = "&Exit";
            this._exitToolStripMenu.Click += new System.EventHandler(this._exitToolStripMenu_Click);
            // 
            // _sidebarPanel
            // 
            this._sidebarPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._sidebarPanel.Controls.Add(this.flowLayoutPanel1);
            this._sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._sidebarPanel.Location = new System.Drawing.Point(0, 24);
            this._sidebarPanel.Name = "_sidebarPanel";
            this._sidebarPanel.Size = new System.Drawing.Size(200, 705);
            this._sidebarPanel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._buttonMenuContract);
            this.flowLayoutPanel1.Controls.Add(this.buttonMenuDailySheet);
            this.flowLayoutPanel1.Controls.Add(this.buttonMenuReport);
            this.flowLayoutPanel1.Controls.Add(this._buttonAbout);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 318);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // _buttonMenuContract
            // 
            this._buttonMenuContract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonMenuContract.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._buttonMenuContract.Location = new System.Drawing.Point(3, 3);
            this._buttonMenuContract.Name = "_buttonMenuContract";
            this._buttonMenuContract.Size = new System.Drawing.Size(194, 50);
            this._buttonMenuContract.TabIndex = 0;
            this._buttonMenuContract.Text = "สัญญาเงินกู้";
            this._buttonMenuContract.UseVisualStyleBackColor = true;
            this._buttonMenuContract.Click += new System.EventHandler(this._buttonMenuContract_Click);
            // 
            // buttonMenuDailySheet
            // 
            this.buttonMenuDailySheet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuDailySheet.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonMenuDailySheet.Location = new System.Drawing.Point(3, 59);
            this.buttonMenuDailySheet.Name = "buttonMenuDailySheet";
            this.buttonMenuDailySheet.Size = new System.Drawing.Size(194, 50);
            this.buttonMenuDailySheet.TabIndex = 1;
            this.buttonMenuDailySheet.Text = "ใบรายวัน";
            this.buttonMenuDailySheet.UseVisualStyleBackColor = true;
            this.buttonMenuDailySheet.Click += new System.EventHandler(this.buttonMenuDailySheet_Click);
            // 
            // buttonMenuReport
            // 
            this.buttonMenuReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMenuReport.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.buttonMenuReport.Location = new System.Drawing.Point(3, 115);
            this.buttonMenuReport.Name = "buttonMenuReport";
            this.buttonMenuReport.Size = new System.Drawing.Size(194, 50);
            this.buttonMenuReport.TabIndex = 2;
            this.buttonMenuReport.Text = "รายงาน";
            this.buttonMenuReport.UseVisualStyleBackColor = true;
            // 
            // _buttonAbout
            // 
            this._buttonAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this._buttonAbout.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this._buttonAbout.Location = new System.Drawing.Point(3, 171);
            this._buttonAbout.Name = "_buttonAbout";
            this._buttonAbout.Size = new System.Drawing.Size(194, 50);
            this._buttonAbout.TabIndex = 3;
            this._buttonAbout.Text = "เกี่ยวกับโปรแกรม";
            this._buttonAbout.UseVisualStyleBackColor = true;
            this._buttonAbout.Click += new System.EventHandler(this._buttonAbout_Click);
            // 
            // _mainPanel
            // 
            this._mainPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._mainPanel.Controls.Add(this.welcomeControl1);
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(200, 24);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(808, 705);
            this._mainPanel.TabIndex = 5;
            // 
            // welcomeControl1
            // 
            this.welcomeControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.welcomeControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.welcomeControl1.Location = new System.Drawing.Point(0, 0);
            this.welcomeControl1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.welcomeControl1.Name = "welcomeControl1";
            this.welcomeControl1.Size = new System.Drawing.Size(808, 705);
            this.welcomeControl1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1008, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this._sidebarPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this._sidebarPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this._mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel _sidebarPanel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem _exitToolStripMenu;
        private System.Windows.Forms.Panel _mainPanel;
        private WelcomeControl welcomeControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button _buttonMenuContract;
        private System.Windows.Forms.Button buttonMenuDailySheet;
        private System.Windows.Forms.Button buttonMenuReport;
        private System.Windows.Forms.Button _buttonAbout;
    }
}

