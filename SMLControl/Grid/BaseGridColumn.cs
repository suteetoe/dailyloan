using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public abstract class BaseGridColumn
    {
        public String ColumnCode { get; set; } = string.Empty;
        public String ColumnName { get; set; } = String.Empty;
        public int WidthPercent { get; set; } = 10;
        public Boolean IsEdit { get; set; } = true;
        public Boolean IsHide { get; set; } = false;
        public Boolean IsQuery { get; set; } = true;
        public Boolean IsSearch { get; set; } = false;
        public int MaxLength { get; set; } = 255;

        /// <summary>
        /// 1=String,2=Integer,3=Decimal,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object
        /// </summary>
        protected int _columnTypeNumber = 0;

        /// <summary>
        /// 1=String,2=Integer,3=Decimal,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object
        /// </summary>
        public int ColumnType
        {
            get { return _columnTypeNumber; }
        }

        public String Format { get; set; } = "";

        public String ExtraWord { get; set; } = "";

        public String SearchFieldName { get; set; } = "";

    }
}
