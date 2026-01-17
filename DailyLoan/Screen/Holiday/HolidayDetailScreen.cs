using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.Holiday
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

        public void LoadHolidayData(DailyLoan.Data.Models.Holiday holiday)
        {
            this._setDataDate("date_holiday", holiday.holiday_date);
            this._setDataStr("remark", holiday.remark);
            this._setDataStr("year", holiday.holiday_date.Year.ToString());
        }

        public DailyLoan.Data.Models.Holiday GetHoliday()
        {
            var holiday = new DailyLoan.Data.Models.Holiday();
            holiday.holiday_date = this._getDataDate("date_holiday");
            holiday.remark = this._getDataStr("remark");
            return holiday;

        }
    }
}
