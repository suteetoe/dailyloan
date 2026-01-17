using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.Customer
{
    public class _customerDataScreen : SMLControl._myScreen
    {
        public _customerDataScreen()
        {
            this._maxColumn = 1;
            int row = 0;
            this.AddTextField(new SMLControl.TextField() { Row = row++, FieldCode = "code", FieldName = "รหัสลูกค้า" });
            this.AddTextField(new SMLControl.TextField() { Row = row++, FieldCode = "name_1", FieldName = "ชื่อลูกค้า" });
            this.AddTextField(new SMLControl.TextField() { Row = row, FieldCode = "address", FieldName = "ที่อยู่", RowSpan = 3 });
            row += 3;
            this.AddTextField(new SMLControl.TextField() { Row = row, FieldCode = "telephone", FieldName = "เบอร์โทรศัพท์" });
        }

        public void LoadCustomerData(Data.Models.Customer customer)
        {
            this._setDataStr("code", customer.code);
            this._setDataStr("name_1", customer.name_1);
            this._setDataStr("address", customer.address);
            this._setDataStr("telephone", customer.telephone);
        }

        public Data.Models.Customer GetCustomerModel()
        {
            Data.Models.Customer customer = new Data.Models.Customer();
            customer.code = this._getDataStr("code");
            customer.name_1 = this._getDataStr("name_1");
            customer.address = this._getDataStr("address");
            customer.telephone = this._getDataStr("telephone");
            return customer;

        }
    }
}
