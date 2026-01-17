using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyLoan.Data.Repository;
using DailyLoan.Screen.Customer;
using DailyLoan.Screen.LoanType;
using DailyLoan.Screen.Route;
using SMLControl;
namespace DailyLoan.Loan
{
    public class _loanScreenTop : SMLControl._myScreen
    {
        CustomerRepository CustomerRepository = new CustomerRepository();
        LoanTypeRepository LoanTypeRepository = new LoanTypeRepository();
        RouteRepository RouteRepository = new RouteRepository();

        public _loanScreenTop()
        {
            this._maxColumn = 2;
            int row = 0;
            this.AddDateField(new SMLControl.DateField() { Row = row, Column = 0, FieldCode = "contract_date", FieldName = "วันที่", Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "contract_number", FieldName = "เลขที่สัญญา", Required = true });

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "loan_type", FieldName = "ประเภทเงินกู้", IsSearch = true, ColumnSpan = 1, Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "route", FieldName = "สาย", MaxLength = 50, IsSearch = true, Required = true });
            row++;

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_name", FieldName = "ลูกค้า", IsSearch = true, ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_code", FieldName = "รหัสลูกค้า", MaxLength = 50 });

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "customer_address", FieldName = "ที่อยู่", RowSpan = 2, ColumnSpan = 2 });
            row += 2;

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_telephone", FieldName = "โทรศัพท์", MaxLength = 100 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "product_group", FieldName = "กลุ่มสินค้า", ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "description", FieldName = "รายละเอียด", ColumnSpan = 2, RowSpan = 3 });
            row += 3;

            //_myGroupBox groupBox = this.AddGroupBoxField(new SMLControl.GroupBoxField() { Row = row, RowSpan = 1, ColumnSpan = 2, ColumnCount = 2, FieldCode = "loan_type", FieldName = "ประเภทเงินกู้" });

            //this.AddRadioButtonField(groupBox, new SMLControl.RadioButtonField() { Row = 0, Column = 0, FieldCode = "daily_finance", FieldName = "รายวัน", Value = "0", Checked = true });
            //this.AddRadioButtonField(groupBox, new SMLControl.RadioButtonField() { Row = 0, Column = 1, FieldCode = "asses_finance", FieldName = "จำนำ", Value = "1" });
            //row += 2;

            // build loan type code


            this.AddNumberField(new SMLControl.NumberField() { Row = row++, Column = 0, ColumnSpan = 1, FieldCode = "principle_amount", FieldName = "เงินต้น", Required = true });
            this.AddNumberField(new SMLControl.NumberField() { Row = row, Column = 0, FieldCode = "interest_rate", FieldName = "ดอกเบี้ย (%)" });
            this.AddNumberField(new SMLControl.NumberField() { Row = row++, Column = 1, FieldCode = "total_interest", FieldName = "ดอกเบี้ยรวม", Required = true });

            this.AddNumberField(new SMLControl.NumberField() { Row = row, Column = 0, FieldCode = "num_of_period", FieldName = "จำนวนวัน/งวด", Required = true });
            this.AddNumberField(new SMLControl.NumberField() { Row = row++, Column = 1, FieldCode = "amount_per_period", FieldName = "งวดละ", Required = true });
            this.AddNumberField(new SMLControl.NumberField() { Row = row++, Column = 0, FieldCode = "income_other", FieldName = "รายได้อื่น ๆ" });

            this.AddDateField(new SMLControl.DateField() { Row = row++, Column = 0, FieldCode = "first_period_date", FieldName = "เริมชำระ/ครบกำหนด", Required = true });


            ((SMLControl._myTextBox)this._getControl("customer_name")).textBox.ReadOnly = true;
            ((SMLControl._myTextBox)this._getControl("customer_code")).textBox.ReadOnly = true;
            ((SMLControl._myTextBox)this._getControl("customer_address")).textBox.ReadOnly = true;
            ((SMLControl._myTextBox)this._getControl("customer_telephone")).textBox.ReadOnly = true;

            this._textBoxSearch += _loanScreenTop__textBoxSearch;
            this._textBoxChanged += _loanScreenTop__textBoxChanged;
        }

        private void _loanScreenTop__textBoxChanged(object sender, string name)
        {
            if (name.Equals("customer_code"))
            {
                string customerCode = this._getDataStr("customer_code");
                var customer = CustomerRepository.GetCustomerByCode(customerCode);
                if (customer != null)
                {
                    this._setDataStr("customer_name", customer.name_1);
                    this._setDataStr("customer_address", customer.address);
                    this._setDataStr("customer_telephone", customer.telephone);
                }
                else
                {
                    this._setDataStr("customer_name", "");
                    this._setDataStr("customer_address", "");
                    this._setDataStr("customer_telephone", "");
                }
            }
            else if (name.Equals("loan_type"))
            {
                string loanTypeCode = this._getDataStr("loan_type");
                var loanType = LoanTypeRepository.GetLoanTypeByCode(loanTypeCode);
                if (loanType != null)
                {
                    this._setDataStr("loan_type", loanType.code, loanType.name_1, true);

                }
            }
            else if (name.Equals("route"))
            {
                string routeCode = this._getDataStr("route");
                var route = RouteRepository.GetRouteByCode(routeCode);
                if (route != null)
                {
                    this._setDataStr("route", route.code, route.name_1, true);

                }
            }
        }

        private void _loanScreenTop__textBoxSearch(object sender, string name)
        {

            if (name.Equals("customer_name"))
            {
                SearchCustomerForm searchCustomerForm = new SearchCustomerForm();
                searchCustomerForm.AfterSelectData += (rowData) =>
                {
                    this._setDataStr("customer_code", rowData["code"].ToString());
                    //this._setDataStr("customer_name", rowData["name_1"].ToString());
                    //this._setDataStr("customer_telephone", rowData["telephone"].ToString());
                    searchCustomerForm.Close();
                };

                searchCustomerForm.ShowDialog();
            }
            else if (name.Equals("loan_type"))
            {
                SearchLoanTypeForm searchLoanTypeForm = new SearchLoanTypeForm();
                searchLoanTypeForm.AfterSelectData += (rowData) =>
                {
                    this._setDataStr("loan_type", rowData["code"].ToString());
                    searchLoanTypeForm.Close();
                };
                searchLoanTypeForm.ShowDialog();
            }
            else if (name.Equals("route"))
            {
                SearchRouteForm searchRouteForm = new SearchRouteForm();
                searchRouteForm.AfterSelectData += (rowData) =>
                {
                    this._setDataStr("route", rowData["code"].ToString());
                    searchRouteForm.Close();
                };
                searchRouteForm.ShowDialog();
            }
        }

        private Boolean _isLockScreen = false;
        public Boolean LockScreen
        {
            get
            {
                return this._isLockScreen;
            }
            set
            {
                this._isLockScreen = value;
                foreach (var getControl in this.Controls)
                {
                    if (getControl is SMLControl._myTextBox)
                    {
                        SMLControl._myTextBox getTextbox = (SMLControl._myTextBox)getControl;

                        getTextbox.textBox.ReadOnly = value;
                    }
                }
            }
        }

    }
}
