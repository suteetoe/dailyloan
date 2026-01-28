using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Expenses
{
    public class ExpenseDetailScreeen : _myScreen
    {
        public ExpenseDetailScreeen()
        {
            this._maxColumn = 1;
            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);

            this.AddDateField(new DateField() { Row = 0, Column = 0, FieldCode = "doc_date", FieldName = "วันที่เอกสาร" });
            this.AddTextField(new TextField() { Row = 1, Column = 0, FieldCode = "doc_no", FieldName = "เลขที่เอกสาร" });
            this.AddTextField(new TextField() { Row = 2, Column = 0, FieldCode = "remark", FieldName = "หมายเหตุ", RowSpan = 3 });
            this.AddNumberField(new NumberField() { Row = 5, Column = 0, FieldCode = "total_amount", FieldName = "จำนวนเงิน", NumberFormat = numberFormat });
        }

        public Data.Models.Expense GetExpenseData()
        {
            Data.Models.Expense data = new Data.Models.Expense();
            data.doc_date = this._getDataDate("doc_date");
            data.doc_no = this._getDataStr("doc_no");
            data.remark = this._getDataStr("remark");
            data.total_amount = this._getDataNumber("total_amount");

            return data;

        }

        public void SetExpenseData(Data.Models.Expense data)
        {
            this._setDataDate("doc_date", data.doc_date);
            this._setDataStr("doc_no", data.doc_no);
            this._setDataStr("remark", data.remark);
            this._setDataNumber("total_amount", data.total_amount);
        }
    }
}
