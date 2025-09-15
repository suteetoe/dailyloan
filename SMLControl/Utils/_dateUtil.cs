using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl.Utils
{
    public class _dateUtil
    {
        public static string _convertDateToString(DateTime date)
        {
            _dateUtil utils = new _dateUtil(_myGlobal._cultureInfo());
            string dateString = utils._convertDateToString(date, "d/M/yyyy");
            return dateString;
        }

        public static string _convertDateToQuery(DateTime date)
        {
            string __result = "";
            try
            {
                if (date.CompareTo(new DateTime(1900, 1, 1)) < 0)
                {
                    __result = "1900-1-1";
                }
                else
                {
                    __result = date.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
                }
            }
            catch
            {
                __result = "1900-1-1";
            }
            return (__result);
        }

        private CultureInfo _culture;

        public _dateUtil(CultureInfo culture)
        {
            this._culture = culture;
        }


        public string _convertDateToString(DateTime myDateTime, string formatStr)
        {
            StringBuilder __result = new StringBuilder();
            __result.Append((myDateTime.Year <= 1000) ? "" : myDateTime.ToString(formatStr, this._culture));
            return __result.ToString();
        }

    }
}
