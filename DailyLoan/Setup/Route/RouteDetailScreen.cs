using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Setup.Route
{
    public class RouteDetailScreen : SMLControl._myScreen
    {
        public RouteDetailScreen()
        {
            this._maxColumn = 1;
            this.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, FieldCode = "code", FieldName = "รหัสสาย" });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "name_1", FieldName = "ชื่อสาย" });
        }
    }
}
