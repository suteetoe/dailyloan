using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Setup.Employee
{
    public class EmployeeControl : Control.ManageDataList
    {
        private EmployeeDetailScreen employeeDetailScreen1;

        public EmployeeControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 30, ColumnCode = "code", ColumnName = "รหัสพนักงาน" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 70, ColumnCode = "name_1", ColumnName = "ชื่อพนักงาน" });
            this._dataListGrid.Invalidate();
        }

        private void InitializeComponent()
        {
            this.employeeDetailScreen1 = new DailyLoan.Setup.Employee.EmployeeDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.titlePanel.Title  = "พนักงาน";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.employeeDetailScreen1);
            // 
            // employeeDetailScreen1
            // 
            this.employeeDetailScreen1._isChange = false;
            this.employeeDetailScreen1.BackColor = System.Drawing.Color.Transparent;
            this.employeeDetailScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeDetailScreen1.Location = new System.Drawing.Point(0, 0);
            this.employeeDetailScreen1.Name = "employeeDetailScreen1";
            this.employeeDetailScreen1.Size = new System.Drawing.Size(365, 535);
            this.employeeDetailScreen1.TabIndex = 0;
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "EmployeeControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
