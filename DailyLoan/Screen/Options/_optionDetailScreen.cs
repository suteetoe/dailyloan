using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.Options
{
    public class _optionDetailScreen : SMLControl._myScreen
    {
        public _optionDetailScreen()
        {
            this._maxColumn = 2;
            this.AddNumberField(new SMLControl.NumberField() { Row = 0, Column = 0, FieldCode = "npl_period", FieldName = "จำนวนวันค้างชำระ(NPL)" , NumberFormat = "m0"});
        }
    }
}
