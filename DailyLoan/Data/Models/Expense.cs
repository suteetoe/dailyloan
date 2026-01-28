using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class Expense
    {
        public const string TABLE_NAME = "txn_contract";

        public int id { get; set; }
        public DateTime doc_date { get; set; }

        public string doc_no { get; set; }

        public string remark { get; set; }

        public decimal total_amount { get; set; }

    }
}
