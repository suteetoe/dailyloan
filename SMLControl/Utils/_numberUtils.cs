using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl.Utils
{
    public class _numberUtils
    {
        public static decimal _decimalPhase(string value)
        {
            decimal __getValue = 0M;
            if (value != null && value.Length != 0)
            {
                decimal __value = 0M;
                if (Decimal.TryParse(value, out __value) == true)
                {
                    __getValue = __value;
                }
            }
            return __getValue;
        }

        public static int _intPhase(string value)
        {
            int __getValue = 0;
            if (value.Length != 0)
            {
                try
                {
                    int __value = 0;
                    if (Int32.TryParse(value, out __value) == true)
                    {
                        __getValue = __value;
                    }
                    else
                    {
                        __getValue = (int)_decimalPhase(value);
                    }
                }
                catch
                {
                    __getValue = (int)_decimalPhase(value);
                }
            }
            return __getValue;
        }

        public static string _getFormatNumber(string format)
        {
            return format;
        }
    }
}
