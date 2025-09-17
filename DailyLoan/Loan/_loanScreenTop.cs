using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMLControl;
namespace DailyLoan.Loan
{
    public class _loanScreenTop : SMLControl._myScreen
    {
        public _loanScreenTop()
        {
            this._maxColumn = 2;
            this.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "contract_date", FieldName = "วันที่" });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "contract_number", FieldName = "เลขที่สัญญา" });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 1, FieldCode = "route", FieldName = "สาย", MaxLength = 50 });
            this.AddTextField(new SMLControl.TextField() { Row = 2, Column = 0, FieldCode = "customer_code", FieldName = "ชื่อลูกค้า", IsSearch = true });
            this.AddTextField(new SMLControl.TextField() { Row = 2, Column = 1, FieldCode = "customer_name", FieldName = "รหัสลูกค้า" });
            this.AddTextField(new SMLControl.TextField() { Row = 3, Column = 0, FieldCode = "customer_address", FieldName = "ที่อยู่", RowSpan = 3, ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = 6, Column = 0, FieldCode = "customer_telephone", FieldName = "โทรศัพท์" });
            this.AddTextField(new SMLControl.TextField() { Row = 7, Column = 0, FieldCode = "product_group", FieldName = "กลุ่มสินค้า", ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = 8, Column = 0, FieldCode = "description", FieldName = "รายละเอียด", ColumnSpan = 2 });

            _myGroupBox groupBox = this.AddGroupBoxField(new SMLControl.GroupBoxField() { Row = 9, RowSpan = 1, ColumnSpan = 2, ColumnCount = 2, FieldCode ="loan_type", FieldName = "ประเภทเงินกู้" });

            this.AddRadioButtonField(groupBox, new SMLControl.RadioButtonField() { Row = 0, Column = 0, FieldCode = "daily_finance", FieldName = "รายวัน", Value = "0", Checked = true });
            this.AddRadioButtonField(groupBox, new SMLControl.RadioButtonField() { Row = 0, Column = 1, FieldCode = "asses_finance", FieldName = "จำนำ", Value = "1" });

            this.AddNumberField(new SMLControl.NumberField() { Row = 11, Column = 0, ColumnSpan = 1, FieldCode = "amount", FieldName = "เงินต้น" });
            this.AddNumberField(new SMLControl.NumberField() { Row = 12, Column = 0, FieldCode = "interest", FieldName = "ดอกเบี้ย (%)" });
            this.AddNumberField(new SMLControl.NumberField() { Row = 12, Column = 1, FieldCode = "total_interest", FieldName = "ดอกเบี้ยรวม"});

            this.AddNumberField(new SMLControl.NumberField() { Row = 13, Column = 0, FieldCode = "num_of_period", FieldName = "จำนวนวัน/งวด" });
            this.AddNumberField(new SMLControl.NumberField() { Row = 13, Column = 1, FieldCode = "amount_per_period", FieldName = "งวดละ" });
            this.AddNumberField(new SMLControl.NumberField() { Row = 14, Column = 0, FieldCode = "income_other", FieldName = "รายได้อื่น ๆ" });

            this.AddDateField(new SMLControl.DateField() { Row = 15, Column = 0, FieldCode = "first_period_date", FieldName = "เริมชำระ/ครบกำหนด" });

        }
    }
}
