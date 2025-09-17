namespace DailyLoan
{
    partial class DBSettingForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._dbHostTextbox = new System.Windows.Forms.TextBox();
            this._dbPortTextbox = new System.Windows.Forms.TextBox();
            this._dbUserNameTextbox = new System.Windows.Forms.TextBox();
            this._dbDatabaseNameTextbox = new System.Windows.Forms.TextBox();
            this._dbPasswordTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this._testConnectionButton = new System.Windows.Forms.Button();
            this._buttonSaveConnection = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DailyLoan.Properties.Resources.data_ok;
            this.pictureBox1.Location = new System.Drawing.Point(20, 37);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(73, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(164, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Host :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 40);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Username :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 96);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "Password :";
            // 
            // _dbHostTextbox
            // 
            this._dbHostTextbox.Location = new System.Drawing.Point(212, 11);
            this._dbHostTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dbHostTextbox.Name = "_dbHostTextbox";
            this._dbHostTextbox.Size = new System.Drawing.Size(242, 22);
            this._dbHostTextbox.TabIndex = 5;
            // 
            // _dbPortTextbox
            // 
            this._dbPortTextbox.Location = new System.Drawing.Point(212, 37);
            this._dbPortTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dbPortTextbox.Name = "_dbPortTextbox";
            this._dbPortTextbox.Size = new System.Drawing.Size(58, 22);
            this._dbPortTextbox.TabIndex = 6;
            // 
            // _dbUserNameTextbox
            // 
            this._dbUserNameTextbox.Location = new System.Drawing.Point(212, 65);
            this._dbUserNameTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dbUserNameTextbox.Name = "_dbUserNameTextbox";
            this._dbUserNameTextbox.Size = new System.Drawing.Size(242, 22);
            this._dbUserNameTextbox.TabIndex = 7;
            // 
            // _dbDatabaseNameTextbox
            // 
            this._dbDatabaseNameTextbox.Location = new System.Drawing.Point(212, 121);
            this._dbDatabaseNameTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dbDatabaseNameTextbox.Name = "_dbDatabaseNameTextbox";
            this._dbDatabaseNameTextbox.Size = new System.Drawing.Size(242, 22);
            this._dbDatabaseNameTextbox.TabIndex = 8;
            // 
            // _dbPasswordTextbox
            // 
            this._dbPasswordTextbox.Location = new System.Drawing.Point(212, 93);
            this._dbPasswordTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._dbPasswordTextbox.Name = "_dbPasswordTextbox";
            this._dbPasswordTextbox.PasswordChar = '*';
            this._dbPasswordTextbox.Size = new System.Drawing.Size(242, 22);
            this._dbPasswordTextbox.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 124);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Database Name :";
            // 
            // _testConnectionButton
            // 
            this._testConnectionButton.Location = new System.Drawing.Point(13, 154);
            this._testConnectionButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._testConnectionButton.Name = "_testConnectionButton";
            this._testConnectionButton.Size = new System.Drawing.Size(106, 25);
            this._testConnectionButton.TabIndex = 11;
            this._testConnectionButton.Text = "Test Connect";
            this._testConnectionButton.UseVisualStyleBackColor = true;
            this._testConnectionButton.Click += new System.EventHandler(this._testConnectionButton_Click);
            // 
            // _buttonSaveConnection
            // 
            this._buttonSaveConnection.Location = new System.Drawing.Point(366, 154);
            this._buttonSaveConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._buttonSaveConnection.Name = "_buttonSaveConnection";
            this._buttonSaveConnection.Size = new System.Drawing.Size(88, 25);
            this._buttonSaveConnection.TabIndex = 12;
            this._buttonSaveConnection.Text = "Save";
            this._buttonSaveConnection.UseVisualStyleBackColor = true;
            this._buttonSaveConnection.Click += new System.EventHandler(this._buttonSaveConnection_Click);
            // 
            // _cancelButton
            // 
            this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancelButton.Location = new System.Drawing.Point(272, 154);
            this._cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this._cancelButton.Name = "_cancelButton";
            this._cancelButton.Size = new System.Drawing.Size(88, 25);
            this._cancelButton.TabIndex = 13;
            this._cancelButton.Text = "Cancel";
            this._cancelButton.UseVisualStyleBackColor = true;
            // 
            // DBSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 187);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._buttonSaveConnection);
            this.Controls.Add(this._testConnectionButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this._dbPasswordTextbox);
            this.Controls.Add(this._dbDatabaseNameTextbox);
            this.Controls.Add(this._dbUserNameTextbox);
            this.Controls.Add(this._dbPortTextbox);
            this.Controls.Add(this._dbHostTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "DBSettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DBSettingForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox _dbHostTextbox;
        private System.Windows.Forms.TextBox _dbPortTextbox;
        private System.Windows.Forms.TextBox _dbUserNameTextbox;
        private System.Windows.Forms.TextBox _dbDatabaseNameTextbox;
        private System.Windows.Forms.TextBox _dbPasswordTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button _testConnectionButton;
        private System.Windows.Forms.Button _buttonSaveConnection;
        private System.Windows.Forms.Button _cancelButton;
    }
}