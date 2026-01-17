using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class Customer
    {
        public const string TABLE_NAME = "mst_customer";

        public string code { get; set; }
        public string name_1 { get; set; }
        public string address { get; set; }
        public string telephone { get; set; }
    }
}
