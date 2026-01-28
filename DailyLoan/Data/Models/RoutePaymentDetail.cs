using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class RoutePaymentDetail
    {
        public const string TABLE_NAME = "txn_route_payment_detail";

        public String contract_no { get; set; }

        public decimal total_amount { get; set; }

        public string customer_code { get; set; }

        public string customer_name { get; set; }
    }
}
