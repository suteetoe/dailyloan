using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class ContractPeriod
    {
        public const string TABLE_NAME = "txn_contract_period";

        public int id { get; set; }

        public int period_no { get; set; }

        public DateTime due_date { get; set; }

        public Decimal amount { get; set; }
    }
}
