using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class LoanType
    {
        public const string TABLE_NAME = "mst_loan_type";

        public String code { get; set; }

        public String name_1 { get; set; }

        public String working_days { get; set; }

        /// <summary>
        /// 1=จันทร์-ศุกร์, 2=จันทร์-เสาร์
        /// </summary>
        public int working_holiday_type { get; set; }
    }
}
