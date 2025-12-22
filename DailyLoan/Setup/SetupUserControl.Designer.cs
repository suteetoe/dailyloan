namespace DailyLoan.Setup
{
    partial class SetupUserControl
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
            this._routeMenuButton = new System.Windows.Forms.Button();
            this._employeeMenuButton = new System.Windows.Forms.Button();
            this._holidayMenuButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel1
            // 
            this.titlePanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.titlePanel1.Location = new System.Drawing.Point(0, 0);
            this.titlePanel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.titlePanel1.Name = "titlePanel1";
            this.titlePanel1.Size = new System.Drawing.Size(700, 60);
            this.titlePanel1.TabIndex = 2;
            this.titlePanel1.Title = "ตั้งค่า";
            // 
            // _routeMenuButton
            // 
            this._routeMenuButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._routeMenuButton.Image = global::DailyLoan.Properties.Resources.books_48;
            this._routeMenuButton.Location = new System.Drawing.Point(144, 3);
            this._routeMenuButton.Name = "_routeMenuButton";
            this._routeMenuButton.Size = new System.Drawing.Size(143, 126);
            this._routeMenuButton.TabIndex = 1;
            this._routeMenuButton.Text = "สาย";
            this._routeMenuButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._routeMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._routeMenuButton.UseVisualStyleBackColor = true;
            this._routeMenuButton.Click += new System.EventHandler(this._routeMenuButton_Click);
            // 
            // _employeeMenuButton
            // 
            this._employeeMenuButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._employeeMenuButton.Image = global::DailyLoan.Properties.Resources.user3_48;
            this._employeeMenuButton.Location = new System.Drawing.Point(3, 3);
            this._employeeMenuButton.Name = "_employeeMenuButton";
            this._employeeMenuButton.Size = new System.Drawing.Size(135, 126);
            this._employeeMenuButton.TabIndex = 0;
            this._employeeMenuButton.Text = "พนักงาน";
            this._employeeMenuButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._employeeMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._employeeMenuButton.UseVisualStyleBackColor = true;
            this._employeeMenuButton.Click += new System.EventHandler(this._employeeMenuButton_Click);
            // 
            // _holidayMenuButton
            // 
            this._holidayMenuButton.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this._holidayMenuButton.Image = global::DailyLoan.Properties.Resources.calendar_48;
            this._holidayMenuButton.Location = new System.Drawing.Point(293, 3);
            this._holidayMenuButton.Name = "_holidayMenuButton";
            this._holidayMenuButton.Size = new System.Drawing.Size(143, 126);
            this._holidayMenuButton.TabIndex = 2;
            this._holidayMenuButton.Text = "วันหยุด";
            this._holidayMenuButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._holidayMenuButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._holidayMenuButton.UseVisualStyleBackColor = true;
            this._holidayMenuButton.Click += new System.EventHandler(this._holidayMenuButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this._employeeMenuButton);
            this.flowLayoutPanel1.Controls.Add(this._routeMenuButton);
            this.flowLayoutPanel1.Controls.Add(this._holidayMenuButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 60);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(700, 610);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // SetupUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.titlePanel1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Name = "SetupUserControl";
            this.Size = new System.Drawing.Size(700, 670);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.TitlePanel titlePanel1;
        private System.Windows.Forms.Button _routeMenuButton;
        private System.Windows.Forms.Button _employeeMenuButton;
        private System.Windows.Forms.Button _holidayMenuButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
