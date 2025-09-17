using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class DateField : BaseField
    {
        public Boolean Required { get; set; }

        public Boolean IsQuery { get; set; } = true;
    }
}
