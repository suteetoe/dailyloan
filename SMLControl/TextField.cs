using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class TextField : BaseField
    {
        public int MaxLength { get; set; } = 255;

        public Boolean IsSearch { get; set; }

        public Boolean IsPassword { get; set; }

        public Boolean Required {  get; set; }

        public Boolean IsQuery { get; set; } = true;

        public Boolean IsGetData { get; set; } = true;

        public Boolean IsTabStop { get; set; } = false;

        public String SearchScreenName { get; set; } = "";

        public int IconNumber
        {
            get
            {
                if (IsSearch)
                {
                    return 1;
                }
                return 0;
            }
        }

    }
}
