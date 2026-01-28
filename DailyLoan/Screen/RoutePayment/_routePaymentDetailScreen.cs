using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.RoutePayment
{
    public class _routePaymentDetailScreen : SMLControl._myScreen
    {
        public _routePaymentDetailScreen()
        {
            this._maxColumn = 1;
            this.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "doc_date", FieldName = "วันที่", Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "route", FieldName = "สาย", MaxLength = 50, IsSearch = true, Required = true });
        }

        public void LoadData(Data.Models.RoutePayment contractPay)
        {
            this._setDataDate("doc_date", contractPay.doc_date);
            this._setDataStr("route", contractPay.route.code, contractPay.route.name_1, true);
            this.Invalidate();
        }
    }
}
