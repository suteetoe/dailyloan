using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.Employee
{
    public class EmployeeDetailScreen : SMLControl._myScreen
    {
        public EmployeeDetailScreen()
        {
            this._maxColumn = 1;
            this.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, FieldCode = "code", FieldName = "รหัสพนักงาน", Required = true, IsAutoUpper = true});
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "name_1", FieldName = "ชื่อพนักงาน", Required = true });
        }
    }
}
