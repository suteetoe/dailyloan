using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.CompanyProfile
{
    public class _companyProfileDetailScreen : SMLControl._myScreen
    {
        public _companyProfileDetailScreen()
        {
            this._maxColumn = 1;
            this.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, FieldCode = "company_name", FieldName = "ชื่อบริษัท" });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "address", FieldName = "ที่อยู่", RowSpan = 3 });
            this.AddTextField(new SMLControl.TextField() { Row = 4, Column = 0, FieldCode = "telephone", FieldName = "โทรศัพท์", MaxLength = 100 });
        }
    }
}
