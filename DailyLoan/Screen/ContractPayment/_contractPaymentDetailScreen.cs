using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.ContractPayment
{
    public class _contractPaymentDetailScreen : SMLControl._myScreen

    {
        public _contractPaymentDetailScreen()
        {
            this._maxColumn = 1;
            this.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "doc_date", FieldName = "วันที่เอกสาร", Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "doc_no", FieldName = "เลขที่เอกสาร", Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = 2, Column = 0, FieldCode = "contract_no", FieldName = "สัญญาเลขที่", Required = true, IsSearch = true });
            this.AddTextField(new SMLControl.TextField() { Row = 3, Column = 0, FieldCode = "customer", FieldName = "ลูกค้า", Required = true, IsSearch = true });
            this.AddNumberField(new SMLControl.NumberField() { Row = 4, Column = 0, FieldCode = "total_amount", FieldName = "จำนวนเงิน", Required = true });
        }

        public void LoadContractPayData(Data.Models.ContractPay data)
        {
            this._setDataDate("doc_date", data.doc_date);
            this._setDataStr("doc_no", data.doc_no);
            this._setDataStr("contract_no", data.contract_no);
            this._setDataStr("customer", data.contract.customer_code, data.contract.customer.name_1, true);
            this._setDataNumber("total_amount", data.total_amount);


        }
    }
}
