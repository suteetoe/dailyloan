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
            this._customerMenuButton = new System.Windows.Forms.ToolStripButton();
            this._paymentListMenuButton = new System.Windows.Forms.ToolStripButton();
            this._routePaymentMenuButton = new System.Windows.Forms.ToolStripButton();
            this._expenseMenuButton = new System.Windows.Forms.ToolStripButton();
            this._reportMenuButton = new System.Windows.Forms.ToolStripButton();
            this._setupMenuButton = new System.Windows.Forms.ToolStripButton();
            this._welcomeMenuButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this._mainPanel = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this._versionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this._sidebarPanel.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1506, 24);
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
            this._sidebarPanel.Size = new System.Drawing.Size(200, 784);
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
            this._customerMenuButton,
            this._paymentListMenuButton,
            this._routePaymentMenuButton,
            this._expenseMenuButton,
            this._reportMenuButton,
            this._setupMenuButton,
            this._welcomeMenuButton,
            this.toolStripSeparator2});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(200, 784);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // _loanMenuButton
            // 
            this._loanMenuButton.Image = global::DailyLoan.Properties.Resources.book_red;
            this._loanMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._loanMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._loanMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._loanMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._loanMenuButton.Name = "_loanMenuButton";
            this._loanMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._loanMenuButton.Size = new System.Drawing.Size(178, 48);
            this._loanMenuButton.Text = "สัญญาเงินกู้";
            this._loanMenuButton.Click += new System.EventHandler(this._loanMenuButton_Click);
            // 
            // _dailyMenuButton
            // 
            this._dailyMenuButton.Image = global::DailyLoan.Properties.Resources.note;
            this._dailyMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._dailyMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._dailyMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._dailyMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._dailyMenuButton.Name = "_dailyMenuButton";
            this._dailyMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._dailyMenuButton.Size = new System.Drawing.Size(178, 48);
            this._dailyMenuButton.Text = "ใบรายวัน";
            this._dailyMenuButton.Click += new System.EventHandler(this._dailyMenuButton_Click);
            // 
            // _customerMenuButton
            // 
            this._customerMenuButton.Image = global::DailyLoan.Properties.Resources.businessman;
            this._customerMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._customerMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._customerMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._customerMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._customerMenuButton.Name = "_customerMenuButton";
            this._customerMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._customerMenuButton.Size = new System.Drawing.Size(178, 48);
            this._customerMenuButton.Text = "ลูกค้า";
            this._customerMenuButton.Click += new System.EventHandler(this._customerMenuButton_Click);
            // 
            // _paymentListMenuButton
            // 
            this._paymentListMenuButton.Image = global::DailyLoan.Properties.Resources.money2_24;
            this._paymentListMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._paymentListMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._paymentListMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._paymentListMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._paymentListMenuButton.Name = "_paymentListMenuButton";
            this._paymentListMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._paymentListMenuButton.Size = new System.Drawing.Size(178, 48);
            this._paymentListMenuButton.Text = "การชำระเงิน";
            this._paymentListMenuButton.Click += new System.EventHandler(this._paymentListMenuButton_Click);
            // 
            // _routePaymentMenuButton
            // 
            this._routePaymentMenuButton.Image = global::DailyLoan.Properties.Resources.note_view_24;
            this._routePaymentMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._routePaymentMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._routePaymentMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._routePaymentMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._routePaymentMenuButton.Name = "_routePaymentMenuButton";
            this._routePaymentMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._routePaymentMenuButton.Size = new System.Drawing.Size(178, 48);
            this._routePaymentMenuButton.Text = "การชำระเงิน(สาย)";
            this._routePaymentMenuButton.Click += new System.EventHandler(this._routePaymentMenuButton_Click);
            // 
            // _expenseMenuButton
            // 
            this._expenseMenuButton.Image = global::DailyLoan.Properties.Resources.form_yellow;
            this._expenseMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._expenseMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._expenseMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._expenseMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._expenseMenuButton.Name = "_expenseMenuButton";
            this._expenseMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._expenseMenuButton.Size = new System.Drawing.Size(178, 48);
            this._expenseMenuButton.Text = "ค่าใช้จ่าย";
            this._expenseMenuButton.Click += new System.EventHandler(this._expenseMenuButton_Click);
            // 
            // _reportMenuButton
            // 
            this._reportMenuButton.Image = global::DailyLoan.Properties.Resources.column_chart;
            this._reportMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._reportMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._reportMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._reportMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._reportMenuButton.Name = "_reportMenuButton";
            this._reportMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._reportMenuButton.Size = new System.Drawing.Size(178, 48);
            this._reportMenuButton.Text = "รายงาน";
            this._reportMenuButton.Click += new System.EventHandler(this._reportMenuButton_Click);
            // 
            // _setupMenuButton
            // 
            this._setupMenuButton.Image = global::DailyLoan.Properties.Resources.server_preferences;
            this._setupMenuButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._setupMenuButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this._setupMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._setupMenuButton.Margin = new System.Windows.Forms.Padding(10);
            this._setupMenuButton.Name = "_setupMenuButton";
            this._setupMenuButton.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this._setupMenuButton.Size = new System.Drawing.Size(178, 48);
            this._setupMenuButton.Text = "ตั้งค่า";
            this._setupMenuButton.ToolTipText = "ตั้งค่า";
            this._setupMenuButton.Click += new System.EventHandler(this._setupMenuButton_Click);
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
            this._mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainPanel.Location = new System.Drawing.Point(200, 24);
            this._mainPanel.Name = "_mainPanel";
            this._mainPanel.Size = new System.Drawing.Size(1306, 784);
            this._mainPanel.TabIndex = 5;
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
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._versionLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 808);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1506, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // _versionLabel
            // 
            this._versionLabel.AutoSize = false;
            this._versionLabel.Name = "_versionLabel";
            this._versionLabel.Size = new System.Drawing.Size(150, 17);
            this._versionLabel.Text = "Version: ";
            this._versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1506, 830);
            this.Controls.Add(this._mainPanel);
            this.Controls.Add(this._sidebarPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton _loanMenuButton;
        private System.Windows.Forms.ToolStripButton _dailyMenuButton;
        private System.Windows.Forms.ToolStripButton _expenseMenuButton;
        private System.Windows.Forms.ToolStripButton _welcomeMenuButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton _reportMenuButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton _setupMenuButton;
        private System.Windows.Forms.ToolStripButton _customerMenuButton;
        private System.Windows.Forms.ToolStripButton _paymentListMenuButton;
        private System.Windows.Forms.ToolStripButton _routePaymentMenuButton;
        private System.Windows.Forms.ToolStripStatusLabel _versionLabel;
    }
}

