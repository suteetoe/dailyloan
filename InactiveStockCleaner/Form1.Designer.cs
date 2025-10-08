namespace InactiveStockCleaner
{
    partial class InactiveStockCleaner_Form
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
            this.mainTabControl = new System.Windows.Forms.TabControl();
            this.loginTabPage = new System.Windows.Forms.TabPage();
            this.statusLabel = new System.Windows.Forms.Label();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dbNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dbPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dbUserTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dbPortTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbHostTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.processTabPage = new System.Windows.Forms.TabPage();
            this.processControl1 = new InactiveStockCleaner.ProcessControl();
            this.mainTabControl.SuspendLayout();
            this.loginTabPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.processTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainTabControl
            // 
            this.mainTabControl.Controls.Add(this.loginTabPage);
            this.mainTabControl.Controls.Add(this.processTabPage);
            this.mainTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTabControl.Location = new System.Drawing.Point(0, 0);
            this.mainTabControl.Name = "mainTabControl";
            this.mainTabControl.SelectedIndex = 0;
            this.mainTabControl.Size = new System.Drawing.Size(1988, 1291);
            this.mainTabControl.TabIndex = 0;
            // 
            // loginTabPage
            // 
            this.loginTabPage.Controls.Add(this.statusLabel);
            this.loginTabPage.Controls.Add(this.testConnectionButton);
            this.loginTabPage.Controls.Add(this.loginButton);
            this.loginTabPage.Controls.Add(this.groupBox1);
            this.loginTabPage.Location = new System.Drawing.Point(4, 29);
            this.loginTabPage.Name = "loginTabPage";
            this.loginTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.loginTabPage.Size = new System.Drawing.Size(1980, 1258);
            this.loginTabPage.TabIndex = 0;
            this.loginTabPage.Text = "Login";
            this.loginTabPage.UseVisualStyleBackColor = true;
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusLabel.ForeColor = System.Drawing.Color.Red;
            this.statusLabel.Location = new System.Drawing.Point(30, 340);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 25);
            this.statusLabel.TabIndex = 3;
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.testConnectionButton.Location = new System.Drawing.Point(276, 236);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(128, 40);
            this.testConnectionButton.TabIndex = 10;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // loginButton
            // 
            this.loginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginButton.Location = new System.Drawing.Point(410, 236);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(120, 40);
            this.loginButton.TabIndex = 2;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dbNameTextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dbPasswordTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dbUserTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.dbPortTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dbHostTextBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(30, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(500, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database Configuration";
            // 
            // dbNameTextBox
            // 
            this.dbNameTextBox.Location = new System.Drawing.Point(150, 160);
            this.dbNameTextBox.Name = "dbNameTextBox";
            this.dbNameTextBox.Size = new System.Drawing.Size(320, 30);
            this.dbNameTextBox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Database Name:";
            // 
            // dbPasswordTextBox
            // 
            this.dbPasswordTextBox.Location = new System.Drawing.Point(150, 125);
            this.dbPasswordTextBox.Name = "dbPasswordTextBox";
            this.dbPasswordTextBox.PasswordChar = '*';
            this.dbPasswordTextBox.Size = new System.Drawing.Size(320, 30);
            this.dbPasswordTextBox.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // dbUserTextBox
            // 
            this.dbUserTextBox.Location = new System.Drawing.Point(150, 90);
            this.dbUserTextBox.Name = "dbUserTextBox";
            this.dbUserTextBox.Size = new System.Drawing.Size(320, 30);
            this.dbUserTextBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username:";
            // 
            // dbPortTextBox
            // 
            this.dbPortTextBox.Location = new System.Drawing.Point(150, 55);
            this.dbPortTextBox.Name = "dbPortTextBox";
            this.dbPortTextBox.Size = new System.Drawing.Size(320, 30);
            this.dbPortTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // dbHostTextBox
            // 
            this.dbHostTextBox.Location = new System.Drawing.Point(150, 25);
            this.dbHostTextBox.Name = "dbHostTextBox";
            this.dbHostTextBox.Size = new System.Drawing.Size(320, 30);
            this.dbHostTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host:";
            // 
            // processTabPage
            // 
            this.processTabPage.Controls.Add(this.processControl1);
            this.processTabPage.Location = new System.Drawing.Point(4, 29);
            this.processTabPage.Name = "processTabPage";
            this.processTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.processTabPage.Size = new System.Drawing.Size(1980, 1258);
            this.processTabPage.TabIndex = 1;
            this.processTabPage.Text = "Process";
            this.processTabPage.UseVisualStyleBackColor = true;
            // 
            // processControl1
            // 
            this.processControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.processControl1.Location = new System.Drawing.Point(3, 3);
            this.processControl1.Name = "processControl1";
            this.processControl1.Size = new System.Drawing.Size(1974, 1252);
            this.processControl1.TabIndex = 0;
            // 
            // InactiveStockCleaner_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1988, 1291);
            this.Controls.Add(this.mainTabControl);
            this.Name = "InactiveStockCleaner_Form";
            this.Text = "InactiveStockCleaner";
            this.Load += new System.EventHandler(this.InactiveStockCleaner_Form_Load);
            this.mainTabControl.ResumeLayout(false);
            this.loginTabPage.ResumeLayout(false);
            this.loginTabPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.processTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl mainTabControl;
        private System.Windows.Forms.TabPage loginTabPage;
        private System.Windows.Forms.TabPage processTabPage;
        private InactiveStockCleaner.ProcessControl processControl1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox dbNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dbPasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dbUserTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dbPortTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox dbHostTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button testConnectionButton;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label statusLabel;
    }
}

