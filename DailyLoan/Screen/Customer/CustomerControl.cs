using DailyLoan.Control;
using DailyLoan.Data.Repository;
using DocumentFormat.OpenXml.Office2010.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.Customer
{
    public class CustomerControl : Control.ManageDataList
    {
        private _customerDataScreen _customerDataScreen1;
        CustomerRepository _customerRepository = new CustomerRepository();

        public CustomerControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "รหัสลูกค้า", ColumnCode = "code", WidthPercent = 20 });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "ชื่อลูกค้า", ColumnCode = "name_1", WidthPercent = 60 });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { ColumnName = "โทรศัพท์", ColumnCode = "telephone", WidthPercent = 20 });
            this._dataListGrid._calcPersentWidthToScatter();

            this._customerDataScreen1.ReadOnly = true;
        }

        protected override void ClearScreen()
        {
            this._customerDataScreen1._clear();
            this._customerDataScreen1._enabedControl("code", true);
        }

        protected override void ChangeFormMode(bool isEdit)
        {
            this._customerDataScreen1.ReadOnly = !isEdit;
        }


        protected override string LoadDataListQuery()
        {
            string filter = this.GetFilterCommand();
            string query = "SELECT code, name_1, telephone from mst_customer " + (filter.Length > 0 ? " WHERE " + filter : "");
            return query;
        }

        protected override string SortField()
        {
            string sort = " order by code";
            return sort;

        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            string code = selectedRow["code"].ToString();

            var customer = _customerRepository.GetCustomerByCode(code);
            if (customer != null)
            {
                this._customerDataScreen1.LoadCustomerData(customer);
                this._customerDataScreen1._enabedControl("code", false);
                return true;
            }
            return false;
        }

        protected override bool OnSaveData()
        {
            string requireText = this._customerDataScreen1._checkEmtryField();
            if (requireText != "")
            {
                MessageBox.Show(requireText, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            var saveCustomer = this._customerDataScreen1.GetCustomerModel();
            if (this.formMode == FormMode.EDIT)
            {
                _customerRepository.UpdateCustomer(saveCustomer);
            }
            else
            {
                _customerRepository.CreateCustomer(saveCustomer);
            }

            return true;

        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                string code = rowSelected["code"].ToString();
                _customerRepository.DeleteCustomer(code);
                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้\n" + ex.Message, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
        }

        private void InitializeComponent()
        {
            this._customerDataScreen1 = new DailyLoan.Screen.Customer._customerDataScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _dataListGrid
            // 
            this._dataListGrid.Size = new System.Drawing.Size(407, 539);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._customerDataScreen1);
            this.panel2.Size = new System.Drawing.Size(359, 575);
            // 
            // _dataLoadingTimer
            // 
            this._dataLoadingTimer.Enabled = true;
            // 
            // _customerDataScreen1
            // 
            this._customerDataScreen1._isChange = false;
            this._customerDataScreen1.BackColor = System.Drawing.Color.Transparent;
            this._customerDataScreen1.Dock = System.Windows.Forms.DockStyle.Fill;
            this._customerDataScreen1.Location = new System.Drawing.Point(0, 0);
            this._customerDataScreen1.Name = "_customerDataScreen1";
            this._customerDataScreen1.Size = new System.Drawing.Size(359, 575);
            this._customerDataScreen1.TabIndex = 0;
            //
            // titlePanel
            //
            this.titlePanel.Title = "ลูกค้า";
            // 
            // CustomerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.Name = "CustomerControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
