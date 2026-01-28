using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class RoutePayment
    {
        public const string TABLE_NAME = "txn_route_payment";

        public DateTime doc_date { get; set; }

        public string doc_time { get; set; }

        public string doc_no { get; set; }

        public String route_code { get; set; }

        public decimal total_route_amount { get; set; }

        public Route route { get; set; }
        public List<RoutePaymentDetail> Details { get; set; }
    }
}
