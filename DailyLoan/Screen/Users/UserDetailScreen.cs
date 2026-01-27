using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Screen.Users
{
    public class UserDetailScreen : SMLControl._myScreen
    {
        public UserDetailScreen()
        {
            List<string> rolesList = new List<string>()
            { "User", "Admin", "SuperAdmin" };

            string[] rolesValueList = new string[]
            { "0", "1", "2" };

            this._maxColumn = 1;
            this.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, FieldCode = "user_code", FieldName = "Username" });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "name_1", FieldName = "ชื่อ" });
            this.AddTextField(new SMLControl.TextField() { Row = 2, Column = 0, FieldCode = "user_password", FieldName = "Password", IsPassword = true });
            this.AddComboBoxField(new SMLControl.ComboBoxField() { Row = 3, Column = 0, LabelOptionsList = rolesList, FieldCode = "user_role", FieldName = "ระดับผู้ใช้งาน" });
        }

        public void LoadUserData(Data.Models.User user)
        {
            this._setDataStr("user_code", user.UserCode);
            this._setDataStr("name_1", user.Name);
            this._setDataStr("user_password", user.Password);

            int userRole = user.UserRole;
            this._setComboBox("user_role", userRole);
        }

        public Data.Models.User getUser()
        {
            Data.Models.User user = new Data.Models.User();
            user.UserCode = this._getDataStr("user_code");
            user.Name = this._getDataStr("name_1");
            user.Password = this._getDataStr("user_password");
            user.UserRole = (int)this._getDataNumber("user_role");

            return user;

        }
    }
}
