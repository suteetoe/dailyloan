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

        /// <summary>
        /// รูปแบบตัวเลข เช่น "m0", "m2", "#,##0.00"
        /// </summary>
        public string NumberFormat { get; set; } = "";
    }
}
