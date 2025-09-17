using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Loan
{
    public class _paymentPeriodGrid : SMLControl._myGrid
    {
        public _paymentPeriodGrid()
        {
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "period_no", ColumnName = "งวด", WidthPercent = 10 });
            this.AddGridColumn(new GridDateColumn() { ColumnCode = "due_date", ColumnName = "วันที่", WidthPercent = 30 });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "amount", ColumnName = "จำนวนเงิน", WidthPercent = 20, Format = "m02" });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "pay_amount", ColumnName = "ชำระแล้ว", WidthPercent = 20, Format = "m02" });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "over_due_amount", ColumnName = "ค้างชำระ", WidthPercent = 20, Format = "m02" });
            this._calcPersentWidthToScatter();
            this.Invalidate();
        }
    }
}
