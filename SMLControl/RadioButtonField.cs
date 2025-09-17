using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class RadioButtonField : BaseField
    {
        public Boolean Checked { get; set; } = false;

        public String Value { get; set; } = "";
    }
}
