using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class ContractPay
    {
        public const string TABLE_NAME = "txn_payment";

        public int id { get; set; }

        public String doc_no { get; set; }

        public DateTime doc_date { get; set; }

        public string doc_time { get; set; }

        // public string cust_code { get; set; }

        public String contract_no { get; set; }

        public decimal total_amount { get; set; }

        public Contract contract { get; set; }

    }
}
