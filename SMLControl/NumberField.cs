using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class NumberField : BaseField
    {
        public int Digit { get; set; } = 2;
        public Boolean IsQuery { get; set; } = true;
        public Boolean Required { get; set; }
        public string NumberFormat { get; set; } = "";
    }
}
