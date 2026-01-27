using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SMLControl
{
    public class _myGlobal
    {
        public static bool _isDesignMode = true;
        public static Font _myFont = new Font("Tahoma", 9);
        public static _languageEnum _language = _languageEnum.Null;

        public static DateTime _workingDate = DateTime.Now;
        public static string _xmlHeader = "";
        public static Regex regexFormatNumberToStringChecker = new Regex("(.+);(.+);(.+)");

        public static string _resource(string text)
        {
            return text;
        }

        public static int _year_type = 0;

        public static int _year_add
        {
            get
            {
                if (_year_type == 1)
                    return 543;

                return 0;
            }
        }

        public static CultureInfo _cultureInfo()
        {
            return new CultureInfo((_year_type == 1) ? "th-TH" : "en-US");
        }

        public static string _convertStrToQuery(string str)
        {
            return str;
        }

        public static CultureInfo DisplayCulture = CultureInfo.CurrentCulture;
        public static CultureInfo SystemCulture = new CultureInfo("en-US");

        public static int DateCultureDiff()
        {
            if (DisplayCulture.Calendar != SystemCulture.Calendar)
            {
                return 543;
            }
            return 0;
        }
    }
}
