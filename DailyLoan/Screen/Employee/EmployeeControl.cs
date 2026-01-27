using DailyLoan.Control;
using DailyLoan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.Employee
{
    public class EmployeeControl : Control.ManageDataList
    {
        private EmployeeDetailScreen employeeDetailScreen1;
        EmployeeRepository employeeRepository = new EmployeeRepository();

        public EmployeeControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 30, ColumnCode = "code", ColumnName = "รหัสพนักงาน" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 70, ColumnCode = "name_1", ColumnName = "ชื่อพนักงาน" });
            this._dataListGrid.Invalidate();

            this.employeeDetailScreen1.ReadOnly = true;
        }

        protected override void ChangeFormMode(bool isEdit)
        {
            this.employeeDetailScreen1.ReadOnly = !isEdit;
        }

        private void InitializeComponent()
        {
            this.employeeDetailScreen1 = new DailyLoan.Screen.Employee.EmployeeDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.titlePanel.Title = "พนักงาน";
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

        protected override string LoadDataListQuery()
        {
            string query = "SELECT code, name_1 from mst_employee ";
            return query;
        }

        protected override void ClearScreen()
        {
            this.employeeDetailScreen1._clear();
            this.employeeDetailScreen1._enabedControl("code", true);


        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            string code = selectedRow["code"];
            var employee = employeeRepository.GetEmployeeByCode(code);
            if (employee != null)
            {
                this.employeeDetailScreen1._loadData(employee);
                this.employeeDetailScreen1._enabedControl("code", false);
                return true;
            }
            return false;
        }

        protected override bool OnSaveData()
        {
            string requireText = this.employeeDetailScreen1._checkEmtryField();
            if (requireText != "")
            {
                MessageBox.Show(requireText, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DailyLoan.Data.Models.Employee saveEmp = new DailyLoan.Data.Models.Employee();
            saveEmp.code = this.employeeDetailScreen1._getDataStr("code");
            saveEmp.name_1 = this.employeeDetailScreen1._getDataStr("name_1");

            if (this.formMode == FormMode.EDIT)
            {
                employeeRepository.UpdateEmployee(saveEmp);
            }
            else
            {
                employeeRepository.CreateEmployee(saveEmp);
            }
            return true;

        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                employeeRepository.DeleteEmployee(rowSelected["code"]);

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้\n" + ex.Message, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }
    }
}
