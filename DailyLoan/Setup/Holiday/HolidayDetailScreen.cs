using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Setup.Holiday
{
    public class HolidayDetailScreen : SMLControl._myScreen
    {
        public HolidayDetailScreen()
        {
            this._maxColumn = 1;
            this.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "date_holiday", FieldName = "วันที่" });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "remark", FieldName = "รายละเอียด" });
            this.AddTextField(new SMLControl.TextField() { Row = 2, Column = 0, FieldCode = "year", FieldName = "ประจำปี" });

            this._enabedControl("year", false);
        }
    }
}
