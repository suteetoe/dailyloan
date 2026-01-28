using SMLControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.RoutePayment
{
    public class _routePaymentDetailGrid : SMLControl._myGrid
    {
        public _routePaymentDetailGrid()
        {
            this.ShowTotal = true;
            this.IsEdit = false;

            string numberFormat = SMLControl.Utils._numberUtils.BuildNumberFormat(2);


            this.AddGridColumn(new GridTextColumn() { ColumnCode = "contract_no", ColumnName = "สัญญา", WidthPercent = 20 });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "cust_code", ColumnName = "รหัสลูกค้า", WidthPercent = 15, IsHide = true });
            this.AddGridColumn(new GridTextColumn() { ColumnCode = "cust_name", ColumnName = "ลูกค้า", WidthPercent = 30 });
            this.AddGridColumn(new GridDecimalColumn() { ColumnCode = "amount", ColumnName = "จำนวนเงิน", WidthPercent = 20, Format = numberFormat });

            this._calcPersentWidthToScatter();
            this.Invalidate();
        }

        public void LoadRoutePayment(Data.Models.RoutePayment routePayment)
        {
            this._clear();

            if (routePayment != null)
            {
                foreach (var item in routePayment.Details)
                {
                    int addr = this._addRow();
                    this._cellUpdate(addr, "contract_no", item.contract_no, true);
                    this._cellUpdate(addr, "cust_name", item.customer_code + "~" + item.customer_name, true);
                    this._cellUpdate(addr, "amount", item.total_amount, true);
                }
            }
        }
    }
}
