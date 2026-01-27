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
            this.IsEdit = false;

            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);

            this.AddGridColumn(new GridTextColumn() { ColumnCode = "contract_no", ColumnName = "สัญญา", WidthPercent = 20 });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "customer", ColumnName = "ลูกค้า", WidthPercent = 30 });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "amount", ColumnName = "จำนวนเงิน", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "over_due_amount", ColumnName = "ยอดค้างชำระ", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "pay_amount", ColumnName = "ยอดชำระ", WidthPercent = 20, Format = numberFormat });

            // hide
            this.AddGridColumn(new GridDateColumn() { ColumnCode = "due_date", ColumnName = "due_date", WidthPercent = 0, IsHide = true });


            this._calcPersentWidthToScatter();
            this.Invalidate();
        }
    }

    public class _dailyDueGrid : SMLControl._myGrid
    {
        public _dailyDueGrid()
        {
            this.ShowTotal = true;
            this.IsEdit = false;

            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);

            this.AddGridColumn(new GridTextColumn() { ColumnCode = "contract_no", ColumnName = "สัญญา", WidthPercent = 20 });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "cust_code", ColumnName = "รหัสลูกค้า", WidthPercent = 15, IsHide = true });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "cust_name", ColumnName = "ลูกค้า", WidthPercent = 30 });
            this.AddGridColumn(new GridIntegerColumn() { ColumnCode = "pay_count", ColumnName = "งวดที่ส่งแล้ว", WidthPercent = 10 });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "total_contract_amount", ColumnName = "ยอดทั้งสิ้น", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "contract_balance", ColumnName = "คงเหลือ", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "over_due_amount", ColumnName = "ยอดค้างชำระ", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "amount", ColumnName = "รายวัน", WidthPercent = 20, Format = numberFormat });

            // hide
            this.AddGridColumn(new GridDateColumn() { ColumnCode = "due_date", ColumnName = "due_date", WidthPercent = 0, IsHide = true });


            this._calcPersentWidthToScatter();
            this.Invalidate();

        }

    }

}
