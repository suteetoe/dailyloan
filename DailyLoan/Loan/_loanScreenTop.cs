using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "contract_no", FieldName = "เลขที่สัญญา", Required = true, IsAutoUpper = true });

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "loan_type", FieldName = "ประเภทเงินกู้", IsSearch = true, ColumnSpan = 1, Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "route_code", FieldName = "สาย", MaxLength = 50, IsSearch = true, Required = true });
            row++;

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_name", FieldName = "ลูกค้า", IsSearch = true, ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_code", FieldName = "รหัสลูกค้า", MaxLength = 50 });

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "customer_address", FieldName = "ที่อยู่", RowSpan = 2, ColumnSpan = 2 });
            row += 2;

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_telephone", FieldName = "โทรศัพท์", MaxLength = 100 });
            // this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "product_group", FieldName = "กลุ่มสินค้า", ColumnSpan = 2 });

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

            this.AddDateField(new SMLControl.DateField() { Row = row, Column = 0, FieldCode = "first_period_date", FieldName = "เริมชำระ", Required = true });
            this.AddDateField(new SMLControl.DateField() { Row = row++, Column = 1, FieldCode = "last_period_date", FieldName = "ครบกำหนด", Required = true });


            ((SMLControl._myTextBox)this._getControl("customer_name")).textBox.ReadOnly = true;
            ((SMLControl._myTextBox)this._getControl("customer_code")).textBox.ReadOnly = true;
            ((SMLControl._myTextBox)this._getControl("customer_address")).textBox.ReadOnly = true;
            ((SMLControl._myTextBox)this._getControl("customer_telephone")).textBox.ReadOnly = true;

            this._enabedControl("last_preiod_date", false);

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
            else if (name.Equals("route_code"))
            {
                string routeCode = this._getDataStr("route_code");
                var route = RouteRepository.GetRouteByCode(routeCode);
                if (route != null)
                {
                    this._setDataStr("route_code", route.code, route.name_1, true);

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

                this.StartSearchForm(searchLoanTypeForm, "loan_type");
                //searchLoanTypeForm.ShowDialog();
            }
            else if (name.Equals("route_code"))
            {
                SearchRouteForm searchRouteForm = new SearchRouteForm();
                searchRouteForm.AfterSelectData += (rowData) =>
                {
                    this._setDataStr("route_code", rowData["code"].ToString());
                    searchRouteForm.Close();
                };
                this.StartSearchForm(searchRouteForm, "route_code");

                //searchRouteForm.ShowDialog();
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
                this.ReadOnly = value;
              
            }
        }

        public Data.Models.LoanType getLoanType()
        {

            string loanTypeCode = this._getDataStr("loan_type");
            var loanType = LoanTypeRepository.GetLoanTypeByCode(loanTypeCode);
            if (loanType != null)
            {
                return loanType;
            }
            return null;
        }

        public Data.Models.Contract GetContractModel()
        {
            Data.Models.Contract contract = new Data.Models.Contract();
            contract.contract_date = this._getDataDate("contract_date");
            contract.contract_no = this._getDataStr("contract_no");

            contract.loan_type = this._getDataStr("loan_type");
            contract.route_code = this._getDataStr("route_code");

            contract.customer_code = this._getDataStr("customer_code");
            contract.description = this._getDataStr("description");
            contract.principle_amount = this._getDataNumber("principle_amount");
            contract.interest_rate = this._getDataNumber("interest_rate");
            contract.total_interest = this._getDataNumber("total_interest");
            contract.num_of_period = (int)this._getDataNumber("num_of_period");
            contract.amount_per_period = this._getDataNumber("amount_per_period");
            contract.first_period_date = this._getDataDate("first_period_date");
            contract.last_period_date = this._getDataDate("last_period_date");
            return contract;
        }

        public void LoadContractData(Data.Models.Contract contract)
        {
            this._setDataDate("contract_date", contract.contract_date);
            this._setDataStr("contract_no", contract.contract_no);
            this._setDataStr("description", contract.description);
            this._setDataNumber("principle_amount", contract.principle_amount);
            this._setDataNumber("interest_rate", contract.interest_rate);
            this._setDataNumber("total_interest", contract.total_interest);
            this._setDataNumber("num_of_period", contract.num_of_period);
            this._setDataNumber("amount_per_period", contract.amount_per_period);
            this._setDataDate("first_period_date", contract.first_period_date);
            this._setDataStr("loan_type", contract.loan_type);
            this._setDataStr("route_code", contract.route_code);
            this._setDataStr("customer_code", contract.customer_code);
            this._setDataDate("last_period_date", contract.last_period_date);
        }
    }
}
