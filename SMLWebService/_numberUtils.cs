using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLWebService
{
    public class _numberUtils
    {
        public static int _intPhase(string integerString)
        {
            try
            {
                return int.Parse(integerString);
            }
            catch
            {
                return 0;
            }
        }
    }
}
