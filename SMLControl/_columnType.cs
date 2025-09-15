using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class _columnType
    {
        /// <summary>ชื่อ Column ที่ใช้แสดง</summary>
        public string _name;
        /// <summary>ชื่อดั้งเดิม</summary>
        public string _originalName;
        /// <summary>field สำหรับค้นหา (For DataList)</summary>
        public string _searchField;
        /// <summary>
        /// สำหรับการเรียงใน DataList
        /// </summary>
        public string _orderBy;
        /// <summary>
        /// ชื่อ Field
        /// </summary>
        public string _query;
        /// <summary>1=String,2=Integer,3=Decimal,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object</summary>
        public int _type;
        /// <summary>ความกว้างของ Column (%)</summary>
        public float _widthPercent;
        /// <summary>ความกว้างของ Column ได้จากการคำนวณ (แก้ไม่มีผลอะไร)</summary>
        public float _widthPoint;
        /// <summary>ความยาวของ string</summary>
        public int _maxLength;
        /// <summary>Column นี้ให้แก้ได้หรือไม่</summary>
        public bool _isEdit;
        /// <summary>ซ่อนหรือไม่</summary>
        public bool _isHide;
        /// <summary>ประกอบใน Query หรือไม่</summary>
        public bool _isQuery;
        /// <summary>รูปแบบของวันที่ หรือตัวเลข (DD/MM/YY, DD/MM/YYYY, ###,###.## , @@@@,@@@@.@@</summary>
        public string _format;
        /// <summary>ค้นหารายการอื่นๆ เพื่ออ้างอิง</summary>
        public bool _isSearch;
        /// <summary>เป็น Column ที่สามารถค้นหาได้</summary>
        public bool _isColumnFilter = true;
        /// <summary>
        /// แสดงยอดรวม
        /// </summary>
        public bool _totalDisplay;
        /// <summary>
        /// ยอดรวม (ฝากไว้)
        /// </summary>
        public decimal _total;
        /// <summary>
        /// สีพื้นของ Column
        /// </summary>
        public Color _backColor;
        /// <summary>
        /// มีสีพื้นหรือไม่
        /// </summary>
        public bool _backColorOn = false;
        public int _columnBegin;
        public int _columnEnd;
        /// <summary>
        /// ข้อความต่อท้าย Column Name
        /// </summary>
        public string _extraWord = "";
        /// <summary>
        /// ชื่อ Resource
        /// </summary>
        public string _resourceName = "";
        /// <summary>
        /// กรณีตัวเลข เป็นค่าบวกเสมอ
        /// </summary>
        public bool _plusOnly;
    }
}
