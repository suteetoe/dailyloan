using DailyLoan.Domain;
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
            this.IsEdit = false;
            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "period_no", ColumnName = "งวด", WidthPercent = 10 });
            this.AddGridColumn(new GridDateColumn() { ColumnCode = "due_date", ColumnName = "วันที่", WidthPercent = 30 });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "amount", ColumnName = "จำนวนเงิน", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "pay_amount", ColumnName = "ชำระแล้ว", WidthPercent = 20, Format = numberFormat });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "over_due_amount", ColumnName = "ค้างชำระ", WidthPercent = 20, Format = numberFormat });
            this._total_show = true;
            this._calcPersentWidthToScatter();
            this.Invalidate();
        }

        public void LoadListPayPeriod(List<PayPeriod> payPeriods)
        {
            this._clear();

            foreach (var period in payPeriods)
            {
                int addRowIdx = this._addRow();
                this._cellUpdate(addRowIdx, "period_no", period.PeriodNumber, false);
                this._cellUpdate(addRowIdx, "due_date", period.PayDueDate, true);
                this._cellUpdate(addRowIdx, "amount", period.PayAmount, false);
            }
            this.Invalidate();
        }
    }
}
