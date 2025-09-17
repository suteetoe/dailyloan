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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this._exitToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._sidebarPanel = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this._loanMenuButton = new System.Windows.Forms.ToolStripButton();
            this._dailyMenuButton = new System.Windows.Forms.ToolStripButton();
            this._reportMenuButton = new System.Windows.Forms.ToolStripButton();
            this._welcomeMenuButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._mainPanel = new System.Windows.Forms.Panel();
            this.welcomeControl1 = new DailyLoan.WelcomeControl();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.menuStrip1.SuspendLayout();
            this._sidebarPanel.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this._sidebarPanel.BackColor = System.Drawing.Color.AliceBlue;
            this._sidebarPanel.Controls.Add(this.toolStrip2);
            this._sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this._sidebarPanel.Location = new System.Drawing.Point(0, 24);
            this._sidebarPanel.Name = "_sidebarPanel";
            this._sidebarPanel.Size = new System.Drawing.Size(200, 705);
            this._sidebarPanel.TabIndex = 4;
            // 
            // toolStrip2
            // 
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.BackColor = System.Drawing.Color.LightBlue;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._loanMenuButton,
            this._dailyMenuButton,
            this._reportMenuButton,
            this._welcomeMenuButton,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(200, 705);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // _loanMenuButton
            // 
            this._loanMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._loanMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("_loanMenuButton.Image")));
            this._loanMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loanMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._loanMenuButton.Name = "_loanMenuButton";
            this._loanMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._loanMenuButton.Size = new System.Drawing.Size(178, 43);
            this._loanMenuButton.Text = "สัญญาเงินกู้";
            this._loanMenuButton.Click += new System.EventHandler(this._loanMenuButton_Click);
            // 
            // _dailyMenuButton
            // 
            this._dailyMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._dailyMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("_dailyMenuButton.Image")));
            this._dailyMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._dailyMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._dailyMenuButton.Name = "_dailyMenuButton";
            this._dailyMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._dailyMenuButton.Size = new System.Drawing.Size(178, 43);
            this._dailyMenuButton.Text = "ใบรายวัน";
            this._dailyMenuButton.Click += new System.EventHandler(this._dailyMenuButton_Click);
            // 
            // _reportMenuButton
            // 
            this._reportMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._reportMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("_reportMenuButton.Image")));
            this._reportMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._reportMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._reportMenuButton.Name = "_reportMenuButton";
            this._reportMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._reportMenuButton.Size = new System.Drawing.Size(178, 43);
            this._reportMenuButton.Text = "รายงาน";
            this._reportMenuButton.Click += new System.EventHandler(this._reportMenuButton_Click);
            // 
            // _welcomeMenuButton
            // 
            this._welcomeMenuButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this._welcomeMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this._welcomeMenuButton.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._welcomeMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("_welcomeMenuButton.Image")));
            this._welcomeMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._welcomeMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._welcomeMenuButton.Name = "_welcomeMenuButton";
            this._welcomeMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._welcomeMenuButton.Size = new System.Drawing.Size(178, 38);
            this._welcomeMenuButton.Text = "เกี่ยวกับโปรแกรม";
            this._welcomeMenuButton.Click += new System.EventHandler(this._welcomeMenuButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
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
            this.welcomeControl1.BackColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton _loanMenuButton;
        private System.Windows.Forms.ToolStripButton _dailyMenuButton;
        private System.Windows.Forms.ToolStripButton _reportMenuButton;
        private System.Windows.Forms.ToolStripButton _welcomeMenuButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

