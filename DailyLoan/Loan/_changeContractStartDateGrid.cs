using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Loan
{
    public class _changeContractStartDateGrid : _myGrid
    {
        public _changeContractStartDateGrid()
        {
            this._isEdit = false;
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "period_no", ColumnName = "งวด", WidthPercent = 20 });
            this.AddGridColumn(new GridDateColumn() { ColumnCode = "due_date", ColumnName = "วันที่", WidthPercent = 40 });
            this.AddGridColumn(new GridDateColumn() { ColumnCode = "due_date_new", ColumnName = "วันที่ใหม่", WidthPercent = 40 });

            this._calcPersentWidthToScatter();
            this.Invalidate();
        }
    }
}
