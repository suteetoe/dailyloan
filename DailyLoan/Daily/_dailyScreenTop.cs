using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Daily
{
    public class _dailyScreenTop : SMLControl._myScreen
    {
        public _dailyScreenTop()
        {
            this._maxColumn = 3;

            this.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "contract_date", FieldName = "วันที่" });
            this.AddTextField(new SMLControl.TextField() { Row = 0, Column = 1, FieldCode = "route", FieldName = "สาย", MaxLength = 50 });
            this._addButton(0, 2, 1, "เรียกข้อมูล");
        }
    }
}
