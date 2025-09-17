using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class GroupBoxField : BaseField
    {
        public int ColumnCount { get; set; } = 1;

        public Boolean IsQuery { get; set; } = true;
    }
}
