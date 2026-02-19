using DocumentFormat.OpenXml.Spreadsheet;
using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Loan
{
    public class _changeContractStartDateScreenTop : _myScreen
    {
        public _changeContractStartDateScreenTop()
        {
            this._maxColumn = 2;

            this.AddTextField(new SMLControl.TextField() { Row =0, Column = 0, FieldCode = "contract_no", FieldName = "เลขที่สัญญา", Required = true, IsAutoUpper = true });
            this.AddDateField(new SMLControl.DateField() { Row = 1, Column = 0, FieldCode = "first_period_date", FieldName = "เริมชำระ", Required = true });
            this.AddDateField(new SMLControl.DateField() { Row = 1, Column = 1, FieldCode = "last_period_date", FieldName = "ครบกำหนด", Required = true });


            this.AddDateField(new SMLControl.DateField() { Row = 2, Column = 0, FieldCode = "new_first_period_date", FieldName = "เริมชำระ(ใหม่)", Required = true });
            this.AddDateField(new SMLControl.DateField() { Row = 2, Column = 1, FieldCode = "new_last_period_date", FieldName = "ครบกำหนด(ใหม่)", Required = true });

            this._enabedControl("contract_no", false);
            this._enabedControl("first_period_date", false);
            this._enabedControl("last_period_date", false);
            this._enabedControl("new_last_period_date", false);

        }
    }
}
