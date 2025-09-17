using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Daily
{
    public class _dailyGrid : SMLControl._myGrid
    {
        public _dailyGrid()
        {
            this.ShowTotal = true;
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "contract_no", ColumnName = "สัญญา", WidthPercent = 15 });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "customer", ColumnName = "ลูกค้า", WidthPercent = 45 });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "amount", ColumnName = "จำนวนเงิน", WidthPercent = 20, Format = "m02" });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "over_due_amount", ColumnName = "ค้างชำระ", WidthPercent = 20, Format = "m02" });
            this._calcPersentWidthToScatter();
            this.Invalidate();
        }
    }
}
