using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class Holiday
    {
        public const string TABLE_NAME = "mst_holiday";

        public DateTime holiday_date { get; set; }

        public String remark { get; set; }


    }
}
