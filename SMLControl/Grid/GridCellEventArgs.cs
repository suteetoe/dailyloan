using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    /// <summary>
    /// ในกรณีกดที่ Cell ทั้ง Before,After
    /// </summary>
    public class GridCellEventArgs : System.EventArgs
    {
        /// <summary>บรรทัดที่ (เริ่มนับจาก 0)</summary>
        public int _row;
        /// <summary>Column (เริ่มนับจาก 0)</summary>
        public int _column;
        /// <summary>ชื่อ Column</summary>
        public string _columnName;
        /// <summary>ในกรณีที่เป็นข้อความ</summary>
        public string _text;
        /// <summary>ในกรณีที่เป็นตัวเลข (ไม่มีทศนิยม)</summary>
        public int _int;
        /// <summary>ในการณีที่เป็นตัวเลข (มีทศนิยม)</summary>
        public int _double;
        /// <summary>ในการณีที่เป็น Object</summary>
        public object _object;
    }

    public class BeforeDisplayRowReturn
    {
        public Font newFont;
        public Color newColor;
        public Object newData;
        public ContentAlignment align = ContentAlignment.MiddleLeft;
    }

    public class _myGridMoveColumnType
    {
        public int _newRow;
        public int _newColumn;
    }

    public class QueryForInsertPerRowType
    {
        public string _field;
        public string _data;
    }
    public class _findColumnByNameListType
    {
        public string _name;
        public int _addr;
    }
}
