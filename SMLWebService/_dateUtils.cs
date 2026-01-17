using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLWebService
{
    public class _dateUtils
    {
        public static decimal _dateDiff(string howtocompare, System.DateTime startDate, System.DateTime endDate)
        {
            decimal __diff = 0;
            System.TimeSpan __ts = new System.TimeSpan(endDate.Ticks - startDate.Ticks);

            switch (howtocompare.ToLower())
            {
                case "year":
                    __diff = Convert.ToDecimal(__ts.TotalDays / 365);
                    break;
                case "month":
                    __diff = Convert.ToDecimal((__ts.TotalDays / 365) * 12);
                    break;
                case "day":
                    __diff = Convert.ToDecimal(__ts.TotalDays);
                    break;
                case "hour":
                    __diff = Convert.ToDecimal(__ts.TotalHours);
                    break;
                case "minute":
                    __diff = Convert.ToDecimal(__ts.TotalMinutes);
                    break;
                case "second":
                    __diff = Convert.ToDecimal(__ts.TotalSeconds);
                    break;
                case "millisecond":
                    __diff = Convert.ToDecimal(__ts.TotalMilliseconds);
                    break;
            }
            return __diff;
        }
    }
}
