using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public abstract class BaseField
    {
        public string FieldCode { get; set; }
        public string FieldName { get; set; }
        public int Row { get; set; } = 0;
        public int Column { get; set; } = 0;
        public int RowSpan { get; set; } = 1;
        public int ColumnSpan { get; set; } = 1;
        public Boolean ShowLabel { get; set; } = true;
    }
}
