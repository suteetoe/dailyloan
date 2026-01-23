using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReportRender
{
    public class test_sml_screen : SMLControl._myScreen
    {
        public test_sml_screen()
        {
            this._maxColumn = 2;
            int row = 0;
            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "line_0_0", FieldName = "line_0_0", MaxLength = 100 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "line_0_1", FieldName = "line_0_1", MaxLength = 100 });

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "line_1_0", FieldName = "line_1_0", MaxLength = 100 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "line_1_1", FieldName = "line_1_1", MaxLength = 100 });


            this.AddDateField(new SMLControl.DateField() { Row = row, Column = 0, FieldCode = "contract_date", FieldName = "วันที่", Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "contract_no", FieldName = "เลขที่สัญญา", Required = true, IsAutoUpper = true });

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "loan_type", FieldName = "ประเภทเงินกู้", IsSearch = true, ColumnSpan = 1, Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 1, FieldCode = "route_code", FieldName = "สาย", MaxLength = 50, IsSearch = true, Required = true });
            row++;

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_name", FieldName = "ลูกค้า", IsSearch = true, ColumnSpan = 2 });
            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_code", FieldName = "รหัสลูกค้า", MaxLength = 50 });
            row++;

            this.AddTextField(new SMLControl.TextField() { Row = row, Column = 0, FieldCode = "customer_address", FieldName = "ที่อยู่", RowSpan = 2, ColumnSpan = 2 });
            row += 2;

            this.AddNumberField(new SMLControl.NumberField() { Row = row++, Column = 0, ColumnSpan = 1, FieldCode = "principle_amount", FieldName = "เงินต้น", Required = true });
            this.AddNumberField(new SMLControl.NumberField() { Row = row, Column = 0, FieldCode = "interest_rate", FieldName = "ดอกเบี้ย (%)" });
            this.AddNumberField(new SMLControl.NumberField() { Row = row++, Column = 1, FieldCode = "total_interest", FieldName = "ดอกเบี้ยรวม", Required = true });

            this.AddTextField(new SMLControl.TextField() { Row = row++, Column = 0, FieldCode = "customer_telephone", FieldName = "โทรศัพท์", MaxLength = 100 });


        }
    }
}
