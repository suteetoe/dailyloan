using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class ContractPeriodPaymentDetail
    {
        public string doc_no { get; set; }

        public DateTime doc_date { get; set; }

        public string doc_time { get; set; }

        public decimal amount { get; set; }
    }
}
