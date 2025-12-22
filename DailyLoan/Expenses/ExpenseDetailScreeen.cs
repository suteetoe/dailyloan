using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Expenses
{
    public class ExpenseDetailScreeen : _myScreen
    {
        public ExpenseDetailScreeen()
        {
            this._maxColumn = 1;
            this.AddDateField(new DateField() { Row = 0, Column = 0, FieldCode = "doc_date", FieldName = "วันที่เอกสาร" });
            this.AddTextField(new TextField() { Row = 1, Column = 0, FieldCode = "doc_no", FieldName = "เลขที่เอกสาร" });
            this.AddTextField(new TextField() { Row = 2, Column = 0, FieldCode = "remark", FieldName = "หมายเหตุ", RowSpan = 3 });
        }
    }
}
