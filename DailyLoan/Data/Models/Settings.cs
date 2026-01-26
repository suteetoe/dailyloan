using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class Settings
    {
        public const string TABLE_NAME = "sys_options";

        public int npl_period { get; set; }
    }
}
