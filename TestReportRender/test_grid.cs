using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReportRender
{
    public class test_grid : SMLControl._myGrid
    {
        public test_grid()
        {
            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);
            this.AddGridColumn(new GridCheckBoxColumn() { ColumnCode = "selected", ColumnName = "S" });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "period_no", ColumnName = "งวด", WidthPercent = 10 });
            this.AddGridColumn(new GridDateColumn() { ColumnCode = "due_date", ColumnName = "วันที่", WidthPercent = 30 });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "amount", ColumnName = "จำนวนเงิน", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "over_due_amount", ColumnName = "ค้างชำระ", WidthPercent = 20, Format = numberFormat });
            this._total_show = true;
            this._calcPersentWidthToScatter();
            this.Invalidate();

        }
    }
}
