using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class User
    {
        public const string TABLE_NAME = "sys_users";

        public int Id { get; set; }
        public String Name { get; set; }
        public String UserCode { get; set; }
        public String Password { get; set; }
        public int UserRole { get; set; }

        public UserRole Role
        {
            get
            {
                return (UserRole)UserRole;
            }
        }
    }
}
