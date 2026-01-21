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
            this.testRenderReportButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testRenderReportButton
            // 
            this.testRenderReportButton.Location = new System.Drawing.Point(108, 190);
            this.testRenderReportButton.Name = "testRenderReportButton";
            this.testRenderReportButton.Size = new System.Drawing.Size(216, 91);
            this.testRenderReportButton.TabIndex = 0;
            this.testRenderReportButton.Text = "Render Report";
            this.testRenderReportButton.UseVisualStyleBackColor = true;
            this.testRenderReportButton.Click += new System.EventHandler(this.testRenderReportButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 521);
            this.Controls.Add(this.testRenderReportButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button testRenderReportButton;
    }
}

