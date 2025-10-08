using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyLoan.Customer;
using SMLControl;
namespace DailyLoan.Loan
{
    public class _loanScreenTop : SMLControl._myScreen
    {
        public _loanScreenTop()
        {
            this._maxColumn = 2;
            int row = 0;
            this.AddDateField(new SMLControl.DateField() { Row = row++, Column = 0, FieldCode = "contract_date", FieldName = "วันที่" });
            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "contract_number", FieldName = "เลขที่สัญญา" });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "route", FieldName = "สาย", MaxLength = 50 });

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_name", FieldName = "ลูกค้า", IsSearch = true, ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_code", FieldName = "รหัสลูกค้า", MaxLength = 50 });

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "customer_address", FieldName = "ที่อยู่", RowSpan = 3, ColumnSpan = 2 });
            row += 3;

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_telephone", FieldName = "โทรศัพท์", MaxLength = 100 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "product_group", FieldName = "กลุ่มสินค้า", ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "description", FieldName = "รายละเอียด", ColumnSpan = 2 });

            _myGroupBox groupBox = this.AddGroupBoxField(new SMLControl.GroupBoxField() { Row = row, RowSpan = 1, ColumnSpan = 2, ColumnCount = 2, FieldCode = "loan_type", FieldName = "ประเภทเงินกู้" });

            this.AddRadioButtonField(groupBox, new SMLControl.RadioButtonField() { Row = 0, Column = 0, FieldCode = "daily_finance", FieldName = "รายวัน", Value = "0", Checked = true });
            this.AddRadioButtonField(groupBox, new SMLControl.RadioButtonField() { Row = 0, Column = 1, FieldCode = "asses_finance", FieldName = "จำนำ", Value = "1" });
            row += 2;

            this.AddNumberField(new SMLControl.NumberField() { Row = row++, Column = 0, ColumnSpan = 1, FieldCode = "principle", FieldName = "เงินต้น", Required = true });
            this.AddNumberField(new SMLControl.NumberField() { Row = row, Column = 0, FieldCode = "interest", FieldName = "ดอกเบี้ย (%)" });
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
        }

        private void _loanScreenTop__textBoxSearch(object sender, string name)
        {

            if (name.Equals("customer_name"))
            {
                SearchCustomerForm searchCustomerForm = new SearchCustomerForm();
                searchCustomerForm.searchCustomerControl1.AfterSelectData += (rowData) =>
                {
                    this._setDataStr("customer_code", rowData["code"].ToString());
                    this._setDataStr("customer_name", rowData["name_1"].ToString());
                    this._setDataStr("customer_telephone", rowData["telephone"].ToString());
                    searchCustomerForm.Close();
                };

                searchCustomerForm.ShowDialog();
            }

        }


    }
}
