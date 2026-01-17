using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class Route
    {
        public const string TABLE_NAME = "mst_route";

        public String code { get; set; }

        public String name_1 { get; set; }
    }
}
