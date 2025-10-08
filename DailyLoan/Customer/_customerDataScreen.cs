using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Customer
{
    public class _customerDataScreen : SMLControl._myScreen
    {
        public _customerDataScreen()
        {
            this._maxColumn = 1;
            int row = 0;
            this.AddTextField(new SMLControl.TextField() { Row = row++, FieldCode = "code", FieldName = "รหัสลูกค้า" });
            this.AddTextField(new SMLControl.TextField() { Row = row++, FieldCode = "name_1", FieldName = "ชื่อลูกค้า" });
            this.AddTextField(new SMLControl.TextField() { Row = row, FieldCode = "address", FieldName = "ที่อยู่", RowSpan = 3 });
            row += 3;
            this.AddTextField(new SMLControl.TextField() { Row = row, FieldCode = "telephone", FieldName = "เบอร์โทรศัพท์" });
        }
    }
}
