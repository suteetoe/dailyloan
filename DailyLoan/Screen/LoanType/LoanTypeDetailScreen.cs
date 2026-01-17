using SMLControl;
using SMLControl.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.LoanType
{
    public class LoanTypeDetailScreen : _myScreen
    {
        public LoanTypeDetailScreen()
        {
            this._maxColumn = 1;
            this.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, FieldCode = "code", FieldName = "รหัส", Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "name_1", FieldName = "ชื่อ", Required = true });

            var groupboxWorking = this.AddGroupBoxField(new SMLControl.GroupBoxField() { Row = 2, Column = 0, ColumnCount = 2, FieldCode = "working_holiday_type", FieldName = "วันทำการ" });
            this.AddRadioButtonField(groupboxWorking, new SMLControl.RadioButtonField()
            {
                Row = 0,
                Column = 0,
                FieldName = "จันทร์ - ศุกร์",
                Value = "1"
            });

            this.AddRadioButtonField(groupboxWorking, new SMLControl.RadioButtonField()
            {
                Row = 0,
                Column = 1,
                FieldName = "จันทร์ - เสาร์",
                Value = "2",
            });
        }

        public void LoadData(DailyLoan.Data.Models.LoanType loanType)
        {
            this._setDataStr("code", loanType.code);
            this._setDataStr("name_1", loanType.name_1);
            this._setGroupbox("working_holiday_type", loanType.working_holiday_type.ToString());
        }

        public DailyLoan.Data.Models.LoanType GetLoanTypeData()
        {
            var loanType = new DailyLoan.Data.Models.LoanType();
            loanType.code = this._getDataStr("code");
            loanType.name_1 = this._getDataStr("name_1");
            string getWorkDayType = this._getDataStr("working_holiday_type");
            loanType.working_holiday_type = _numberUtils._intPhase(getWorkDayType);

            return loanType;

        }
    }
}
