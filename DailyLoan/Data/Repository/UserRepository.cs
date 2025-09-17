using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class UserRepository : RepositoryBase<User>
    {
        public UserRepository() : base()
        {
        }

        public User FindUserByUserCode(string userCode)
        {

            string query = "SELECT * FROM users where user_code = \'"+ userCode +"\' ";

            //var parameters = new Dictionary<string, object>();
            //parameters.Add("@user_code", userCode);

            var ds = connecton.QueryData(query);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                User user = new User();
                user.Id = Convert.ToInt32(row["id"]);
                user.Name = row["name"].ToString();
                user.UserCode = row["user_code"].ToString();
                user.Password = row["user_password"].ToString();
                user.UserRole = Convert.ToInt32(row["user_role"]);
                return user;
            }

            return null;
        }
    }
}
