﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public partial class _myGrid : UserControl
    {
        #region Grid Field-Properties
        /// <summary>
        /// Auto Upper สำหรับ search field 
        /// </summary>
        public Boolean _autoUpperSearchString = true;
        /// <summary>
        /// กำลัง Import ข้อมูล
        /// </summary>
        public Boolean _importWorking = false;
        /// <summary>
        /// ให้ event mouse click ทำงาน
        /// </summary>
        public Boolean _mouseClickEnable = true;
        /// <summary>
        /// เอาไว้ต่อท้ายสำหรับ Grid ที่ติดต่อฐานข้อมูล
        /// </summary>
        public string _rowNumberName = "roworder";
        /// <summary>
        /// เอาไว้ใช้ทั่วไป
        /// </summary>
        public string _temp1 = "grid_temp1";
        /// <summary>
        /// ใช้ระบบ RowNumber (ติดต่อฐานข้อมูลเพื่อ Update,Delete)
        /// </summary>
        public bool _rowNumberWork = false;
        /// <summary>
        /// เอาไว้เก็บ RowNumber ต้นฉบับเพื่อเปรียบเทียบเมื่อทำการ Update
        /// </summary>
        private ArrayList _rowNumberList = new ArrayList();
        /// <summary>
        /// เก็บรายละเอียด Column ทั้หมด จะดึงต้อใช้ _columnType ดึง
        /// </summary>
        public ArrayList _columnList = new ArrayList();
        /// <summary>ที่เก็บข้อมูลของ DataGrid ดึงไปใช้ตรงๆก็ได้ ส่วนมากจะใช้ในการนับจำนวนบรรทัด</summary>
        public ArrayList _rowData = new ArrayList();
        public Boolean _vScrollBarLock = false;
        int[] _columnLine = new int[5000];
        int _columnLineMax = -1;
        bool _columnSplitMode = false;
        bool _columnSplitActive = false;
        int _columnSplitAddr = 0;
        int _columnSplitFirstValue = 0;
        int _columnSplitMoveValue = 0;
        Boolean _drawing = false;
        System.Drawing.Text.TextRenderingHint _textRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
        public Object _lastControl = null;
        /// <summary>
        /// เอาไว้ใช้แยกว่า เป็น Grid อะไร (Programmer เอาไปใช้เอง)
        /// </summary>
        public int _gridType = 0;
        /// <summary>
        /// เพิ่มบรรทัดใหม่ได้หรือไม่
        /// </summary>
        public bool _addRowEnabled = true;
        /// <summary>ตำแหน่งของ Column เริ่มต้น</summary>
        public int _columnFirst = 0;
        /// <summary>ตัวบวกสำหรับ Line Number (ในกรณี Next page)</summary>
        public int _rowStartNumber = 0;
        /// <summary>ตำแหน่งของ Row เริ่มต้น</summary>
        public int _rowFirst = 0;
        private Color _columnBackgroundBeginAuto = Color.FromArgb(250, 251, 252);
        private Color _columnBackgroundEndAuto = Color.FromArgb(214, 217, 227);
        /// <summary>สีของ Column (ด้านบน,ด้านข้างซ้าย)</summary>
        public Color _columnBackground = Color.FromArgb(250, 251, 252);
        /// <summary>สีของ Column (ด้านบน,ด้านข้างซ้าย)</summary>
        public Color _columnBackgroundEnd = Color.FromArgb(214, 217, 227);
        /// <summary>
        /// สี Background Column อัตโนมัติ
        /// </summary>
        public bool _columnBackgroundAuto = true;
        /// <summary>สีพื้น Row เลขคี่</summary>
        public Color _RowBackground1 = Color.Snow;
        /// <summary>สีพื้น Row เลขคู่</summary>
        public Color _RowBackground2 = Color.White;
        /// <summary>ความสูงของ Cell (ต่อบรรทัด)</summary>
        public float _cellHeight = 16;
        /// <summary>ตำแหน่งปัจจุบัน (Row)</summary>
        public int _selectRowTemp = -1;
        public int _selectRowOldPositon = -1;
        /// <summary>ตำแหน่งปัจจุบัน (Column)</summary>
        public int _selectColumn = -1;
        /// <summary>บรรทัดที่ Mouse เลื่อนไป</summary>
        public int _selectRowFromMouse = -1;
        public int _selectColumnFromMouse = -1;
        public int _selectRowFromMouseLast = -1;
        /// <summary>ในกรณีมีการแก้ไขใน grid เอาไว้ใช้เตือนผู้ใช้เวลาแก้แล้วยังไม่ save แต่จะจบโปรแกรม</summary>
        public bool _isChange = false;
        /// <summary>สามารถแก้ไขได้ (มี 2 mode คือ แก้ไขได้ และดูอย่างเดียวเพิ่มเลือกว่าจะเอาบรรทัดไหน</summary>
        public bool _isEdit = true;
        /// <summary>ต้องการดึงชื่อ Column จากระบบ Resource</summary>
        public bool _getResource = true;
        /// <summary>ในกรณีดึง Report ต้องระบุชื่อ Table ด้วย จะได้หาชื่อจาก Database พบ</summary>
        public string _table_name = "";
        /// <summary>
        /// ชื่อฐานข้อมูล ไม่มีก็ได้
        /// </summary>
        public string _database_name = "";
        /// <summary>คำนวณความกว้าง Column แบบ %</summary>
        public bool _width_by_persent = true;
        /// <summary>
        /// แสดงหมายเลขบรรทัด
        /// </summary>
        public bool _displayRowNumber = true;
        /// <summary>
        /// ตำแหน่งเริ่มต้นของ Grid (แนวนอน)
        /// </summary>
        public int _displayStartY = 41;
        /// <summary>
        /// แสดงยอดรวม
        /// </summary>
        public bool _total_show = false;
        /// <summary>
        /// จำนวนรายการที่แสดงสูงสุด (ในหน้าปัจจุบัน)
        /// </summary>
        public int _maxDataRow = 0;
        /// <summary>
        /// เอาไว้เก็บข้อมูลอื่นๆ ที่อยากจะส่งต่อในกรณี Drag Drop
        /// </summary>
        public ArrayList _extraArray = new ArrayList();
        /// <summary>
        /// จำนวนบรรทัดต่อหนึ่งหน้า
        /// </summary>
        public int _rowPerPage = 0;
        public bool _processKeyEnable = true;
        public bool _showMenuInsertAndDeleteRow = false;
        private Boolean _extraWordShowTemp = true;
        /// <summary>
        /// แสดงข้อความด้านล่าง
        /// </summary>
        public string _message = "";
        /// <summary>
        /// _myTextBox ที่ใช้ใน Grid (กรณีต้องการเพิ่ม Event)
        /// </summary>
        public _myTextBox _inputTextBox = new _myTextBox();
        /// <summary>
        /// _myNumberBox ใช้ใน Grid (กรณีต้องการเพิ่ม Event)
        /// </summary>
        public _myNumberBox _inputNumberBox = new _myNumberBox(1);
        /// <summary>
        /// _myDateBox  ใช้ใน Grid (กรณีต้องการเพิ่ม Event)
        /// </summary>
        public _myDateBox _inputDateBox = new _myDateBox();
        /// <summary>
        /// _myComboBox ใช้ใน Grid (กรณีต้องการเพิ่ม Event)
        /// </summary>
        public _myComboBox _inputComboBox = new _myComboBox();
        //

        //
        /// <summary>
        /// หัว Column
        /// </summary>
        public bool _columnTopActive = false;
        /// <summary>
        /// หัวบนสุด
        /// </summary>
        public ArrayList _columnListTop = new ArrayList();

        public Boolean _stopMove = false;
        //
        private List<_findColumnByNameListType> _findColumnByNameList = new List<_findColumnByNameListType>();

        public Font _fixFont = null;

        public Boolean _autoInsertResource = true;
        int _countColumnOver = 0;


        #region Helpe rGrid Action Variable

        /// <summary>
        /// กด Mouse ค้าง
        /// </summary>
        bool _mouseIsDown = false;

        /// <summary>
        /// 
        /// </summary>
        bool _mouseIsDrag = false;

        public int _lastSelectRow = -1;
        public int _lastSelectColumn = -1;

        /// <summary>
        /// ปุ่มที่กดล่าสุด
        /// </summary>
        public Keys _lastKeyData;

        #endregion



        public List<_myGridCell> selectedCell = new List<_myGridCell>();
        public Boolean displayCellHoverHighlight = false;
        public Boolean showSelectedCellHighlight = false;
        public Color highlightColor = Color.Indigo;


        private Boolean _showImportToolstrip = true;


        bool _disableCalTotal = false;

        public GridRowData _getRowData(int row)
        {
            GridRowData value = new GridRowData();

            for (int col = 0; col < this._columnList.Count; col++)
            {
                _columnType __column = (_columnType)this._columnList[col];
                object data = ((ArrayList)this._rowData[row])[col];
                value.Add(__column._originalName, data);
            }

            return value;
        }



        #region Grid Properties

        public Font _getFont
        {
            get
            {
                if (_fixFont != null)
                {
                    return _fixFont;
                }
                return new System.Drawing.Font(_myGlobal._myFont.FontFamily, _myGlobal._myFont.Size);
            }
        }

        public Boolean AllowImportDataToGrid
        {
            get
            {
                return _showImportToolstrip;
            }
            set
            {
                _showImportToolstrip = value;
                //this._importFromTextFileFastToolStripMenuItem.Visible = value;
                //this._importFromTextFileToolStripMenuItem.Visible = value;
            }
        }

        public int _selectRow
        {
            set
            {
                this._selectRowTemp = value;
                if (this._selectRowOldPositon != this._selectRowTemp)
                {
                    this._selectRowOldPositon = this._selectRowTemp;
                    if (this._afterSelectRow != null)
                    {
                        this._afterSelectRow(this, this._selectRowTemp);
                    }
                }
            }
            get
            {
                return this._selectRowTemp;
            }
        }

        /// <summary>
        /// แสดงข้อความต่อท้ายหรือไม่ (Column Name)
        /// </summary>
        public Boolean _extraWordShow
        {
            set
            {
                this._extraWordShowTemp = value;
                this.Invalidate();
            }
            get
            {
                return this._extraWordShowTemp;
            }
        }

        public int _getTopY
        {
            get
            {
                return (this._columnTopActive) ? ((this._isEdit) ? (int)this._cellHeight + 2 : (int)this._cellHeight) : 0;
            }
        }

        public int SelectRow
        {
            get
            {
                return this._selectRow;
            }
        }

        /// <summary>
        /// แสดงหมายเลขบรรทัด
        /// </summary>
        [Category("_SML")]
        [Description("แสดงหมายเลขบรรทัด")]
        [DefaultValue(true)]
        public bool DisplayRowNumber
        {
            get
            {
                return _displayRowNumber;
            }
            set
            {
                _displayRowNumber = value;
                this.Invalidate();
            }
        }

        [Category("_SML")]
        [Description("ความละเอียดของตัวอักษร ตอนวาด")]
        [DefaultValue(System.Drawing.Text.TextRenderingHint.SystemDefault)]
        public System.Drawing.Text.TextRenderingHint TextRenderingHint
        {
            get
            {
                return this._textRenderingHint;
            }
            set
            {
                this._textRenderingHint = value;
            }
        }

        /// <summary>
        /// สีพื้นหลัง (หมายเลขบรรทัด)
        /// </summary>
        [Category("_SML")]
        [Description("สีพื้นหลัง (อัตโนมัติ)")]
        [DefaultValue(true)]
        public bool ColumnBackgroundAuto
        {
            get
            {
                return _columnBackgroundAuto;
            }
            set
            {
                _columnBackgroundAuto = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// สีพื้นหลัง (หมายเลขบรรทัด)
        /// </summary>
        [Category("_SML")]
        [Description("สีพื้นหลัง (หมายเลขบรรทัด)")]
        [DefaultValue(typeof(Color), "Honeydew")]
        public Color ColumnBackground
        {
            get
            {
                return _columnBackground;
            }
            set
            {
                _columnBackground = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// สีพื้นหลัง (หมายเลขบรรทัด)
        /// </summary>
        [Category("_SML")]
        [Description("สีพื้นหลัง (หมายเลขบรรทัด)")]
        [DefaultValue(typeof(Color), "Honeydew")]
        public Color ColumnBackgroundEnd
        {
            get
            {
                return _columnBackgroundEnd;
            }
            set
            {
                _columnBackgroundEnd = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// สีพื้นหลัง เลขคี่ (บรรทัด)
        /// </summary>
        [Category("_SML")]
        [Description("สีพื้นหลัง เลขคี่ (บรรทัด)")]
        [DefaultValue(typeof(Color), "Snow")]
        public Color RowOddBackground
        {
            get
            {
                return _RowBackground1;
            }
            set
            {
                _RowBackground1 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// สีพื้นหลัง เลขคู่ (บรรทัด)
        /// </summary>
        [Category("_SML")]
        [Description("สีพื้นหลัง เลขคู่ (บรรทัด)")]
        [DefaultValue(typeof(Color), "White")]
        public Color RowEvenBackground
        {
            get
            {
                return _RowBackground2;
            }
            set
            {
                _RowBackground2 = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// แก้ไขได้หรือไม่
        /// </summary>
        [Category("_SML")]
        [Description("แก้ไขได้หรือไม่")]
        [DefaultValue(true)]
        public bool IsEdit
        {
            get
            {
                return this._isEdit;
            }
            set
            {
                this._isEdit = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// เพิ่มบรรทัดใหม่ได้หรือไม่
        /// </summary>
        [Category("_SML")]
        [Description("เพิ่มบรรทัดใหม่ได้หรือไม่")]
        [DefaultValue(true)]
        public bool AddRow
        {
            get
            {
                return _addRowEnabled;
            }
            set
            {
                _addRowEnabled = value;
            }
        }

        /// <summary>
        /// ความกว้างเป็น % หรือตายตัว
        /// </summary>
        [Category("_SML")]
        [Description("ความกว้างเป็น % หรือตายตัว")]
        [DefaultValue(true)]
        public bool WidthByPersent
        {
            get
            {
                return _width_by_persent;
            }
            set
            {
                _width_by_persent = value;
                this.Invalidate();
            }
        }

        /// <summary>
        /// แสดงยอดรวมไว้ด้านล่าง
        /// </summary>
        [Category("_SML")]
        [Description("แสดงยอดรวมไว้ด้านล่าง")]
        [DefaultValue(false)]
        public bool ShowTotal
        {
            get
            {
                return _total_show;
            }
            set
            {
                _total_show = value;
                this.Invalidate();
            }
        }


        #endregion

        public event beforeAddRowHandler _beforeAddRow;
        public event MouseClickHandler _mouseClick;
        public event MouseClickHandler _mouseClickHeader;
        public event MouseClickHandler _mouseClick2;
        /// <summary>
        /// On Click Column Object
        /// </summary>
        public event ClipMouseClickHandler _mouseClickClip;
        public event MouseDoubleClickHandler _mouseDoubleClick;
        public event SearchEventHandler _clickSearchButton;
        public event AfterCellUpdateEventHandler _alterCellUpdate;
        public event BeforeCellUpdateEventHandler _beforeCellUpdate;
        public event CellComboBoxItemEventHandler _cellComboBoxItem;
        public event CellComboBoxItemGetDisplay _cellComboBoxGet;
        public event AfterAddRowEventHandler _afterAddRow;
        public event AfterSelectRowEventHandler _afterSelectRow;
        public event KeyDownEventHandler _keyDown;
        public event BeforeDisplayRowEventHandler _beforeDisplayRow;
        public event BeforeDisplayTotalHandler _beforeDisplayTotal;
        public event AfterCalcTotalEventHandler _afterCalcTotal;
        public event BeforeInputCellEventHandler _beforeInputCell;
        public event AfterRemoveRowEventHandler _afterRemoveRow;
        public event BeforeLoadDataToColumnObject _beforeLoadDataObjectColumn;
        public event AfterImportDataWork _afterImportDataWork;
        public event BeforeDisplayRenderRowEventHandler _beforeDisplayRendering;
        public event TotalCheckEventHandler _totalCheck;
        public event QueryForRowRemoveCheckEventHandler _queryForRowRemoveCheck;
        public event QueryForInsertCheckEventHandler _queryForInsertCheck;
        public event QueryForUpdateCheckEventHandler _queryForUpdateCheck;
        public event QueryForUpdateWhereEventHandler _queryForUpdateWhere;
        public event QueryForInsertPerRowEventHandler _queryForInsertPerRow;
        public event LostFocusCellEventHandler _lostFocusCell;
        public event FocusCellEventHandler _focusCell;
        public event MoveNextColumnEventHandler _moveNextColumn;
        public event MovePrevColumnEventHandler _movePrevColumn;
        public event beforeCellNumberBoxCheckNumberValue _beforeNumberBoxCheckValue;

        #endregion

        public _myGrid()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font(_myGlobal._myFont.FontFamily, _myGlobal._myFont.Size);

            this.MouseClick += new MouseEventHandler(_myGrid_MouseClick);
            this.MouseDoubleClick += new MouseEventHandler(_myGrid_MouseDoubleClick);
            this.MouseMove += new MouseEventHandler(_myGrid_MouseMove);
            this.MouseUp += new MouseEventHandler(_myGrid_MouseUp);
            this.MouseWheel += new MouseEventHandler(_myGrid_MouseWheel);
            this.MouseLeave += new EventHandler(_myGrid_MouseLeave);
            this.SizeChanged += new EventHandler(_myGrid_SizeChanged);
            this.MouseDown += new MouseEventHandler(_myGrid_MouseDown);

            _vScrollBar1.Visible = false;
            _vScrollBar1.ValueChanged += new EventHandler(vScrollBar1_ValueChanged);
            _vScrollBar1.Scroll += new ScrollEventHandler(vScrollBar1_Scroll);
            _vScrollBar1.MouseEnter += new EventHandler(_vScrollBar1_MouseEnter);
            _vScrollBar1.VisibleChanged += new EventHandler(_vScrollBar1_VisibleChanged);
            //
            _hScrollBar1.Visible = false;
            _hScrollBar1.ValueChanged += new EventHandler(hScrollBar1_ValueChanged);
            _hScrollBar1.Scroll += new ScrollEventHandler(hScrollBar1_Scroll);
            _hScrollBar1.MouseEnter += new EventHandler(_hScrollBar1_MouseEnter);
            _hScrollBar1.VisibleChanged += new EventHandler(_hScrollBar1_VisibleChanged);
            this.TabStop = false;

            // event
            _inputTextBox.textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            _inputTextBox._cellMoveLeft += new CellMoveLeftHandler(_inputTextBox__cellMoveLeft);
            _inputTextBox._cellMoveRight += new CellMoveRightHandler(_inputTextBox__cellMoveRight);
            _inputTextBox._cellSearch += new CellSearchHandler(_inputTextBox__cellSearch);
            _inputTextBox.Visible = false;
            _inputTextBox.TabStop = false;
            _inputTextBox.textBox.LostFocus += new EventHandler(textBox_LostFocus);
            _inputTextBox.Font = this._getFont;

            this.Controls.Add(_inputTextBox);
            //
            this._inputNumberBox.textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            this._inputNumberBox._cellMoveLeft += new CellMoveLeftHandler(_inputTextBox__cellMoveLeft);
            this._inputNumberBox._cellMoveRight += new CellMoveRightHandler(_inputTextBox__cellMoveRight);
            this._inputNumberBox._cellSearch += new CellSearchHandler(_inputTextBox__cellSearch);
            this._inputNumberBox.Visible = false;
            this._inputNumberBox.TabStop = false;
            this._inputNumberBox.textBox.LostFocus += new EventHandler(textBox_LostFocus);
            // toe
            this._inputNumberBox._beforeCheckNumberValue += _inputNumberBox__beforeCheckNumberValue;

            this._inputNumberBox._afterSelectCalculator += new AfterSelectCalculatorHandler(_inputNumberBox__afterSelectCalculator);
            this._inputNumberBox.Font = this._getFont;
            //somruk
            this.Controls.Add(_inputNumberBox);
            //
            _inputComboBox.KeyPress += new KeyPressEventHandler(_inputComboBox_KeyPress);
            _inputComboBox._cellMoveLeft += new CellComboBoxMoveLeftHandler(_inputComboBox__cellMoveLeft);
            _inputComboBox._cellMoveRight += new CellComboBoxMoveRightHandler(_inputComboBox__cellMoveRight);
            _inputComboBox.LostFocus += new EventHandler(_inputComboBox_LostFocus);
            _inputComboBox.LocationChanged += new EventHandler(_inputComboBox_LocationChanged);
            _inputComboBox.Visible = false;
            _inputComboBox.TabStop = false;
            _inputComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _inputComboBox.SelectedValueChanged += new EventHandler(_inputComboBox_SelectedValueChanged);
            this._inputComboBox.Font = this._getFont;
            this.Controls.Add(_inputComboBox);
            //
            _inputDateBox.textBox.KeyPress += new KeyPressEventHandler(textBox_KeyPress);
            _inputDateBox._cellMoveLeft += new CellMoveLeftHandler(_inputDateBox__cellMoveLeft);
            _inputDateBox._cellMoveRight += new CellMoveRightHandler(_inputDateBox__cellMoveRight);
            _inputDateBox._cellSearch += new CellSearchHandler(_inputDateBox__cellSearch);
            _inputDateBox.Visible = false;
            _inputDateBox.TabStop = false;
            _inputDateBox._lostFocust = false;
            _inputDateBox._warning = false;
            _inputDateBox.textBox.LostFocus += new EventHandler(textBox_LostFocus);
            _inputDateBox._afterSelectCalendar += new AfterSelectCalendarHandler(_inputDateBox__afterSelectCalendar);
            this._inputDateBox.Font = this._getFont;
            this.Controls.Add(_inputDateBox);
            //
            this.GotFocus += new EventHandler(_myGrid_GotFocus);
            this.DragOver += new DragEventHandler(_myGrid_DragOver);
            this.Invalidated += new InvalidateEventHandler(_myGrid_Invalidated);
            //
            this.MouseDown += new MouseEventHandler(myGrid_MouseDown);
        }

        #region Grid Add Column New


        public void AddGridColumn(BaseGridColumn column)
        {
            this._addColumn(
                column.ColumnCode,
                column.ColumnType,
                column.MaxLength,
                column.WidthPercent,
                column.IsEdit,
                column.IsHide,
                column.IsQuery,
                column.IsSearch, column.Format, column.ExtraWord, column.SearchFieldName, column.ColumnName);
        }



        #endregion

        #region Grid Add Column Operation OLD

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        public void _addColumn(string name, int type, int maxLength, int widthPercent, bool isEdit, bool isHide, bool isQuery)
        {
            _addColumn(name, type, maxLength, widthPercent, isEdit, isHide, isQuery, false, "", name);
        }

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        /// <param name="isSearch">string แบบต้องการค้นหา (โปรแกรมจะแสดงแว่นขยายให้)</param>
        /// <param name="format">รูปแบบของวันที่ หรือตัวเลข (DD/MM/YY, DD/MM/YYYY, ###,###.## , @@@@,@@@@.@@</param>
        public void _addColumn(string name, int type, int maxLength, int widthLength, bool isEdit, bool isHide, bool isQuery, bool isSearch, string format, string query)
        {
            _addColumn(name, type, maxLength, widthLength, isEdit, isHide, isQuery, isSearch, format, query, "");
        }


        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        /// <param name="isSearch">string แบบต้องการค้นหา (โปรแกรมจะแสดงแว่นขยายให้)</param>
        /// <param name="format">รูปแบบของวันที่ หรือตัวเลข (DD/MM/YY, DD/MM/YYYY, ###,###.## , @@@@,@@@@.@@</param>
        /// <param name="extraWord">ข้อความต่อท้าย ColumnName</param>
        public void _addColumn(string name, int type, int maxLength, int widthLength, bool isEdit, bool isHide, bool isQuery, bool isSearch, string format, string query, string extraWord)
        {
            _addColumn(name, type, maxLength, widthLength, isEdit, isHide, isQuery, isSearch, format, query, "", "");
        }

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        public void _addColumn(string name, int type, int maxLength, int widthPercent, bool isEdit, bool isHide)
        {
            _addColumn(name, type, maxLength, widthPercent, isEdit, isHide, true, false, "", name);
        }

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        public void _addColumn(string name, int type, int maxLength, int widthPercent)
        {
            _addColumn(name, type, maxLength, widthPercent, true, false, true, false, "", name);
        }

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        public void _addColumn(string name, int type, int maxLength, int widthPercent, bool isQuery)
        {
            _addColumn(name, type, maxLength, widthPercent, true, false, isQuery, false, "", name);
        }


        public void _addColumn(string name, int type, int maxLength, int widthLength, bool isEdit, bool isHide, bool isQuery, bool isSearch, string format, string query, string extraWord, string resourceName)
        {
            _addColumn(name, type, maxLength, widthLength, isEdit, isHide, isQuery, isSearch, format, query, extraWord, "", resourceName);
        }

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        /// <param name="isSearch">string แบบต้องการค้นหา (โปรแกรมจะแสดงแว่นขยายให้)</param>
        /// <param name="format">รูปแบบของวันที่ หรือตัวเลข (DD/MM/YY, DD/MM/YYYY, ###,###.## , @@@@,@@@@.@@</param>
        /// <param name="extraWord">ข้อความต่อท้าย ColumnName</param>
        /// <param name="fieldSearch">กำหนด Field สำหรับค้นหา ของ Column นี้</param>
        /// <param name="resourceName">Resource Name</param>
        public void _addColumn(string name, int type, int maxLength, int widthLength, bool isEdit, bool isHide, bool isQuery, bool isSearch, string format, string query, string extraWord, string fieldSearch, string resourceName)
        {
            if (this._findColumnByName(name) == -1)
            {
                if (DisplayRowNumber == false)
                {
                    _displayStartY = 1;
                }
                _columnType __newColumn = new _columnType();
                __newColumn._originalName = name;
                string __getstring = (resourceName.Length == 0) ? name : resourceName;
                int __getLength = maxLength;
                if (this._getResource && _myGlobal._isDesignMode == false)
                {
                    try
                    {
                        _myResourceType __getResource = _myResource._findResource((this._table_name.Length == 0) ? __getstring : (this._table_name + "." + __getstring), __getstring, this._autoInsertResource);
                        __getstring = __getResource._str;
                        if (__getResource._length > 0)
                        {
                            __getLength = __getResource._length;
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    //__getstring = __getstring;
                    __getLength = 255;
                }
                if ((Control.ModifierKeys & Keys.Control) == Keys.Control && (Control.ModifierKeys & Keys.Shift) == Keys.Shift)
                {
                    __newColumn._name = name;
                }
                else
                {
                    __newColumn._name = __getstring;
                }
                __newColumn._type = type;
                __newColumn._widthPercent = (isHide) ? 0 : widthLength;
                __newColumn._widthPoint = (isHide) ? 0 : ((this._width_by_persent) ? ((this.Width - (_displayStartY - 1)) * widthLength) / 100 : widthLength);
                __newColumn._maxLength = __getLength;
                __newColumn._isEdit = (this._isEdit) ? isEdit : true;
                __newColumn._isHide = isHide;
                __newColumn._isQuery = isQuery;
                __newColumn._format = format;
                __newColumn._isSearch = isSearch;
                __newColumn._totalDisplay = true;
                __newColumn._total = 0;
                __newColumn._query = query;
                __newColumn._extraWord = extraWord;
                __newColumn._resourceName = resourceName;

                if (fieldSearch.Length > 0)
                {
                    __newColumn._searchField = fieldSearch;
                }

                _columnList.Add(__newColumn);
            }
            else
            {
                MessageBox.Show("Add column Duplicate : " + name);
            }
        }

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        /// <param name="isSearch">string แบบต้องการค้นหา (โปรแกรมจะแสดงแว่นขยายให้)</param>
        /// <param name="format">รูปแบบของวันที่ หรือตัวเลข (DD/MM/YY, DD/MM/YYYY, ###,###.## , @@@@,@@@@.@@</param>
        public void _addColumn(string name, int type, int maxLength, int widthPercent, bool isEdit, bool isHide, bool isQuery, bool isSearch, string format)
        {
            _addColumn(name, type, maxLength, widthPercent, isEdit, isHide, isQuery, isSearch, format, name);
        }

        /// <summary>
        /// เพิ่ม Column เข้าไปใน Grid
        /// </summary>
        /// <param name="name">ชื่อ Column ใช้ในการนำข้อมูลเข้า ดึงข้อมูลออก หรือจะใช้ Index แทนก็ได้ (ลำดับที่)</param>
        /// <param name="type">ประเภท Column (1=string,2=Integer,3=Double,4=Date,5=Time,10=Combo Box,11=Check Box,12=Object)</param>
        /// <param name="maxLength">ความยาวของ string</param>
        /// <param name="widthPercent">ความกว้างของ Column (ใน 100%) แต่ถ้าต้องการเกิน ก็กำหนดให้เกิน 100% ได้ จะมีตัวเลื่อนขึ้นให้</param>
        /// <param name="isEdit">แก้ไขได้หรือไม่ (ถ้าแก้ไม่ได้ โปรแกรมจะแสดงพื้นทึบ)</param>
        /// <param name="isHide">ซ่อนหรือไม่ (ในกรณีต้องการเก็บ Field บางตัวซ่อนไว้)</param>
        /// <param name="isQuery">ใช้ในการสร้างคำสั่งสำหรับ Query หรือไม่ (Insert,Update)</param>
        /// <param name="isSearch">string แบบต้องการค้นหา (โปรแกรมจะแสดงแว่นขยายให้)</param>
        /// <param name="format">รูปแบบของวันที่ หรือตัวเลข (DD/MM/YY, DD/MM/YYYY, ###,###.## , @@@@,@@@@.@@</param>
        public void _addColumn(string name, int type, int maxLength, int widthPercent, bool isEdit, bool isHide, bool isQuery, bool isSearch)
        {
            _addColumn(name, type, maxLength, widthPercent, isEdit, isHide, isQuery, isSearch, "", name);
        }

        #endregion

        #region Grid Column Operation




        /// <summary>
        /// เปลี่ยนสีพื้นของ Column
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="backColor"></param>
        public void _setColumnBackground(string columnName, Color backColor)
        {
            int __column = this._findColumnByName(columnName);
            _setColumnBackground(__column, backColor);
        }

        /// <summary>
        /// เปลี่ยนสีพื้นของ Column
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="backColor"></param>
        public void _setColumnBackground(int columnNumber, Color backColor)
        {
            if (columnNumber != -1)
            {
                ((_columnType)_columnList[columnNumber])._backColor = backColor;
                ((_columnType)_columnList[columnNumber])._backColorOn = true;
            }
        }


        /// <summary>
        /// คำนวณความกว้างอัตโนมัติ ให้ครบ 100%
        /// </summary>
        public void _calcPersentWidthToScatter()
        {
            float __sum = 0;
            for (int __loop = 0; __loop < _columnList.Count; __loop++)
            {
                _columnType __getColumn = (_columnType)_columnList[__loop];
                __sum += __getColumn._widthPercent;
            }
            for (int __loop = 0; __loop < _columnList.Count; __loop++)
            {
                _columnType __getColumn = (_columnType)_columnList[__loop];
                __getColumn._widthPercent = ((__getColumn._widthPercent * 100.0f) / __sum);
                _columnList[__loop] = (_columnType)__getColumn;
            }
            this.Invalidate();
        }

        /// <summary>
        /// กำหนด Extra Word (ข้อความพิเศษ ต่อท้าย) ให้กับ Column
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <param name="extraWord">ข้อความพิเศษ</param>
        public void _columnExtraWord(string columnName, string extraWord)
        {
            int __addr = this._findColumnByName(columnName);
            if (__addr != -1)
            {
                _columnType __column = (_columnType)this._columnList[__addr];
                __column._extraWord = extraWord;
                this._columnList[__addr] = (_columnType)__column;
            }
        }

        /// <summary>
        /// เปลี่ยนข้อความ ให้กับ Column
        /// </summary>
        /// <param name="columnName">Column Name</param>
        /// <param name="extraWord">ข้อความใหม่</param>
        public void _columnNameChange(string columnName, string word)
        {
            int __addr = this._findColumnByName(columnName);
            if (__addr != -1)
            {
                _columnType __column = (_columnType)this._columnList[__addr];
                __column._name = word;
                this._columnList[__addr] = (_columnType)__column;
            }
        }



        public void _addColumnTop(string columnName, int columnBegin, int columnEnd)
        {
            _columnType __newColumn = new _columnType();
            __newColumn._originalName = columnName;
            string __getstring = columnName;
            if (this._getResource && _myGlobal._isDesignMode == false)
            {
                _myResourceType __getResource = _myResource._findResource((this._table_name.Length == 0) ? columnName : string.Concat(this._table_name, ".", columnName), columnName);
                __getstring = __getResource._str;
            }
            else
            {
                __getstring = columnName;
            }
            __newColumn._name = __getstring;
            __newColumn._columnBegin = columnBegin;
            __newColumn._columnEnd = columnEnd;
            this._columnListTop.Add(__newColumn);
        }

        public void _clearGridColumn()
        {
            this._columnList.Clear();
            this._findColumnByNameList.Clear();
        }

        /// <summary>
        /// ค้นหาชื่อ Column 
        /// </summary>
        /// <param name="columnName">ชื่อ Column</param>
        /// <returns>ตำแหน่งของ Column</returns>
        public int _findColumnByName(string columnName)
        {
            columnName = columnName.ToLower();
            // ค้นหาใน List ก่อน เพื่อความเร็ว
            _findColumnByNameListType __find = _findColumnByNameList.Find(delegate (_findColumnByNameListType __resource) { return __resource._name == columnName; });
            if (__find != null)
            {
                return __find._addr;
            }
            // ถ้าไม่เจอให้ Scan
            for (int __loop = 0; __loop < _columnList.Count; __loop++)
            {
                if (((_columnType)_columnList[__loop])._originalName.ToLower().CompareTo(columnName) == 0)
                {
                    _findColumnByNameListType __data = new _findColumnByNameListType();
                    __data._name = ((_columnType)_columnList[__loop])._originalName.ToLower();
                    __data._addr = __loop;
                    _findColumnByNameList.Add(__data);
                    _findColumnByNameList.Sort(delegate (_findColumnByNameListType __resource1, _findColumnByNameListType __resource2) { return __resource1._name.CompareTo(__resource2._name); });
                    return (__loop);
                }
            } // for
            return (-1);
        }

        #endregion

        #region Grid Row Operation

        public int _rowCount(int columnNumber)
        {
            int __result = 0;
            if (columnNumber != -1)
            {
                for (int __row = 0; __row < this._rowData.Count; __row++)
                {
                    if (((ArrayList)_rowData[__row])[columnNumber].ToString().Length != 0)
                    {
                        __result++;
                    }
                }
            }
            return __result;
        }

        /// <summary>
        /// ค้นหาแล้วกระโดดไปบรรทัดที่ต้องการ
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="source"></param>
        public void _findAndGotoRow(string columnName, object source)
        {
            int __columnNumber = this._findColumnByName(columnName);
            if (__columnNumber != -1)
            {
                _findAndGotoRow(__columnNumber, source);
            }
        }

        /// <summary>
        /// ค้นหาแล้วกระโดดไปบรรทัดที่ต้องการ
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="source"></param>
        public void _findAndGotoRow(int columnNumber, object source)
        {
            int __found = _findData(columnNumber, source);
            if (__found != -1)
            {
                this._selectRow = __found;
                this.Invalidate();
            }
        }

        public void _clear()
        {
            this._selectClear();
            this._selectColumn = -1;
            this._selectRow = -1;
            this._rowFirst = 0;
            this._rowData.Clear();
            this._isChange = false;
            this._inputTextBox.Visible = false;
            this._inputNumberBox.Visible = false;
            this._inputComboBox.Visible = false;
            this._inputDateBox.Visible = false;
            this.Invalidate();
        }


        public void _goToRow(int row)
        {
            if (this._vScrollBar1.Maximum > 0 && this._vScrollBar1.Value > 0)
            {
                int moreRowCount = 0;
                if (this._total_show)
                {
                    moreRowCount++;
                }

                if (this._message.Length > 0)
                {
                    moreRowCount++;
                }
                int __scollValue = row / this._rowData.Count + moreRowCount;
                if (__scollValue < this._vScrollBar1.Value)
                {
                    this._vScrollBar1.Value = row;
                }
            }
        }

        public int _addRow()
        {
            return this._addRow(-1);
        }

        /// <summary>
        /// เพิ่มบรรทัด (แบบแทรก) พร้อม clear ตัวแปรทุก Column
        /// </summary>
        public int _addRow(int rowNumber)
        {
            ArrayList __data = new ArrayList();
            _columnType __getColumn = new _columnType();
            for (int __loop = 0; __loop < _columnList.Count; __loop++)
            {
                __getColumn = (_columnType)_columnList[__loop];
                string __datastring = "";
                decimal __dataDouble = 0;
                int __dataInt = 0;
                object __dataObjcet = __datastring;
                switch (__getColumn._type)
                {
                    case 2:
                        __dataObjcet = __dataInt;
                        break;
                    case 3:
                    case 5:
                        __dataObjcet = __dataDouble;
                        break;
                    case 4:
                        __dataObjcet = new DateTime(1000, 1, 1); // Date
                        break;
                    case 10:
                        __dataObjcet = __dataInt;// ComboBox
                        break;
                    case 11:
                        __dataObjcet = __dataInt;// CheckBox
                        break;
                    case 12:
                        __dataObjcet = null;// Object
                        break;
                }
                if (_beforeAddRow != null)
                {
                    __dataObjcet = _beforeAddRow(this, __dataObjcet, _rowData.Count - 1, __loop, __getColumn._originalName);
                }
                __data.Add(__dataObjcet);
            } // for
            __data.Add(false); // Change

            if (rowNumber > -1)
                _rowData.Insert(rowNumber, __data);
            else
            {
                _rowData.Add(__data);
            }

            if (_afterAddRow != null)
                _afterAddRow(this, rowNumber);
            this.Invalidate();


            int rowIndex = (rowNumber > -1) ? rowNumber : (_rowData.Count - 1);
            return rowIndex;

        }

        #endregion

        #region Grid Operation 

        /// <summary>
        /// ค้นหาข้อมูลใน Grid
        /// </summary>
        /// <param name="columnNumber"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public int _findData(int columnNumber, object source)
        {
            int __found = -1;
            for (int __row = 0; __row < this._rowData.Count; __row++)
            {
                if (source.GetType() == typeof(string))
                {
                    string __getData = this._cellGet(__row, columnNumber).ToString().ToUpper();
                    if (__getData.Equals(source.ToString().ToUpper()))
                    {
                        __found = __row;
                        break;
                    }
                }
            }
            return __found;
        }



        public void _reset()
        {
            this._autoUpperSearchString = true;
            this._importWorking = false;
            this._mouseClickEnable = true;
            this._rowNumberWork = false;
            this._rowNumberList = new ArrayList();
            this._columnList = new ArrayList();
            this._rowData = new ArrayList();
            this._vScrollBarLock = false;
            this._columnLine = new int[5000];
            this._columnLineMax = -1;
            this._columnSplitMode = false;
            this._columnSplitActive = false;
            this._columnSplitAddr = 0;
            this._columnSplitFirstValue = 0;
            this._columnSplitMoveValue = 0;
            this._drawing = false;
            this._textRenderingHint = System.Drawing.Text.TextRenderingHint.SystemDefault;
            this._lastControl = null;
            this._gridType = 0;
            this._addRowEnabled = true;
            this._columnFirst = 0;
            this._rowStartNumber = 0;
            this._rowFirst = 0;
            this._columnBackgroundBeginAuto = Color.FromArgb(250, 251, 252);
            this._columnBackgroundEndAuto = Color.FromArgb(214, 217, 227);
            this._columnBackground = Color.FromArgb(250, 251, 252);
            this._columnBackgroundEnd = Color.FromArgb(214, 217, 227);
            this._columnBackgroundAuto = true;
            this._RowBackground1 = Color.Snow;
            this._RowBackground2 = Color.White;
            this._cellHeight = 16;
            this._selectRowTemp = -1;
            this._selectRowOldPositon = -1;
            this._selectColumn = -1;
            this._selectRowFromMouse = -1;
            this._selectColumnFromMouse = -1;
            this._selectRowFromMouseLast = -1;
            this._isChange = false;
            this._table_name = "";
            this._database_name = "";
            this._width_by_persent = true;
            this._displayRowNumber = true;
            this._displayStartY = 41;
            this._total_show = false;
            this._maxDataRow = 0;
            this._extraArray = new ArrayList();
            this._rowPerPage = 0;
            this._processKeyEnable = true;
            this._showMenuInsertAndDeleteRow = false;
            this._extraWordShowTemp = true;
            this._message = "";
            this._lastSelectRow = -1;
            this._lastSelectColumn = -1;
            this._columnTopActive = false;
            this._columnListTop = new ArrayList();
            this._stopMove = false;
            this._findColumnByNameList = new List<_findColumnByNameListType>();
            //
            this._calcHeightCalc();
        }


        /// <summary>
        /// ดึงข้อมูลจาก DataSet ที่ Query มาได้ เข้า DataGrid แบบอัตโนมัติ
        /// </summary>
        /// <param name="myData">DataSet ที่ได้จากการ Query</param>
        /// <param name="myDataRow">DataRow ที่ได้จากการ Select จาก DataSet</param>
        public void _loadFromDataTable(DataTable myDataTable, DataRow[] myDataRow)
        {
            List<int> __columnIndex = new List<int>();
            this._rowNumberList.Clear();
            this._clear();
            this._maxDataRow = 0;
            if (myDataRow.Length == 0)
            {
                return;
            }
            for (int __findColumn = 0; __findColumn < _columnList.Count; __findColumn++)
            {
                Boolean __found = false;
                _columnType __getColumn = (_columnType)_columnList[__findColumn];
                for (int __column = 0; __column < myDataRow[0].ItemArray.Length; __column++)
                {
                    string __columnName = myDataTable.Columns[__column].ColumnName.ToLower();
                    if (__getColumn._originalName.ToLower().Equals(__columnName))
                    {
                        __columnIndex.Add(__column);
                        __found = true;
                        break;
                    }
                }
                if (__found == false)
                {
                    __columnIndex.Add(-1);
                }
            }
            for (int __row = 0; __row < myDataRow.Length; __row++)
            {
                this._maxDataRow++;
                ArrayList __data = new ArrayList();
                for (int __findColumn = 0; __findColumn < _columnList.Count; __findColumn++)
                {
                    int __dataColumn = __columnIndex[__findColumn];
                    _columnType __getColumn = (_columnType)_columnList[__findColumn];
                    if (__dataColumn == -1)
                    {
                        __data.Add(this._dataObjectBlank(__getColumn._type));
                    }
                    else
                    {
                        string __dataStr = ((myDataRow[__row].IsNull(__dataColumn))) ? "" : myDataRow[__row].ItemArray[__dataColumn].ToString();
                        switch (__getColumn._type)
                        {
                            case 1:
                                __data.Add(__dataStr); //__data.Add(__dataStr.Replace('\n', ' '));
                                break;
                            case 2:
                                int __getInt = (__dataStr.Length == 0) ? 0 : Utils._numberUtils._intPhase(__dataStr);
                                __data.Add((int)__getInt);
                                if (this._rowNumberWork)
                                {
                                    if (myDataTable.Columns[__dataColumn].ColumnName.ToLower().Equals(_rowNumberName.ToLower()))
                                    {
                                        this._rowNumberList.Add((int)__getInt);
                                    }
                                }
                                break;
                            case 3:
                            case 5:
                                __data.Add((decimal)Utils._numberUtils._decimalPhase(__dataStr));
                                break;
                            case 4:
                                string[] __getDate = __dataStr.Split(' ');
                                DateTime __getDateResult = new DateTime(1000, 1, 1);
                                try
                                {
                                    string __dateBuffer = __getDate[0];
                                    __dateBuffer = __dateBuffer.Replace('-', '/').Replace('.', '/').Replace('*', '/').Replace(' ', '/');
                                    if (__dateBuffer.Length > 0)
                                    {
                                        string[] __dateSplit = __dateBuffer.Split('/');
                                        int __year = Convert.ToInt32(__dateSplit[0]);
                                        int __month = Convert.ToInt32(__dateSplit[1]);
                                        int __day = Convert.ToInt32(__dateSplit[2]);
                                        __getDateResult = new DateTime(__year, __month, __day);
                                    }
                                }
                                catch
                                {
                                    Debugger.Break();
                                }
                                __data.Add(__getDateResult);
                                break;
                            case 10:
                            case 11: __data.Add((int)((__dataStr.Length == 0) ? 0 : Convert.ToInt32(__dataStr))); break;

                            case 12:
                                {
                                    if (_beforeLoadDataObjectColumn != null)
                                    {
                                        __data.Add(_beforeLoadDataObjectColumn(__dataStr, __row, __dataColumn));
                                    }
                                    else
                                        __data.Add((int)((__dataStr.Length == 0) ? 0 : Convert.ToInt32(__dataStr)));
                                    break;
                                }
                            default: __data.Add((int)0); break;
                        }
                    }
                }
                __data.Add(false);
                this._rowData.Add(__data);
            }
            /*for (int __row = 0; __row < myDataRow.Length; __row++)
            {
                _maxDataRow++;
                _addRow();
                for (int __column = 0; __column < myDataRow[__row].ItemArray.Length; __column++)
                {
                    string __columnName = myDataTable.Columns[__column].ColumnName.ToLower();
                    for (int __findColumn = 0; __findColumn < _columnList.Count; __findColumn++)
                    {
                        _columnType __getColumn = (_columnType)_columnList[__findColumn];
                        if (__getColumn._originalName.ToLower().Equals(__columnName))
                        {
                            string dataStr = myDataRow[__row].ItemArray[__column].ToString();
                            if (myDataRow[__row].IsNull(__column)) dataStr = "";
                            switch (__getColumn._type)
                            {
                                case 1: _cellUpdate(__row, __findColumn, dataStr.Replace('\n', ' '), false);
                                    break;
                                case 2: int __getInt = (dataStr.Length == 0) ? 0 : Convert.ToInt32(dataStr);
                                    _cellUpdate(__row, __findColumn, __getInt, false);
                                    if (_rowNumberWork)
                                    {
                                        if (__columnName.ToLower().Equals(_rowNumberName.ToLower()))
                                        {
                                            _rowNumberList.Add(__getInt);
                                        }
                                    }
                                    break;
                                case 3:
                                case 5: _cellUpdate(__row, __findColumn, _myGlobal._decimalPhase(dataStr), false);
                                    break;
                                case 4: string[] __getDate = dataStr.Split(' ');
                                    DateTime __getDateResult = new DateTime(1000, 1, 1);
                                    try
                                    {
                                        string __dateBuffer = __getDate[0];
                                        __dateBuffer = __dateBuffer.Replace('-', '/');
                                        __dateBuffer = __dateBuffer.Replace('.', '/');
                                        __dateBuffer = __dateBuffer.Replace('*', '/');
                                        __dateBuffer = __dateBuffer.Replace(' ', '/');
                                        if (__dateBuffer.Length > 0)
                                        {
                                            string[] __dateSplit = __dateBuffer.Split('/');
                                            int __year = Convert.ToInt32(__dateSplit[0]);
                                            int __month = Convert.ToInt32(__dateSplit[1]);
                                            int __day = Convert.ToInt32(__dateSplit[2]);
                                            __getDateResult = new DateTime(__year, __month, __day);
                                        }
                                    }
                                    catch
                                    {
                                        // Debugger.Break();
                                    }
                                    _cellUpdate(__row, __findColumn, __getDateResult, false);
                                    break;
                                case 10: _cellUpdate(__row, __findColumn, (dataStr.Length == 0) ? 0 : Convert.ToInt32(dataStr), false); break;
                                case 11: _cellUpdate(__row, __findColumn, (dataStr.Length == 0) ? 0 : Convert.ToInt32(dataStr), false); break;
                                case 12: _cellUpdate(__row, __findColumn, (dataStr.Length == 0) ? 0 : Convert.ToInt32(dataStr), false); break;
                                default: _cellUpdate(__row, __findColumn, 0, false); break;
                            }
                            break;
                        }
                    } // for
                } // for
            } // for*/
            this._calcTotal(false);
        }


        /// <summary>
        /// กระโดดไปยังตำแหน่งที่ต้องการ
        /// </summary>
        /// <param name="row">Row (เริ่มจาก 0)</param>
        /// <param name="column">Column (เริ่มจาก 0)</param>
        public void _gotoCell(int row, int column)
        {
            _inputCell(row, column);
        }


        /// <summary>
        /// บันทึกข้อมูลในช่อง
        /// </summary>
        /// <param name="selectNewRow"></param>
        /// <param name="selectNewColumn"></param>
        public void _inputCell(int selectNewRow, int selectNewColumn)
        {
            Boolean __editCheck = true;
            if (_beforeInputCell != null) __editCheck = _beforeInputCell(this, selectNewRow, selectNewColumn);
            if (selectNewColumn == -1 || selectNewRow == -1)
            {
                return;
            }
            _inputTextBox.textBox.LostFocus -= new EventHandler(textBox_LostFocus);
            this._inputNumberBox.textBox.LostFocus -= new EventHandler(textBox_LostFocus);
            try
            {
                _lastSelectColumn = this._selectColumn;
                _lastSelectRow = this._selectRow;
                float __currentX = _displayStartY - 1;
                float __columnWidth = ((_columnType)_columnList[selectNewColumn])._widthPoint;
                //
                // save ค่าก่อน
                if (_removeLastControl())
                {
                    // เปลี่ยนตำแหน่ง
                    this._selectRow = selectNewRow;
                    this._selectColumn = selectNewColumn;
                    if (_selectRow == _rowData.Count && this._isEdit == true && AddRow)
                    {
                        _addRow();
                    }
                    //
                    if (selectNewRow < _rowData.Count)
                    {
                        for (int __column = _columnFirst; __column < selectNewColumn; __column++)
                        {
                            _columnType getColumn = (_columnType)_columnList[__column];
                            __currentX += getColumn._widthPoint;
                        }
                        if (this._displayRowNumber == false)
                        {
                            __currentX += 2;
                        }
                        int reserveRow = 1;
                        float __reserveTotalRowHeight = 0f;
                        if (this._total_show)
                        {
                            __reserveTotalRowHeight = _cellHeight;
                        }
                        // create input
                        float __currentY = (((_selectRow - _rowFirst) + reserveRow) * _cellHeight) + 1 + this._getTopY;
                        float __calcHeight = _calcHeight();
                        if (__currentY > (__calcHeight - (_cellHeight + __reserveTotalRowHeight)) + this._getTopY)
                        {
                            // เลื่อนทั้งหน้าขึ้น
                            _rowFirst++;
                            if (this._total_show)
                            {
                                _rowFirst++;
                            }
                            __currentY -= _cellHeight;
                        }
                        if (selectNewRow < _rowFirst)
                        {
                            // เลื่อนหน้าลง
                            _rowFirst--;
                            __currentY += _cellHeight;
                        }
                        if (__editCheck && _isEdit && ((_columnType)_columnList[_selectColumn])._isEdit)
                        {
                            switch (((_columnType)_columnList[selectNewColumn])._type)
                            {
                                case 1:
                                    _inputTextBox.SuspendLayout();
                                    _inputTextBox.ShowIcon = (((_columnType)_columnList[selectNewColumn])._isSearch) ? true : false;
                                    _inputTextBox.Location = new Point((int)__currentX, (int)__currentY);
                                    _inputTextBox.Width = (int)__columnWidth;
                                    _inputTextBox.MaxLength = ((_columnType)_columnList[selectNewColumn])._maxLength;
                                    _inputTextBox.textBox.ReadOnly = (((_columnType)_columnList[selectNewColumn])._isEdit == false) ? true : false;
                                    _inputTextBox.Visible = true;
                                    _inputTextBox.textBox.Text = _cellGet(selectNewRow, selectNewColumn).ToString();
                                    _inputTextBox.Invalidate();
                                    _inputTextBox.textBox.Focus();
                                    _inputTextBox.textBox.SelectAll();
                                    _inputTextBox.ResumeLayout(false);
                                    _lastControl = (_myTextBox)_inputTextBox;
                                    //
                                    _inputDateBox.Visible = false;
                                    this._inputNumberBox.Visible = false;
                                    _inputComboBox.Visible = false;
                                    break;
                                case 2:
                                    this._inputNumberBox.SuspendLayout();
                                    this._inputNumberBox.textBox.SuspendLayout();
                                    this._inputNumberBox.textBox.Text = _cellGet(selectNewRow, selectNewColumn).ToString();
                                    this._inputNumberBox._checkNumber();
                                    this._inputNumberBox.Location = new Point((int)__currentX, (int)__currentY);
                                    this._inputNumberBox._format = ((_columnType)_columnList[selectNewColumn])._format;
                                    this._inputNumberBox.Width = (int)__columnWidth;
                                    this._inputNumberBox.MaxLength = ((_columnType)_columnList[selectNewColumn])._maxLength;
                                    this._inputNumberBox.textBox.ReadOnly = (((_columnType)_columnList[selectNewColumn])._isEdit == false) ? true : false;
                                    this._inputNumberBox.Visible = true;
                                    this._inputNumberBox.textBox.Focus();
                                    this._inputNumberBox.textBox.SelectAll();
                                    this._inputNumberBox.textBox.ResumeLayout(false);
                                    this._inputNumberBox.ResumeLayout(false);
                                    _lastControl = (_myNumberBox)_inputNumberBox;
                                    //
                                    _inputDateBox.Visible = false;
                                    _inputTextBox.Visible = false;
                                    _inputComboBox.Visible = false;
                                    break;
                                case 3:
                                case 5:

                                    string formatNumber = Utils._numberUtils._getFormatNumber(((_columnType)_columnList[selectNewColumn])._format);
                                    this._inputNumberBox.SuspendLayout();
                                    this._inputNumberBox.textBox.SuspendLayout();
                                    this._inputNumberBox.textBox.Text = string.Format(formatNumber, Utils._numberUtils._decimalPhase(_cellGet(selectNewRow, selectNewColumn).ToString()));
                                    this._inputNumberBox._checkNumber();
                                    this._inputNumberBox.Location = new Point((int)__currentX, (int)__currentY);
                                    this._inputNumberBox.Width = (int)__columnWidth;
                                    this._inputNumberBox._format = ((_columnType)_columnList[selectNewColumn])._format;
                                    this._inputNumberBox.MaxLength = ((_columnType)_columnList[selectNewColumn])._maxLength;
                                    this._inputNumberBox.textBox.ReadOnly = (((_columnType)_columnList[selectNewColumn])._isEdit == false) ? true : false;
                                    this._inputNumberBox.Visible = true;
                                    this._inputNumberBox.textBox.Focus();
                                    this._inputNumberBox.textBox.SelectAll();
                                    this._inputNumberBox.textBox.ResumeLayout(false);
                                    this._inputNumberBox.ResumeLayout(false);
                                    _lastControl = (_myNumberBox)_inputNumberBox;
                                    //
                                    _inputDateBox.Visible = false;
                                    _inputTextBox.Visible = false;
                                    _inputComboBox.Visible = false;
                                    break;
                                case 4:
                                    _inputDateBox.SuspendLayout();
                                    _inputDateBox.textBox.SuspendLayout();
                                    _inputDateBox._dateTime = (DateTime)_cellGet(selectNewRow, selectNewColumn);
                                    _inputDateBox._beforeInput();
                                    _inputDateBox.Location = new Point((int)__currentX, (int)__currentY);
                                    _inputDateBox.Width = (int)__columnWidth;
                                    _inputDateBox.MaxLength = ((_columnType)_columnList[selectNewColumn])._maxLength;
                                    _inputDateBox.textBox.ReadOnly = (((_columnType)_columnList[selectNewColumn])._isEdit == false) ? true : false;
                                    _inputDateBox.Visible = true;
                                    _inputDateBox.textBox.Focus();
                                    _inputDateBox.textBox.SelectAll();
                                    _inputDateBox.textBox.ResumeLayout(false);
                                    _inputDateBox.ResumeLayout(false);
                                    _lastControl = (_myDateBox)_inputDateBox;
                                    //
                                    this._inputNumberBox.Visible = false;
                                    _inputTextBox.Visible = false;
                                    _inputComboBox.Visible = false;
                                    break;
                                case 10:
                                    _inputComboBox.SuspendLayout();
                                    _inputComboBox.Location = new Point((int)__currentX, (int)__currentY);
                                    _inputComboBox.Width = (int)__columnWidth;
                                    _inputComboBox.MaxLength = ((_columnType)_columnList[selectNewColumn])._maxLength;
                                    int getValue = (int)_cellGet(_selectRow, this._selectColumn);
                                    if (_cellComboBoxItem != null)
                                    {
                                        _inputComboBox.Items.Clear();
                                        _inputComboBox.Items.AddRange(_cellComboBoxItem(this, this._selectRow, this._selectColumn));
                                    }
                                    _inputComboBox.SelectedIndex = (_inputComboBox.Items.Count == 0) ? -1 : (getValue < 0 || getValue > _inputComboBox.Items.Count) ? 0 : getValue;
                                    _inputComboBox.Visible = true;
                                    _inputComboBox.Focus();
                                    _inputComboBox.SelectAll();
                                    _inputComboBox.ResumeLayout(false);
                                    _lastControl = (_myComboBox)_inputComboBox;
                                    //
                                    _inputDateBox.Visible = false;
                                    this._inputNumberBox.Visible = false;
                                    _inputTextBox.Visible = false;
                                    break;
                            }
                        }
                        this.Invalidate();

                        // scrollbar
                        //this._vScrollBar1.Maximum < 
                    }
                    if (_focusCell != null)
                    {
                        _focusCell(this, this._selectRow, this._selectColumn, ((_columnType)_columnList[selectNewColumn])._originalName);
                    }
                }
            }
            catch
            {
                // Debugger.Break();
            }
            _inputTextBox.textBox.LostFocus += new EventHandler(textBox_LostFocus);
            this._inputNumberBox.textBox.LostFocus += new EventHandler(textBox_LostFocus);
        }


        /// <summary>
        /// นำข้อมูลเข้าไปใน Cell
        /// </summary>
        /// <param name="row">บรรทัดที่ (เริ่มจาก 0)</param>
        /// <param name="column">Column (เริ่มจาก 0)</param>
        /// <param name="data">ข้อมูล เป็น Object</param>
        /// <param name="eventActive">ต้องการให้ Event ทำงาน (ในกรณี Load ข้อมูล ไม่ควรเป็น true)</param>
        public void _cellUpdate(int row, int column, Object data, Boolean eventActive)
        {
            if (_rowData.Count == 0)
            {
                return;
            }

            if (column == -1 || column >= _columnList.Count)
            {
                return;
            }
            try
            {
                _columnType __getColumn = (_columnType)_columnList[column];
                if (_lastControl != null && row == this._selectRow && column == this._selectColumn)
                {
                    if (_lastControl.GetType() == typeof(_myTextBox))
                    {
                        ((_myTextBox)_lastControl).textBox.Text = data.ToString();
                    }
                    else
                    {
                        if (_lastControl.GetType() == typeof(_myNumberBox))
                        {
                            decimal __value = (data.GetType() == typeof(int)) ? (int)data : (decimal)data;
                            ((_myNumberBox)_lastControl)._double = __value;
                            ((_myNumberBox)_lastControl).textBox.Text = data.ToString();
                        }
                    }
                }
                if (__getColumn._type == 11)
                {
                    // CheckBox
                    int __dataCompare = (int)((ArrayList)_rowData[row])[column];
                    if (__dataCompare != (int)data)
                    {
                        Boolean __nextStep = true;
                        if (eventActive)
                        {
                            GridCellEventArgs __getData = new GridCellEventArgs();
                            __getData._column = column;
                            __getData._row = row;
                            __getData._int = (int)data;
                            __getData._columnName = ((_columnType)_columnList[column])._originalName;
                            __nextStep = _beforeCellUpdateWork(__getData);
                        }
                        if (__nextStep)
                        {
                            int __oldData = (int)((ArrayList)_rowData[row])[column];
                            ((ArrayList)_rowData[row])[column] = data;
                            if (eventActive && (int)data != __oldData)
                            {
                                //***
                                ((ArrayList)_rowData[row])[_columnList.Count] = true;
                                _isChange = true;
                                if (eventActive) _afterCellUpdateWork(row, column);
                            }
                        }
                    }
                }
                else
                    if (__getColumn._type == 10)
                {
                    // ComboBox
                    int __dataCompare = (int)((ArrayList)_rowData[row])[column];
                    if (__dataCompare != (int)data)
                    {
                        Boolean __nextStep = true;
                        if (eventActive)
                        {
                            GridCellEventArgs __getData = new GridCellEventArgs();
                            __getData._column = column;
                            __getData._row = row;
                            __getData._columnName = ((_columnType)_columnList[column])._originalName;
                            __getData._int = (int)data;
                            __nextStep = _beforeCellUpdateWork(__getData);
                        }
                        if (__nextStep)
                        {
                            int __oldData = (int)((ArrayList)_rowData[row])[column];
                            ((ArrayList)_rowData[row])[column] = (int)data;
                            if (eventActive && (int)data != __oldData)
                            {
                                //***
                                ((ArrayList)_rowData[row])[_columnList.Count] = true;
                                _isChange = true;
                                if (eventActive) _afterCellUpdateWork(row, column);
                            }
                        }
                    }
                }
                else
                        // Int
                        if (__getColumn._type == 2)
                {
                    int __dataCompare = (int)((ArrayList)_rowData[row])[column];
                    if (__dataCompare != (int)data)
                    {
                        Boolean __nextStep = true;
                        if (eventActive)
                        {
                            GridCellEventArgs __getData = new GridCellEventArgs();
                            __getData._column = column;
                            __getData._row = row;
                            __getData._int = (int)data;
                            __getData._columnName = ((_columnType)_columnList[column])._originalName;
                            __nextStep = _beforeCellUpdateWork(__getData);
                        }
                        if (__nextStep)
                        {
                            int __oldData = (int)((ArrayList)_rowData[row])[column];
                            ((ArrayList)_rowData[row])[column] = data;
                            if (eventActive && (int)data != __oldData)
                            {
                                //***
                                ((ArrayList)_rowData[row])[_columnList.Count] = true;
                                _isChange = true;
                                if (eventActive) _afterCellUpdateWork(row, column);
                            }
                        }
                    }
                }
                else
                            // String
                            if (__getColumn._type == 1)
                {
                    if (data != null)
                    {
                        Object __getObject = ((ArrayList)_rowData[row])[column];
                        string __data = data.ToString();

                        //toe
                        if (__getColumn._isSearch && this._autoUpperSearchString)
                        {
                            __data = __data.ToUpper();
                        }
                        string __dataCompare = (__getObject == null) ? "" : __getObject.ToString();
                        if (__dataCompare.CompareTo(__data) != 0)
                        {
                            Boolean __nextStep = true;
                            if (eventActive)
                            {
                                GridCellEventArgs __getData = new GridCellEventArgs();
                                __getData._column = column;
                                __getData._row = row;
                                __getData._text = __data;
                                __getData._columnName = ((_columnType)_columnList[column])._originalName;
                                __nextStep = _beforeCellUpdateWork(__getData);
                            }
                            if (__nextStep)
                            {
                                string __oldData = ((ArrayList)_rowData[row])[column].ToString();
                                ((ArrayList)_rowData[row])[column] = __data;
                                if (eventActive && __data.CompareTo(__oldData) != 0)
                                {
                                    //***
                                    ((ArrayList)_rowData[row])[_columnList.Count] = true;
                                    _isChange = true;
                                    if (eventActive) _afterCellUpdateWork(row, column);
                                }
                            }
                        }
                    }
                }
                else
                                //decimal
                                if (__getColumn._type == 3 || __getColumn._type == 5)
                {
                    if (data.GetType() != typeof(decimal))
                    {
                        MessageBox.Show("Format error : " + data.ToString());
                    }
                    string __getFormat = ((_columnType)_columnList[column])._format;
                    __getFormat = Utils._numberUtils._getFormatNumber(__getFormat);
                    decimal __getData = Utils._numberUtils._decimalPhase(String.Format(__getFormat, (decimal)data));
                    if (__getColumn._plusOnly && __getData < 0)
                    {
                        __getData = 0;
                    }

                    decimal __dataCompare = (decimal)((ArrayList)_rowData[row])[column];
                    if (__dataCompare != (decimal)__getData)
                    {
                        Boolean __nextStep = true;
                        if (eventActive)
                        {
                            GridCellEventArgs __getDataGrid = new GridCellEventArgs();
                            __getDataGrid._column = column;
                            __getDataGrid._row = row;
                            __getDataGrid._text = __getData.ToString();
                            __getDataGrid._columnName = ((_columnType)_columnList[column])._originalName;
                            __nextStep = _beforeCellUpdateWork(__getDataGrid);
                        }
                        if (__nextStep)
                        {
                            decimal __oldData = (decimal)((ArrayList)_rowData[row])[column];
                            ((ArrayList)_rowData[row])[column] = __getData;
                            if (eventActive && (decimal)__getData != __oldData)
                            {
                                //***
                                ((ArrayList)_rowData[row])[_columnList.Count] = true;
                                _isChange = true;
                                if (eventActive) _afterCellUpdateWork(row, column);
                            }
                        }
                    }
                }
                else
                                    // Date
                                    if (__getColumn._type == 4)
                {
                    if (data.GetType() == typeof(DateTime))
                    {
                        if (((DateTime)data).Year > 1900)
                        {
                            DateTime __dataCompare = (DateTime)((ArrayList)_rowData[row])[column];
                            if (__dataCompare != (DateTime)data)
                            {
                                Boolean __nextStep = true;
                                if (eventActive)
                                {
                                    GridCellEventArgs __getDataGrid = new GridCellEventArgs();
                                    __getDataGrid._column = column;
                                    __getDataGrid._row = row;
                                    __getDataGrid._text = data.ToString();
                                    __getDataGrid._columnName = ((_columnType)_columnList[column])._originalName;
                                    __nextStep = _beforeCellUpdateWork(__getDataGrid);
                                }
                                if (__nextStep)
                                {
                                    DateTime __oldData = (DateTime)((ArrayList)_rowData[row])[column];
                                    ((ArrayList)_rowData[row])[column] = data;
                                    if (eventActive && (DateTime)data != __oldData)
                                    {
                                        //***
                                        ((ArrayList)_rowData[row])[_columnList.Count] = true;
                                        _isChange = true;
                                        if (eventActive) _afterCellUpdateWork(row, column);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Boolean __nextStep = true;
                    if (eventActive)
                    {
                        GridCellEventArgs __getDataGrid = new GridCellEventArgs();
                        __getDataGrid._column = column;
                        __getDataGrid._row = row;
                        __getDataGrid._object = data;
                        __getDataGrid._columnName = ((_columnType)_columnList[column])._originalName;
                        __nextStep = _beforeCellUpdateWork(__getDataGrid);
                    }
                    if (__nextStep)
                    {
                        //***
                        ((ArrayList)_rowData[row])[column] = data;
                        if (eventActive)
                        {
                            ((ArrayList)_rowData[row])[_columnList.Count] = true;
                            _afterCellUpdateWork(row, column);
                            _isChange = true;
                        }
                    }
                }
                // รวม
                if (eventActive)
                {
                    this._calcTotal(true);
                    //_lastControl = null;
                }
            }
            catch (Exception __ex)
            {
                MessageBox.Show(__ex.Message.ToString() + ":" + __ex.StackTrace.ToString()); // 
            }
        }

        public void _calcTotal(Boolean eventActive)
        {

            if (_disableCalTotal == false)
            {
                for (int __column = 0; __column < _columnList.Count; __column++)
                {
                    _columnType __getColumn = (_columnType)_columnList[__column];
                    if (__getColumn._type == 3)
                    {
                        __getColumn._total = 0;
                        for (int __row = 0; __row < _rowData.Count; __row++)
                        {
                            bool __totalPass = true;
                            if (_totalCheck != null)
                            {
                                __totalPass = _totalCheck(this, __row, __column);
                            }
                            if (__totalPass)
                            {
                                try
                                {
                                    __getColumn._total += (decimal)(((ArrayList)_rowData[__row])[__column]);
                                }
                                catch (Exception ex)
                                {
                                    this._disableCalTotal = true;
                                    string __message = string.Format("Error Sum Total Value {0} : Message {1} \r\nRow : {2}, Column {3}", (((ArrayList)_rowData[__row])[__column]).ToString(), ex.Message.ToString(), __row, __column);
                                    MessageBox.Show(__message);
                                    break;
                                    //throw new Exception();
                                }

                            }
                        }
                    }
                    _columnList[__column] = (_columnType)__getColumn;
                }
                if (eventActive)
                {
                    if (this._afterCalcTotal != null)
                    {
                        this._afterCalcTotal(this);
                    }
                }
            }
        }



        /// <summary>
        /// นำข้อมูลเข้าไปใน Cell
        /// </summary>
        /// <param name="row">บรรทัดที่ (เริ่มจาก 0)</param>
        /// <param name="columnName">ชื่อ Column</param>
        /// <param name="data">ข้อมูล เป็น Object</param>
        /// <param name="eventActive">ต้องการให้ Event ทำงาน (ในกรณี Load ข้อมูล ไม่ควรเป็น true)</param>
        public void _cellUpdate(int row, string columnName, Object data, Boolean eventActive)
        {
            try
            {
                int __column = _findColumnByName(columnName);
                if (__column != -1) _cellUpdate(row, __column, data, eventActive);
            }
            catch
            {
            }
        }

        /// <summary>
        /// เรียกข้อมูลจาก Datagrid จะ Return ให้เป็น Object เพราะฉะนั้น โปรแกรมเมอร์จะต้องทำการระบุเองว่าเป็น TypeOf อะไร
        /// </summary>
        /// <param name="row">ตำแหน่ง row เริ่มจาก 0</param>
        /// <param name="column">ตำแหน่ง column เริ่มจาก 0</param>
        /// <returns>Object มีสามแบบคือ string,Integer,DateTime</returns>
        public object _cellGet(int row, int column)
        {
            try
            {
                if (row >= 0 && row < _rowData.Count && row != -1 && column != -1)
                {
                    try
                    {
                        return (((ArrayList)_rowData[row])[column]);
                    }
                    catch
                    {
                        return (true);
                    }
                }
                else
                {
                    _columnType __getColumn = (_columnType)_columnList[column];
                    if (__getColumn._type == 1) return ("");
                    if (__getColumn._type == 2) return (0);
                    if (__getColumn._type == 3) return (0.0);
                    if (__getColumn._type == 4) return (new DateTime());
                    return (null);
                }
            }
            catch
            {
                return (null);
            }
        }

        /// <summary>
        /// เรียกข้อมูลจาก Datagrid จะ Return ให้เป็น Object เพราะฉะนั้น โปรแกรมเมอร์จะต้องทำการระบุเองว่าเป็น TypeOf อะไร
        /// </summary>
        /// <param name="row">ตำแหน่ง row เริ่มจาก 0</param>
        /// <param name="columnName">ชื่อของ Column</param>
        /// <returns>Object มีสามแบบคือ string,Integer,DateTime</returns>
        public object _cellGet(int row, string columnName)
        {
            return this._cellGet(row, columnName);
        }

        #endregion

        #region Input Control Event Handler

        void checkKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13 || e.KeyChar == 9)
            {
                e.Handled = true;
            }
            else
            {
                base.OnKeyPress(e);
            }
        }

        void textBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkKeyPress(sender, e);
        }

        void _inputTextBox__cellMoveLeft(object sender)
        {
            cellFlowPrevColumn();
        }

        void _inputTextBox__cellMoveRight(object sender)
        {
            cellFlowNextColumn();
        }

        void _inputTextBox__cellSearch(object sender, string e)
        {
            if (this._selectColumn != -1)
            {
                _inputTextBox.textBox.LostFocus -= new EventHandler(textBox_LostFocus);
                GridCellEventArgs __data = new GridCellEventArgs();
                __data._column = this._selectColumn;
                __data._row = this._selectRow;
                __data._columnName = ((_columnType)_columnList[this._selectColumn])._originalName;
                __data._text = e;
                _clickSearchButtonWork(__data);
                _inputTextBox.textBox.LostFocus += new EventHandler(textBox_LostFocus);
            }
        }

        void _inputNumberBox__beforeCheckNumberValue(object sender, string valueStr)
        {
            if (this._beforeNumberBoxCheckValue != null)
            {
                this._beforeNumberBoxCheckValue(sender, valueStr, _selectRow, this._selectColumn);
            }
        }

        void _inputNumberBox__afterSelectCalculator(decimal e)
        {
            this._inputNumberBox._double = e;
            if (this._inputNumberBox._checkNumber()) _cellUpdate(_selectRow, this._selectColumn, this._inputNumberBox._double, true);
        }

        void _inputComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            checkKeyPress(sender, e);
        }

        void _inputComboBox__cellMoveLeft(object sender)
        {
            cellFlowPrevColumn();
        }

        void _inputComboBox__cellMoveRight(object sender)
        {
            cellFlowNextColumn();
        }

        void _inputComboBox_LostFocus(object sender, EventArgs e)
        {
            this._removeLastControl();
        }

        void _inputComboBox_LocationChanged(object sender, EventArgs e)
        {
            this._removeLastControl();
        }

        void _inputComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            this._removeLastControl();
        }

        void _inputDateBox__cellMoveLeft(object sender)
        {
            cellFlowPrevColumn();
        }

        void _inputDateBox__cellMoveRight(object sender)
        {
            cellFlowNextColumn();
        }

        void _inputDateBox__cellSearch(object sender, string e)
        {

        }

        void _inputDateBox__afterSelectCalendar(DateTime e)
        {
            _inputDateBox._dateTime = e.Date;
            _inputDateBox._checkDate(true, true);
            _cellUpdate(_selectRow, this._selectColumn, _inputDateBox._dateTime, true);
        }

        #endregion

        #region Event Handler
        protected virtual Boolean _beforeCellUpdateWork(GridCellEventArgs e)
        {
            if (_beforeCellUpdate != null) return (_beforeCellUpdate(this, e));
            return (true);
        }

        protected virtual void _afterCellUpdateWork(int row, int column)
        {
            if (_alterCellUpdate != null)
            {
                _alterCellUpdate(this, row, column);

            }
        }

        public bool isCellSelected(int row, int col)
        {
            var cellFind = this.selectedCell.Find(x => x._row == row && x._column == col);
            if (cellFind != null)
                return true;
            return false;
        }

        void _hScrollBarProcess()
        {
            _hScrollBar1.SuspendLayout();
            if (_recalcColumnWidth(false) + (_displayStartY - 1) > this.Width)
            {
                int __calc = (this.BorderStyle == BorderStyle.None) ? 17 : 19;
                _hScrollBar1.Visible = true;
                _hScrollBar1.LargeChange = 1;
                _hScrollBar1.Minimum = 0;
                _hScrollBar1.Maximum = _countColumnOver + 1;
                _hScrollBar1.Location = new Point(0, this.Height - __calc);
                _hScrollBar1.Width = this.Width - ((_vScrollBar1.Visible) ? __calc : 0);
            }
            else _hScrollBar1.Visible = false;
            _hScrollBar1.ResumeLayout(false);
            _hScrollBar1.Invalidate();
        }

        void _vScrollBarProcess()
        {
            if (this._vScrollBarLock == false)
            {
                _vScrollBar1.SuspendLayout();
                int __rowPerPage = (int)(_calcHeight(false) / _cellHeight) - 1;
                if (_rowData.Count > __rowPerPage)
                {
                    int __calc = (this.BorderStyle == BorderStyle.None) ? 17 : 19;
                    if (_vScrollBar1.Visible == false)
                    {
                        _vScrollBar1.Visible = true;
                        _vScrollBar1.LargeChange = 1;
                        _recalcColumnWidth(true);
                    }
                    _vScrollBar1.Minimum = 0;
                    _vScrollBar1.Maximum = (_rowData.Count - __rowPerPage) + 1;
                    _vScrollBar1.Location = new Point(this.Width - __calc, 0);
                    _vScrollBar1.Height = this.Height - ((_hScrollBar1.Visible) ? __calc : 0);
                }
                else
                {
                    _vScrollBar1.Visible = false;
                }
                _vScrollBar1.ResumeLayout(false);
                _vScrollBar1.Invalidate();
            }
        }

        public void addSelectedCell()
        {
            if (this._mouseIsDrag == true)
                return;

            Boolean append = false;
            if ((Control.ModifierKeys & Keys.Control) == Keys.Control)
            {
                append = true;
            }
            addSelectedCell(this.SelectRow, this._selectColumn, append);
        }

        public void addSelectedCell(int row, int col, bool append = false)
        {
            _myGridCell cell = new _myGridCell();
            cell._row = row;
            cell._column = col;

            if (append == false)
            {
                this.selectedCell.Clear();
                this.selectedCell.Add(cell);
            }
            else
            {
                int findIndex = this.selectedCell.FindIndex(c => c._row == cell._row && c._column == cell._column);
                if (findIndex != -1 && this._mouseIsDrag == false)
                {
                    this.selectedCell.RemoveAt(findIndex);
                }
                else
                {
                    this.selectedCell.Add(cell);
                }
            }
        }




        void textBox_LostFocus(object sender, EventArgs e)
        {
            // _removeLastControl();
            ((_myTextBox)((TextBox)sender).Parent).Visible = false;
            if (_lostFocusCell != null && _lastSelectColumn != -1)
            {
                _lostFocusCell(sender, _lastSelectRow, _lastSelectColumn, ((_columnType)_columnList[_lastSelectColumn])._originalName);
            }
        }


        protected virtual void _mouseClickWork(GridCellEventArgs e)
        {
            this.Focus();

            if (e._row == -1 && _mouseClickHeader != null && this._mouseClickEnable)
            {
                {
                    _mouseClickHeader(this, e);
                }
            }

            if (_mouseClick != null && this._mouseClickEnable)
            {

                if (e._row != -1)
                {
                    // โต๋ กันคลิ๊กหัวตาราง ไม่ต้องทำ event
                    _mouseClick(this, e);
                }
            }
            if (this._mouseClickEnable == false)
            {
                // กรณีใช้แบบ Multi Select
                if (_mouseClick2 != null) _mouseClick2(this, e);
            }
        }

        protected virtual void _mouseDoubleClickWork(GridCellEventArgs e)
        {
            this.Focus();
            if (_mouseDoubleClick != null) _mouseDoubleClick(this, e);
        }

        protected virtual void _clickSearchButtonWork(GridCellEventArgs e)
        {
            if (_clickSearchButton != null) _clickSearchButton(this, e);
        }

        #endregion

        #region Grid Mouse Event Handler 


        void _myGrid_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus();
            if (_columnSplitActive == false)
            {
                if (this._selectRow == -1)
                {
                    this._selectColumn = _findColumnNumber(e);
                    if (this._selectColumn != -1)
                    {
                        GridCellEventArgs getData = new GridCellEventArgs();
                        getData._column = this._selectColumn;
                        getData._columnName = ((_columnType)_columnList[this._selectColumn])._originalName;
                        getData._row = -1;
                        getData._text = "";
                        _mouseClickWork(getData);
                    }
                }
                else if (this._selectRow >= 0 && this._selectRow < _rowData.Count)
                {
                    this._selectColumn = _findColumnNumber(e);
                    if (this._selectColumn >= 0)
                    {
                        if (((_columnType)_columnList[this._selectColumn])._isEdit)
                        {
                            if (((_columnType)_columnList[this._selectColumn])._type == 11)
                            {
                                //***
                                _cellUpdate(this._selectRow, this._selectColumn, (((int)_cellGet(this._selectRow, this._selectColumn)) == 0) ? 1 : 0, true);
                                _cellUpdate(this._selectRow, _columnList.Count, true, true);
                            }
                            else
                            {
                                GridCellEventArgs __getData = new GridCellEventArgs();
                                __getData._column = this._selectColumn;
                                __getData._columnName = ((_columnType)_columnList[this._selectColumn])._originalName;
                                __getData._row = this._selectRow;
                                try
                                {
                                    object __getCellObject = _cellGet(_selectRow, 0);
                                    __getData._text = __getCellObject == null ? "" : __getCellObject.ToString();
                                }
                                catch
                                {
                                    __getData._text = "";
                                    // Debugger.Break();
                                }
                                _mouseClickWork(__getData);
                            }
                            if (this._selectColumn >= 0)
                            {
                                if (((_columnType)_columnList[this._selectColumn])._type == 12)
                                {
                                    if (_mouseClickClip != null)
                                    {
                                        GridCellEventArgs __getData = new GridCellEventArgs();
                                        __getData._column = this._selectColumn;
                                        __getData._columnName = ((_columnType)_columnList[this._selectColumn])._originalName;
                                        __getData._row = this._selectRow;
                                        __getData._object = _cellGet(_selectRow, this._selectColumn);
                                        _mouseClickClip(this, __getData);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        void _myGrid_MouseUp(object sender, MouseEventArgs e)
        {
            this._mouseIsDown = false;
            this._mouseIsDrag = false;
            this._columnSplitActive = false;
            this.Cursor = Cursors.Arrow;
        }

        void _myGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_columnSplitActive == false && this._isEdit == false)
            {
                this._selectColumn = _findColumnNumber(e);
                this.Focus();
                GridCellEventArgs __getData = new GridCellEventArgs();
                __getData._column = this._selectColumn;
                __getData._row = this._selectRow;
                try
                {
                    __getData._columnName = ((_columnType)_columnList[this._selectColumn])._originalName;
                    object __getCellObject = _cellGet(_selectRow, 0);
                    __getData._text = (__getCellObject != null) ? __getCellObject.ToString() : "";
                }
                catch
                {
                    __getData._text = "";
                    // Debugger.Break();
                }
                _mouseDoubleClickWork(__getData);
            }
        }

        void _myGrid_MouseLeave(object sender, EventArgs e)
        {
            this._selectRowFromMouseLast = this._selectRowFromMouse;
            this._selectRowFromMouse = -1;
            this._selectColumnFromMouse = -1;
            if (this._drawing == false)
            {
                this.Invalidate();
            }
        }

        void _myGrid_MouseMove(object sender, MouseEventArgs e)
        {
            if (this._mouseIsDown && this.AllowDrop && _columnSplitActive == false)
            {
                // เลื่อน Drag and Drop
                this.DoDragDrop(this, DragDropEffects.Copy);
                this._mouseIsDown = false;
            }
            else if (this._mouseIsDown && this.showSelectedCellHighlight == true)
            {
                this._selectRowFromMouse = this._rowFirst + (int)((e.Y - this._getTopY) / _cellHeight) - 1;
                this._selectColumnFromMouse = _findColumnNumber(e);
                if (_columnSplitActive == false)
                {
                    if (this._selectRowFromMouse != this._selectRow || this._selectColumnFromMouse != this._selectColumn)
                    {
                        this._mouseIsDrag = true;
                        this._selectRow = this._selectRowFromMouse;
                        this._selectColumn = this._selectColumnFromMouse;

                        this.addSelectedCell(this._selectRowFromMouse, this._selectColumnFromMouse, true);
                    }
                }
                else
                {
                    // เลื่อนขนาด Column
                    _columnType __getColumn = new _columnType();
                    __getColumn = (_columnType)_columnList[_columnSplitAddr];
                    _columnSplitMoveValue = e.X - _columnSplitFirstValue;
                    __getColumn._widthPoint = _columnSplitMoveValue;
                    _columnList[_columnSplitAddr] = __getColumn;
                    if (_removeLastControl())
                    {
                        _selectClear();
                        this._selectColumn = -1;
                    }
                }
            }
            else
            {
                this._mouseIsDown = false;
                this._selectRowFromMouse = (int)((e.Y - this._getTopY) / _cellHeight) - 1;
                this._selectColumnFromMouse = _findColumnNumber(e);
                if (_columnSplitActive)
                {
                    // เลื่อนขนาด Column
                    _columnType __getColumn = new _columnType();
                    __getColumn = (_columnType)_columnList[_columnSplitAddr];
                    _columnSplitMoveValue = e.X - _columnSplitFirstValue;
                    __getColumn._widthPoint = _columnSplitMoveValue;
                    _columnList[_columnSplitAddr] = __getColumn;
                    if (_removeLastControl())
                    {
                        _selectClear();
                        this._selectColumn = -1;
                    }
                }
                else
                {
                    bool __found = false;
                    for (int __loop = 1; __loop < _columnLineMax; __loop++)
                    {
                        if ((e.Y - this._getTopY) < 21 && e.X >= _columnLine[__loop] - 2 && e.X <= _columnLine[__loop] + 2)
                        {
                            __found = true;
                            _columnSplitAddr = __loop - 1;
                            _columnSplitFirstValue = _columnLine[__loop - 1];
                            break;
                        }
                    } // for
                    _columnSplitMode = __found;
                    this.Cursor = (__found) ? Cursors.VSplit : Cursors.Arrow;
                }
            }
            if (this._drawing == false)
            {
                this.Invalidate();
            }
        }

        void _myGrid_MouseWheel(object sender, MouseEventArgs e)
        {
            int __rowPerPage = (int)(_calcHeight() / _cellHeight) - 1;
            if (_removeLastControl())
            {
                _selectClear();
                if (e.Delta < 0)
                {
                    for (int __loop = 0; __loop < 5; __loop++)
                    {
                        if (_rowFirst < (_rowData.Count - __rowPerPage) + 1) _rowFirst++;
                    }
                }
                else
                {
                    for (int __loop = 0; __loop < 5; __loop++)
                    {
                        if (_rowFirst > 0) _rowFirst--;
                    }
                }
                if (this._drawing == false)
                {
                    this.Invalidate();
                }
            }
        }

        void _myGrid_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseIsDown = true;
        }



        private void myGrid_MouseDown(object sender, MouseEventArgs e)
        {
            float __columnWidth = 0;
            int __selectRow = 0;
            int __selectColumn = 0;

            //
            _columnType __getColumn = new _columnType();
            if (_columnSplitMode)
            {
                _columnSplitActive = true;
                _columnSplitMoveValue = 0;
            }
            else
            {
                try
                {
                    float __currentX = _displayStartY - 1;
                    if (e.X > _displayStartY - 1)
                    {
                        for (int __column = _columnFirst; __column < _columnList.Count; __column++)
                        {
                            __getColumn = (_columnType)_columnList[__column];
                            if (e.X >= __currentX && e.X <= __getColumn._widthPoint + __currentX)
                            {
                                __selectColumn = __column;
                                __columnWidth = __getColumn._widthPoint;
                                break;
                            }
                            __currentX += __getColumn._widthPoint;
                        } //for
                    }
                    __selectRow = _rowFirst + (int)(((e.Y - this._getTopY) / _cellHeight) - 1);
                    if ((e.Y - this._getTopY) <= _cellHeight)
                    {
                        // click column header
                        if (_removeLastControl())
                        {
                            _selectClear();
                            this._selectColumn = -1;
                        }
                    }
                    else
                    {
                        if (e.X > _displayStartY - 1)
                        {
                            __getColumn = (_columnType)_columnList[__selectColumn];
                            if (__getColumn._isEdit)
                            {
                                _inputCell(__selectRow, __selectColumn);
                            }
                            else
                            {
                                if (_removeLastControl())
                                {
                                    _selectClear();
                                    this._selectColumn = -1;
                                    this._selectRow = __selectRow;
                                }
                            }
                            if (this.showSelectedCellHighlight)
                            {
                                this.addSelectedCell();
                            }
                        }
                        else
                        {
                            if (_removeLastControl())
                            {
                                // ไม่ได้กดบริเวณข้อมูล
                                this._selectColumn = -1;
                                _selectClear();
                            }
                        }
                    }
                }
                catch (Exception __ex)
                {
                    MessageBox.Show(__ex.Message.ToString());
                }
            }
        }

        #endregion

        #region Grid ScrollBar Event Handler 

        void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            _rowFirst = _vScrollBar1.Value;
            this.Invalidate();
        }

        void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _removeLastControl();
        }

        void _vScrollBar1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void _vScrollBar1_VisibleChanged(object sender, EventArgs e)
        {
            this._recalcColumnWidth(true);
            this.Invalidate();
        }

        void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            if (_hScrollBar1.Value >= 0 && _hScrollBar1.Visible)
            {
                _columnFirst = _hScrollBar1.Value;
                this.Invalidate();
            }
        }

        void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            _removeLastControl();
        }

        void _hScrollBar1_MouseEnter(object sender, EventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        void _hScrollBar1_VisibleChanged(object sender, EventArgs e)
        {
            this._recalcColumnWidth(true);
            this.Invalidate();
        }

        #endregion

        #region Grid Event Handler 

        void _myGrid_GotFocus(object sender, EventArgs e)
        {
            _gotoCell(_selectRow, this._selectColumn);
        }

        void _myGrid_DragOver(object sender, DragEventArgs e)
        {
            Point __getPoint = this.PointToClient(Control.MousePosition);
            this._selectRowFromMouse = (__getPoint.Y / (int)_cellHeight) - 1;
            this.Invalidate();
        }


        void _myGrid_SizeChanged(object sender, EventArgs e)
        {
            _removeLastControl();
            _recalcColumnWidth(true);
            if (this._drawing == false)
            {
                this.Invalidate();
            }
        }



        void _myGrid_Invalidated(object sender, InvalidateEventArgs e)
        {
            this._calcTotal(false);
            _deleteRow.Enabled = this._isEdit;
            _insertRow.Enabled = this._isEdit;
            if (_showMenuInsertAndDeleteRow)
            {
                _deleteRow.Enabled = true;
                _insertRow.Enabled = true;
            }
            if (AddRow == false)
            {
                _deleteRow.Enabled = false;
                _insertRow.Enabled = false;
            }
        }

        #endregion

        #region Grid Action Method 
        public float _recalcColumnWidth(Boolean recalc)
        {
            float __total = 0;
            _countColumnOver = 0;
            for (int __column = 0; __column < _columnList.Count; __column++)
            {
                if (recalc)
                {
                    ((_columnType)_columnList[__column])._widthPoint = (int)((_width_by_persent) ? ((this.Width - (_displayStartY - 1)) * ((_columnType)_columnList[__column])._widthPercent) / 100 : ((_columnType)_columnList[__column])._widthPercent);
                    if (__column == 0 && _vScrollBar1.Visible == true)
                    {
                        ((_columnType)_columnList[__column])._widthPoint -= 17;
                    }
                }
                __total += ((_columnType)_columnList[__column])._widthPoint;
                if (__total > this.Width - _displayStartY)
                {
                    _countColumnOver++;
                }
            }
            return (__total);
        }

        #endregion

        #region Grid Internal Process(Paint, Calc) 


        public float _calcHeight(bool includeRowHeader = true)
        {
            int __height = this.Height;
            if (_hScrollBar1.Visible)
            {
                __height -= (this.BorderStyle == BorderStyle.None) ? 17 : 19;
            }

            if (includeRowHeader == false)
            {
                __height -= (int)_cellHeight;
            }

            if (this._total_show)
            {
                return (__height - _cellHeight);
            }

            return (__height - this._getTopY);
        }

        private object _dataObjectBlank(int type)
        {
            switch (type)
            {
                case 2: return ((int)0);
                case 3:
                case 5: return ((decimal)0.0);
                case 4: return (new DateTime(1000, 1, 1)); // Date
                case 10: return ((int)0); // ComboBox
                case 11: return ((int)0); ;// CheckBox
                case 12: return null;// Object
            }
            return "";
        }

        void _selectClear()
        {
            this._selectRow = -1;
            _lastSelectColumn = -1;
            _lastSelectRow = -1;
        }

        public void _calcHeightCalc()
        {
            // calc cell height;
            if (this.DesignMode == false)
            {
                //float __cellHeightTemp = this.CreateGraphics().MeasureString("Test", this.Font).Height;
                float __cellHeightTemp = this.Font.GetHeight() + 2;
                if (this._cellHeight < __cellHeightTemp)
                {
                    this._cellHeight = __cellHeightTemp;
                }
            }
        }

        int _findColumnNumber(MouseEventArgs e)
        {
            float __currentX = _displayStartY - 1;
            for (int __column = _columnFirst; __column < _columnList.Count; __column++)
            {
                _columnType __getColumn = (_columnType)_columnList[__column];
                if (e.X >= __currentX && e.X <= __getColumn._widthPoint + __currentX)
                {
                    return (__column);
                }
                __currentX += __getColumn._widthPoint;
            } //for
            return (-1);
        }

        /// <summary>
        /// บันทึก Control ล่าสุด เพื่อเตรียมการบันทึกต่อไป
        /// </summary>
        /// <param name="removeControl"></param>
        /// <returns></returns>
        public bool _removeLastControl()
        {
            if (this._lastControl != null)
            {
                if (this._lostFocusCell != null && this._lastSelectColumn != -1 && this._lastSelectRow != -1)
                {
                    this._lostFocusCell(this._lastControl, this._lastSelectRow, this._lastSelectColumn, ((_columnType)this._columnList[_lastSelectColumn])._originalName);
                }
                try
                {
                    if (this._selectColumn != -1)
                    {
                        _columnType __getColumn = (_columnType)_columnList[this._selectColumn];
                        if (__getColumn._isEdit)
                        {
                            switch (__getColumn._type)
                            {
                                case 1:
                                    _myTextBox __textBoxTemp1 = ((_myTextBox)this._lastControl);
                                    this._lastControl = null;
                                    this._cellUpdate(_selectRow, this._selectColumn, __textBoxTemp1.textBox.Text, true);
                                    __textBoxTemp1.Visible = false;
                                    break;
                                case 2:
                                    _myNumberBox __textBoxTemp2 = ((_myNumberBox)this._lastControl);
                                    this._lastControl = null;
                                    if (__textBoxTemp2._checkNumber()) this._cellUpdate(this._selectRow, this._selectColumn, (int)__textBoxTemp2._double, true);
                                    __textBoxTemp2.Visible = false;
                                    break;
                                case 3:
                                case 5:
                                    _myNumberBox __textBoxTemp3 = ((_myNumberBox)this._lastControl);
                                    this._lastControl = null;
                                    if (this._beforeNumberBoxCheckValue != null)
                                    {
                                        this._beforeNumberBoxCheckValue(__textBoxTemp3, __textBoxTemp3.textBox.Text, _selectRow, this._selectColumn);
                                    }
                                    if (__textBoxTemp3._checkNumber()) this._cellUpdate(this._selectRow, this._selectColumn, __textBoxTemp3._double, true);
                                    __textBoxTemp3.Visible = false;
                                    break;
                                case 4:
                                    _myDateBox __textBoxTemp4 = ((_myDateBox)this._lastControl);
                                    this._lastControl = null;
                                    __textBoxTemp4._checkDate(true, true);
                                    __textBoxTemp4.textBox.Text = "";
                                    __textBoxTemp4._beforeInput();
                                    this._cellUpdate(this._selectRow, this._selectColumn, __textBoxTemp4._dateTime, true);
                                    __textBoxTemp4.Visible = false;
                                    break;
                                case 10:
                                    _myComboBox __myComboBox = ((_myComboBox)this._lastControl);
                                    this._lastControl = null;
                                    this._cellUpdate(this._selectRow, this._selectColumn, __myComboBox.SelectedIndex, true);
                                    __myComboBox.DroppedDown = false;
                                    __myComboBox.Visible = false;
                                    break;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    string __errorMessage = "Save Last Control Error : " + ex.Message;
                    System.Console.Out.WriteLine(__errorMessage);
                    MessageBox.Show(__errorMessage);

                    //if (_myGlobal._isUserSupport)
                    //{
                    //    _myGlobal._writeEventLog(__errorMessage);
                    //}
                    // Debugger.Break();
                }
                this._lastControl = null;
            }
            return (true);
        }


        public void cellFlowNextColumn()
        {
            _removeLastControl();
            if (this._stopMove)
            {
                this._stopMove = false;
                return;
            }
            int __newColumn = this._selectColumn + 1;
            int __newRow = this._selectRow;
            // เลื่อนไปด้านขวา
            if (__newColumn == this._columnList.Count)
            {
                if (__newRow == _rowData.Count - 1 && AddRow)
                {
                    _addRow();
                }
                __newRow++;
                if (__newRow >= this._rowData.Count)
                {
                    __newRow--;
                }
                __newColumn = 0;
            }
            while (((_columnType)_columnList[__newColumn])._isHide == true || ((_columnType)_columnList[__newColumn])._isEdit == false)
            {
                __newColumn++;
                if (__newColumn == this._columnList.Count)
                {
                    if (__newRow == _rowData.Count - 1 && AddRow)
                    {
                        _addRow();
                    }
                    __newRow++;
                    if (__newRow >= this._rowData.Count)
                    {
                        __newRow--;
                    }
                    __newColumn = 0;
                }
            } // while
            if (_selectColumn < this._columnList.Count - 1)
            {
                if (_moveNextColumn != null)
                {
                    _myGridMoveColumnType __getNewLoction = _moveNextColumn(this, __newRow, __newColumn);
                    __newRow = __getNewLoction._newRow;
                    __newColumn = __getNewLoction._newColumn;
                }
                _inputCell(__newRow, __newColumn);
            }
            else
            {
                if (_selectRow == _rowData.Count - 1 && AddRow)
                {
                    _addRow();
                }
                if (_moveNextColumn != null)
                {
                    _myGridMoveColumnType __getNewLoction = _moveNextColumn(this, __newRow, __newColumn);
                    __newRow = __getNewLoction._newRow;
                    __newColumn = __getNewLoction._newColumn;
                }
                _inputCell(__newRow, __newColumn);
            }
        }

        void cellFlowPrevColumn()
        {
            _removeLastControl();
            if (this._stopMove)
            {
                this._stopMove = false;
                return;
            }
            // เลื่อนไปด้านซ้าย
            int __newColumn = this._selectColumn;
            int __newRow = this._selectRow;
            do
            {
                __newColumn--;
                if (__newColumn == -1)
                {
                    __newColumn = _columnList.Count - 1;
                    __newRow--;
                    if (__newRow == -1)
                    {
                        __newRow = 0;
                        break;
                    }
                }
            } while (((_columnType)_columnList[__newColumn])._isHide == true || ((_columnType)_columnList[__newColumn])._isEdit == false);
            if (_selectColumn > 0)
            {
                if (_movePrevColumn != null)
                {
                    _myGridMoveColumnType __getNewLoction = _movePrevColumn(this, __newRow, __newColumn);
                    __newRow = __getNewLoction._newRow;
                    __newColumn = __getNewLoction._newColumn;
                }
                _inputCell(__newRow, __newColumn);
            }
            else
            {
                if (_selectRow > 0)
                {
                    if (_movePrevColumn != null)
                    {
                        _myGridMoveColumnType __getNewLoction = _movePrevColumn(this, __newRow, __newColumn);
                        __newRow = __getNewLoction._newRow;
                        __newColumn = __getNewLoction._newColumn;
                    }
                    _inputCell(__newRow, __newColumn);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            // ตรวจสอบว่ามี Background หรือไม่ (Column Background)
            try
            {
                this.SuspendLayout();
                this._drawing = true;
                bool _haveBackground = false;
                for (int __columnLoop = _columnFirst; __columnLoop < (int)_columnList.Count && _haveBackground == false; __columnLoop++)
                {
                    if (((_columnType)_columnList[__columnLoop])._backColorOn)
                    {
                        _haveBackground = true;
                        break;
                    }
                }
                //
                if (_rowFirst < 0)
                {
                    _rowFirst = 0;
                }
                /*if (_isEdit)
                {
                    // toe
                    if (this._cellHeight <= 16)
                    {
                        _cellHeight = 21;
                    }
                }*/
                float __topPixel = (this._columnTopActive == true) ? ((_isEdit) ? (_cellHeight * 2) : (_cellHeight * 2)) : _cellHeight;
                Graphics __g = pe.Graphics;
                Pen __myPen1 = new Pen(Color.Gainsboro, 0);
                Pen __myPen2 = new Pen(Color.White, 0);
                int __rowNumber = _rowFirst;
                int __rowEnd = (int)(_calcHeight(false) / _cellHeight);
                _rowPerPage = __rowEnd;
                if (this._total_show)
                {
                    _rowPerPage -= 1;
                }
                for (int __row = 0; __row < __rowEnd; __row++)
                {
                    float __calcPoint = ((float)__row * _cellHeight) + (float)__topPixel;
                    Point[] boxPoints = {
                        new Point(0,(int)__calcPoint),
                        new Point(this.Width,(int)__calcPoint),
                        new Point(this.Width,(int)(__calcPoint+_cellHeight)),
                        new Point(0,(int)(__calcPoint+_cellHeight))
                    };
                    GraphicsPath __background = new GraphicsPath();
                    __background.AddPolygon(boxPoints);
                    // Define fill mode.
                    FillMode __newFillMode = FillMode.Winding;
                    LinearGradientBrush __blueBrush;
                    Color __lastBackGroundColor;
                    if (__row + _rowFirst == this._selectRow)
                    {
                        __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), Color.LightCyan, Color.LightCyan);
                        __lastBackGroundColor = Color.LightCyan;
                    }
                    else
                    {
                        if ((__rowNumber % 2) == 0)
                        {
                            __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), _RowBackground1, _RowBackground1);
                            __lastBackGroundColor = _RowBackground1;
                        }
                        else
                        {
                            __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), _RowBackground2, _RowBackground2);
                            __lastBackGroundColor = _RowBackground2;
                        }
                        //
                        if (_selectRowFromMouse == __row)
                        {
                            __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), Color.AliceBlue, Color.AliceBlue);
                            __lastBackGroundColor = Color.AliceBlue;
                        }
                        else
                        {
                            if ((__rowNumber % 2) == 0)
                            {
                                __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), (Enabled) ? _RowBackground1 : Color.WhiteSmoke, (Enabled) ? _RowBackground1 : Color.WhiteSmoke);
                                __lastBackGroundColor = _RowBackground1;
                            }
                            else
                            {
                                __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), (Enabled) ? _RowBackground2 : Color.White, (Enabled) ? _RowBackground2 : Color.White);
                                __lastBackGroundColor = _RowBackground2;
                            }
                        }
                    }
                    if (this._total_show && __row == __rowEnd - ((this._columnTopActive) ? 2 : 1))
                    {
                        __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), Color.LightYellow, Color.LightYellow);
                        __lastBackGroundColor = Color.LightYellow;
                    }
                    // Draw polygon to screen.
                    __g.FillPolygon(__blueBrush, boxPoints, __newFillMode);
                    // Background
                    if (_haveBackground)
                    {
                        float __currentColumnX;
                        if (DisplayRowNumber)
                        {
                            __currentColumnX = 40;
                        }
                        else
                        {
                            __currentColumnX = 1;
                        }
                        for (int __column = _columnFirst; __column < _columnList.Count; __column++)
                        {
                            float __columnWidthPoint;
                            _columnType __getColumnforBackground = (_columnType)_columnList[__column];
                            __columnWidthPoint = __getColumnforBackground._widthPoint;
                            // สีพื้น
                            if (__getColumnforBackground._backColorOn)
                            {
                                PointF[] __columnMixedBoxPoints = {
                                new PointF(__currentColumnX,__calcPoint),
                                new PointF((__currentColumnX+__columnWidthPoint),__calcPoint),
                                new PointF((__currentColumnX+__columnWidthPoint),(__calcPoint+_cellHeight)),
                                new PointF((__currentColumnX),(__calcPoint+_cellHeight))
                            };
                                Color __newColor = ColorTranslator.FromOle(__lastBackGroundColor.ToArgb() & __getColumnforBackground._backColor.ToArgb());
                                __g.FillPolygon(new SolidBrush(__newColor), __columnMixedBoxPoints, FillMode.Winding);
                            }
                            __currentColumnX += __columnWidthPoint;
                        } //for column
                    }

                    if (_selectRowFromMouse == __row)
                    {
                        if (this.displayCellHoverHighlight)
                        {
                            float __currentColumnX;
                            if (DisplayRowNumber)
                            {
                                __currentColumnX = 40;
                            }
                            else
                            {
                                __currentColumnX = 1;
                            }
                            for (int __column = _columnFirst; __column < _columnList.Count; __column++)
                            {
                                float __columnWidthPoint;
                                _columnType __getColumnforBackground = (_columnType)_columnList[__column];
                                __columnWidthPoint = __getColumnforBackground._widthPoint;

                                if (_selectColumnFromMouse == __column)
                                {
                                    PointF point1 = new PointF(__currentColumnX, __calcPoint);
                                    PointF point2 = new PointF((__currentColumnX + __columnWidthPoint), __calcPoint);
                                    PointF point3 = new PointF((__currentColumnX + __columnWidthPoint), (__calcPoint + (_cellHeight - 1)));
                                    PointF point4 = new PointF((__currentColumnX), (__calcPoint + (_cellHeight - 1)));

                                    //Color __newColor = ColorTranslator.FromOle(__lastBackGroundColor.ToArgb() & __getColumnforBackground._backColor.ToArgb());
                                    //__g.FillPolygon(new SolidBrush(__newColor), __columnMixedBoxPoints, FillMode.Winding);
                                    //__g.DrawPolygon(new Pen(highlightColor), __columnMixedBoxPoints);

                                    __g.DrawLine(new Pen(highlightColor), point1, point2);
                                    __g.DrawLine(new Pen(highlightColor), point2, point3);
                                    __g.DrawLine(new Pen(highlightColor), point3, point4);
                                    __g.DrawLine(new Pen(highlightColor), point4, point1);

                                }
                                __currentColumnX += __columnWidthPoint;

                            }
                        }
                    }

                    if (this.showSelectedCellHighlight == true && this.selectedCell.Count > 0)
                    {
                        float __currentColumnX;
                        if (DisplayRowNumber)
                        {
                            __currentColumnX = 40;
                        }
                        else
                        {
                            __currentColumnX = 1;
                        }
                        for (int __column = _columnFirst; __column < _columnList.Count; __column++)
                        {
                            float __columnWidthPoint;
                            _columnType __getColumnforBackground = (_columnType)_columnList[__column];
                            __columnWidthPoint = __getColumnforBackground._widthPoint;

                            bool isCellSelected = this.isCellSelected(this._rowFirst + __row, __column);

                            if (isCellSelected)
                            {
                                //PointF point1 = new PointF(__currentColumnX, __calcPoint);
                                //PointF point2 = new PointF((__currentColumnX + __columnWidthPoint), __calcPoint);
                                //PointF point4 = new PointF((__currentColumnX + __columnWidthPoint), (__calcPoint + (_cellHeight - 1)));
                                //PointF point3 = new PointF((__currentColumnX), (__calcPoint + (_cellHeight - 1)));
                                //__g.DrawLine(new Pen(highlightColor), point1, point2);
                                //__g.DrawLine(new Pen(highlightColor), point1, point3);
                                //__g.DrawLine(new Pen(highlightColor), point2, point4);
                                //__g.DrawLine(new Pen(highlightColor), point3, point4);

                                PointF[] __columnMixedBoxPoints = {
                                    new PointF(__currentColumnX,__calcPoint),
                                    new PointF((__currentColumnX+__columnWidthPoint),__calcPoint),
                                    new PointF((__currentColumnX+__columnWidthPoint),(__calcPoint+_cellHeight)),
                                    new PointF((__currentColumnX),(__calcPoint+_cellHeight))
                                };


                                Color __newColor = ColorTranslator.FromOle(__lastBackGroundColor.ToArgb() & highlightColor.ToArgb());
                                __g.FillPolygon(new SolidBrush(__newColor), __columnMixedBoxPoints, FillMode.Winding);
                                //__g.DrawPolygon(new Pen(highlightColor), __columnMixedBoxPoints);

                            }
                            __currentColumnX += __columnWidthPoint;

                        }
                    }

                    __g.DrawPath(__myPen2, __background);
                    //
                    PointF[] __rowBoxPoints = {
                        new PointF(0,__calcPoint),
                        new PointF(_displayStartY-1,__calcPoint),
                        new PointF(_displayStartY-1,(__calcPoint+_cellHeight)),
                        new PointF(0,(__calcPoint+_cellHeight))
                    };
                    GraphicsPath __background2 = new GraphicsPath();
                    __background2.AddPolygon(__rowBoxPoints);
                    // วาดเส้นบรรทัด
                    __g.DrawLine(__myPen1, 0f, __calcPoint, (float)this.Width, __calcPoint);


                    // Draw polygon to screen.
                    if (DisplayRowNumber)
                    {
                        LinearGradientBrush __blueBrush2;
                        if (__row + _rowFirst == this._selectRow)
                        {
                            __blueBrush2 = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), Color.FromArgb(255, 200, 149), Color.FromArgb(255, 154, 103));
                        }
                        else
                        {
                            __blueBrush2 = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), (this.ColumnBackgroundAuto) ? _columnBackgroundBeginAuto : _columnBackground, (this.ColumnBackgroundAuto) ? _columnBackgroundEndAuto : _columnBackgroundEnd);
                            if (__rowNumber < _rowData.Count && __rowNumber >= 0)
                            {
                                //***
                                if (__rowNumber < _rowData.Count)
                                {
                                    if ((Boolean)_cellGet(__rowNumber, _columnList.Count) && this._isEdit)
                                    {
                                        __blueBrush2 = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), Color.FromArgb(0xff, 0xfc, 0xde), Color.FromArgb(0xff, 0xd9, 0x6d));
                                    }
                                }
                            }
                        }
                        __g.FillPolygon(__blueBrush2, __rowBoxPoints, FillMode.Winding);
                        __g.DrawPath(__myPen2, __background2);
                        __blueBrush2.Dispose();
                    }
                    string __strGet = (_rowStartNumber + __rowNumber + 1).ToString();
                    if (this._total_show && __row == __rowEnd - ((this._columnTopActive) ? 2 : 1))
                    {
                        __strGet = "Total";
                        if (this._columnTopActive)
                        {
                            __row++;
                        }
                    }
                    SizeF __stringSize = __g.MeasureString(__strGet, this._getFont);
                    if (DisplayRowNumber)
                    {
                        __g.DrawString(__strGet, this._getFont, new SolidBrush(Color.Black), 20 - (__stringSize.Width / 2), __calcPoint);
                    }
                    if (this._total_show && __row == __rowEnd - 1)
                    {
                        _displayTotal(__row, __g);
                    }
                    else
                    {
                        _displayRowData(__row, __rowNumber, __g);
                    }
                    //
                    __rowNumber++;
                    __background.Dispose();
                    __blueBrush.Dispose();
                } // for row
                float __currentX = 0;
                _columnType __getColumn = new _columnType();
                __g.DrawLine(__myPen1, 0, 21, 0, _calcHeight());
                _columnLineMax = 0;
                Color __fontColor = Color.Black;
                // Draw Top Column
                if (this._columnTopActive)
                {
                    float __columnCalc = (DisplayRowNumber) ? 40 : 1;
                    for (int __column = 0; __column < _columnListTop.Count; __column++)
                    {
                        _columnType __getColumnTop = (_columnType)_columnListTop[__column];
                        int __getBegin = __getColumnTop._columnBegin;
                        int __getEnd = __getColumnTop._columnEnd;
                        string __columnNameTop = (__getColumnTop._name.Length == 0) ? __getColumnTop._originalName : __getColumnTop._name;

                        if (__getBegin < _columnFirst)
                        {
                            __getBegin = _columnFirst;
                        }
                        float __startX = __columnCalc;
                        for (int __column2 = _columnFirst; __column2 < __getBegin; __column2++)
                        {
                            __startX += ((_columnType)_columnList[__column2])._widthPoint;
                        }
                        float __width = 0;
                        for (int __column2 = __getBegin; __column2 <= __getEnd; __column2++)
                        {
                            __width += ((_columnType)_columnList[__column2])._widthPoint;
                        }
                        //
                        PointF[] __curvePoints = {
                            new PointF(__startX,_cellHeight),
                            new PointF(__startX,2),
                            new PointF((__startX+2),0),
                            new PointF((__startX+__width-2),0),
                            new PointF((__startX+__width),2),
                            new PointF((__startX+__width),_cellHeight)
                        };
                        GraphicsPath __background = new GraphicsPath();
                        __background.AddPolygon(__curvePoints);
                        LinearGradientBrush __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), (this.ColumnBackgroundAuto) ? _columnBackgroundBeginAuto : _columnBackground, (this.ColumnBackgroundAuto) ? _columnBackgroundEndAuto : _columnBackgroundEnd);
                        __g.FillPolygon(__blueBrush, __curvePoints, FillMode.Winding);
                        __g.DrawPath(__myPen1, __background);
                        //
                        Font __newFont = new Font(this._getFont, FontStyle.Bold);
                        SizeF __stringSize = __g.MeasureString(__columnNameTop, __newFont);
                        float __calcFirstPoint = (__width / 2) - (__stringSize.Width / 2);
                        __g.DrawString(__columnNameTop, __newFont, new SolidBrush(__fontColor), __startX + __calcFirstPoint, 0);
                    }
                }
                // Show Column Name
                for (int __column = _columnFirst; __column <= _columnList.Count; __column++)
                {
                    float __columnWidthPoint;
                    string __columnName;
                    if (__column == _columnFirst)
                    {
                        if (DisplayRowNumber)
                        {
                            __columnName = "Line";
                            __columnWidthPoint = 40;
                        }
                        else
                        {
                            __columnName = "";
                            __columnWidthPoint = 1;
                        }
                    }
                    else
                    {
                        __getColumn = (_columnType)_columnList[__column - 1];
                        __columnWidthPoint = __getColumn._widthPoint;
                        __columnName = (__getColumn._name.Length == 0) ? __getColumn._originalName : __getColumn._name;
                        if (this._extraWordShow && __getColumn._extraWord.Length > 0)
                        {
                            __columnName = String.Concat(__columnName, " ", __getColumn._extraWord);
                        }
                        __fontColor = (__getColumn._isEdit) ? Color.Black : Color.Gray;
                    }
                    PointF[] __curvePoints = {
                        new PointF(__currentX,this._getTopY+_cellHeight),
                        new PointF(__currentX,this._getTopY+2),
                        new PointF(__currentX+2,this._getTopY+0),
                        new PointF((__currentX+__columnWidthPoint-2),this._getTopY+0),
                        new PointF((__currentX+__columnWidthPoint),this._getTopY+2),
                        new PointF((__currentX+__columnWidthPoint),(this._getTopY+_cellHeight)) };
                    GraphicsPath __background = new GraphicsPath();
                    __background.AddPolygon(__curvePoints);
                    // Define fill mode.
                    LinearGradientBrush __blueBrush;
                    if (__column == this._selectColumn + 1)
                    {
                        __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), Color.FromArgb(255, 200, 149), Color.FromArgb(255, 154, 103));
                    }
                    else
                    {
                        __blueBrush = new LinearGradientBrush(new Point(0, 0), new PointF(0, _cellHeight), (this.ColumnBackgroundAuto) ? _columnBackgroundBeginAuto : _columnBackground, (this.ColumnBackgroundAuto) ? _columnBackgroundEndAuto : _columnBackgroundEnd);
                    }
                    // Draw polygon to screen.
                    __g.FillPolygon(__blueBrush, __curvePoints, FillMode.Winding);
                    __g.DrawPath(__myPen1, __background);
                    string __strGet = __columnName;
                    SizeF __stringSize = __g.MeasureString(__strGet, this._getFont);
                    float __calcFirstPoint = __currentX + (__columnWidthPoint / 2) - (__stringSize.Width / 2);
                    if (__calcFirstPoint <= __currentX)
                    {
                        __calcFirstPoint = __currentX + 2;
                    }
                    if (__getColumn._isHide == false)
                    {
                        // เขียนชื่อ Column
                        __g.DrawString(__strGet, this._getFont, new SolidBrush(__fontColor), __calcFirstPoint, ((_isEdit) ? this._getTopY : this._getTopY));
                    }
                    __currentX += __columnWidthPoint;
                    // ขีดเส้นจากบนลงล่าง
                    __g.DrawLine(__myPen1, __currentX, this._cellHeight, __currentX, this.Height);
                    _columnLine[_columnLineMax++] = (int)__currentX;
                    __background.Dispose();
                    __blueBrush.Dispose();
                } //for column
                if (this._message.Length > 0)
                {
                    SizeF __stringSize = __g.MeasureString(this._message, this._getFont);
                    if (this._message.IndexOf("<b>") == -1)
                    {
                        __g.DrawString(this._message, this._getFont, new SolidBrush(__fontColor), 50, this.Height - __stringSize.Height);
                    }
                    else
                    {
                        string[] __messageLine = this._message.Replace("</b>", "\b").Replace("<b>", "\a").Replace("\r", "").Split('\n');
                        for (int __line = 0; __line < __messageLine.Length; __line++)
                        {
                            string __word = __messageLine[__line];
                            Boolean __bold = false;
                            float __start = 50;
                            StringBuilder __wordStr = new StringBuilder();
                            for (int __loop = 0; __loop < __word.Length; __loop++)
                            {
                                if (__word[__loop] == '\a')
                                {
                                    if (__wordStr.Length > 0)
                                    {
                                        Font __newFont = new Font(this._getFont.FontFamily, this._getFont.Size, (__bold) ? FontStyle.Bold : FontStyle.Regular);
                                        SizeF __wordSize = __g.MeasureString(__wordStr.ToString(), this._getFont);
                                        __g.DrawString(__wordStr.ToString(), __newFont, new SolidBrush(__fontColor), __start, this.Height - ((__messageLine.Length - __line) * (__stringSize.Height / __messageLine.Length)));
                                        __start += __wordSize.Width;
                                        __wordStr = new StringBuilder();
                                    }
                                    __bold = true;
                                }
                                else
                                    if (__word[__loop] == '\b')
                                {
                                    if (__wordStr.Length > 0)
                                    {
                                        Font __newFont = new Font(this._getFont.FontFamily, this._getFont.Size, (__bold) ? FontStyle.Bold : FontStyle.Regular);
                                        SizeF __wordSize = __g.MeasureString(__wordStr.ToString(), this._getFont);
                                        __g.DrawString(__wordStr.ToString(), __newFont, new SolidBrush(__fontColor), __start, this.Height - ((__messageLine.Length - __line) * (__stringSize.Height / __messageLine.Length)));
                                        __start += __wordSize.Width;
                                        __wordStr = new StringBuilder();
                                    }
                                    __bold = false;
                                }
                                else
                                {
                                    __wordStr.Append(__word[__loop]);
                                }
                            }
                            if (__wordStr.Length > 0)
                            {
                                Font __newFont = new Font(this._getFont.FontFamily, this._getFont.Size, (__bold) ? FontStyle.Bold : FontStyle.Regular);
                                SizeF __wordSize = __g.MeasureString(__wordStr.ToString(), this._getFont);
                                __g.DrawString(__wordStr.ToString(), __newFont, new SolidBrush(__fontColor), __start, this.Height - ((__messageLine.Length - __line) * (__stringSize.Height / __messageLine.Length)));
                            }
                        }
                    }
                }
                _hScrollBarProcess();
                _vScrollBarProcess();
                if (_rowFirst >= 0 && _rowFirst <= _vScrollBar1.Maximum)
                {
                    _vScrollBar1.Value = _rowFirst;
                }
                __myPen1.Dispose();
                __myPen2.Dispose();
                this._drawing = false;
                this.ResumeLayout();
            }
            catch (Exception __ex)
            {
                MessageBox.Show(__ex.Message.ToString()); // + " " + __ex.StackTrace.ToString()
            }
        }


        /// <summary>
        /// แสดงข้อมูลของบรรทัดนั้นๆ
        /// </summary>
        /// <param name="row">บรรทัดที่ต้องการแสดง</param>
        /// <param name="rowData">บรรทัดของข้อมูล</param>
        /// <param name="e">Graphics</param>
        void _displayRowData(int row, int rowData, Graphics e)
        {
            if (rowData < _rowData.Count)
            {
                float __calcPoint = ((row + 1) * _cellHeight) + this._getTopY;
                float __calcWidth = _displayStartY;
                _columnType __getColumn = new _columnType();
                for (int __column = _columnFirst; __column < _columnList.Count; __column++)
                {
                    bool __strCut = false;
                    __getColumn = (_columnType)_columnList[__column];
                    if (__getColumn._isHide == false && __getColumn._widthPercent != 0 && __getColumn._widthPoint != 0)
                    {
                        string __strDisplay = "";
                        int __align = 0;//0=left,1=right
                        BeforeDisplayRowReturn __newRow = new BeforeDisplayRowReturn();
                        __newRow.newFont = this._getFont; //this.Font;
                        __newRow.newColor = (__getColumn._isEdit) ? Color.Black : Color.Gray;
                        __newRow.newData = ((ArrayList)_rowData[rowData]).Clone();
                        //SOMRUK
                        if (_beforeDisplayRendering != null)
                        {
                            __newRow = _beforeDisplayRendering(this, rowData, __column, (this._table_name.Length == 0) ? __getColumn._originalName : (string.Concat(this._table_name, ".", __getColumn._originalName)), __newRow, __getColumn, (ArrayList)_rowData[rowData], e);
                        }
                        if (_beforeDisplayRow != null)
                        {
                            __newRow = _beforeDisplayRow(this, rowData, __column, (this._table_name.Length == 0) ? __getColumn._originalName : (string.Concat(this._table_name, ".", __getColumn._originalName)), __newRow, __getColumn, (ArrayList)_rowData[rowData]);
                        }
                        switch (__getColumn._type)
                        {
                            case 1:
                                {
                                    __strDisplay = (string)((ArrayList)__newRow.newData)[__column];
                                    if (__newRow.align == ContentAlignment.MiddleRight)
                                    {
                                        __align = 1;
                                    }
                                }
                                break;
                            case 2:
                                {
                                    int __dataInt = (int)((ArrayList)__newRow.newData)[__column];
                                    __strDisplay = __dataInt.ToString();
                                    __align = 1;
                                }
                                break;
                            case 3:
                            case 5:
                                {
                                    string __format2 = __getColumn._format;
                                    decimal __getDouble = (decimal)((ArrayList)__newRow.newData)[__column];

                                    if (_myGlobal.regexFormatNumberToStringChecker.IsMatch(__format2))
                                    {
                                        __strDisplay = (__getDouble == 0) ? "" : __getDouble.ToString(__format2);
                                    }
                                    else
                                    {
                                        if (__format2.Length > 0)
                                        {
                                            __format2 = Utils._numberUtils._getFormatNumber(__format2);
                                        }
                                        __strDisplay = (__getDouble == 0) ? "" : string.Format(__format2, __getDouble);
                                    }
                                    if (__getDouble < 0)
                                    {
                                        __newRow.newColor = Color.Red;
                                    }
                                    __align = 1;
                                }
                                break;
                            case 4:
                                {
                                    DateTime __getDateTime = (DateTime)((ArrayList)__newRow.newData)[__column];
                                    if (__getDateTime.Year > 1900)
                                    {
                                        try
                                        {
                                            string __format3 = __getColumn._format;
                                            if (__format3.Length == 0)
                                            {
                                                __strDisplay = Utils._dateUtil._convertDateToString(__getDateTime);
                                            }
                                            else
                                            {
                                                __strDisplay = __getDateTime.ToString(__format3, _myGlobal._cultureInfo());
                                            }
                                        }
                                        catch
                                        {
                                            __strDisplay = "";
                                            // Debugger.Break();
                                        }
                                    }
                                }
                                break;
                            case 10:
                                if (_cellComboBoxGet != null)
                                {
                                    __strDisplay = _cellComboBoxGet(this, row, __column, ((_columnType)_columnList[__column])._originalName, (int)((ArrayList)__newRow.newData)[__column]);
                                }
                                else
                                {
                                    __strDisplay = "";
                                }
                                break;
                            case 11:
                                {
                                    float __skipHorizontal = (__getColumn._widthPoint / 2f) - (13f / 2f);
                                    float __skipVertical = (this._cellHeight / 2f) - (13f / 2f);
                                    if (this._selectColumnFromMouse == __column && this._selectRowFromMouse == row)
                                    {
                                        e.DrawImage(((int)((ArrayList)__newRow.newData)[__column] == 0) ? Properties.Resources.IconSelectHover : Properties.Resources.IconSelectedHover, __calcWidth + __skipHorizontal, __calcPoint + __skipVertical, 13, 13);
                                    }
                                    else
                                        if (this._selectColumn == __column && this._selectRow == rowData)
                                    {
                                        e.DrawImage(((int)((ArrayList)__newRow.newData)[__column] == 0) ? Properties.Resources.IconSelectHover : Properties.Resources.IconSelectedHover, __calcWidth + __skipHorizontal, __calcPoint + __skipVertical, 13, 13);
                                    }
                                    else
                                    {
                                        e.DrawImage(((int)((ArrayList)__newRow.newData)[__column] == 0) ? Properties.Resources.IconSelect : Properties.Resources.IconSelected, __calcWidth + __skipHorizontal, __calcPoint + __skipVertical, 13, 13);
                                    }
                                }
                                break;
                            /*case 12: int skip2 = (__getColumn._widthPoint / 2) - (13 / 2);
                                Image getImage = (((ArrayList)__newRow.newData)[__column] == null) ? Properties.Resources.pin_grey1 : Properties.Resources.pin_blue1;
                                e.DrawImage(getImage, __calcWidth + skip2, __calcPoint + 2, 13, 13);
                                break;*/
                            //somruk
                            case 12:
                                {
                                    float __skip2 = (__getColumn._widthPoint / 2) - (13 / 2);
                                    if (_beforeDisplayRendering != null)
                                    {
                                        Object __myObject = ((Object)((ArrayList)__newRow.newData)[__column]);
                                        __strDisplay = ((Object)((ArrayList)__newRow.newData)[__column]).ToString();

                                    }
                                    else
                                    {
                                        Image __getImage = (((ArrayList)__newRow.newData)[__column] == null) ? Properties.Resources.pin_grey1 : Properties.Resources.pin_blue1;
                                        e.DrawImage(__getImage, __calcWidth + __skip2, __calcPoint, 13, 13);

                                    }
                                }
                                break;
                        }
                        SizeF __stringSize = e.MeasureString(__strDisplay, __newRow.newFont);
                        if (__stringSize.Width > __getColumn._widthPoint)
                        {
                            while (e.MeasureString(__strDisplay, __newRow.newFont).Width > __getColumn._widthPoint - 5 && __strDisplay.Length > 1)
                            {
                                __strDisplay = __strDisplay.Remove(__strDisplay.Length - 1, 1);
                                __strCut = true;
                            }
                            if (__strCut == true) __strDisplay = string.Concat(__strDisplay, "..");
                        }
                        if (__align == 0)
                        {
                            // left 
                            //e.DrawString(__strDisplay, __newRow.newFont, new SolidBrush(__newRow.newColor), __calcWidth, __calcPoint + ((_isEdit) ? 4 : 2));
                            e.DrawString(__strDisplay, __newRow.newFont, new SolidBrush(__newRow.newColor), __calcWidth, __calcPoint);
                        }
                        else
                        {
                            float skip = (__getColumn._widthPoint - ((SizeF)e.MeasureString(__strDisplay, __newRow.newFont)).Width) - 2;
                            //e.DrawString(__strDisplay, __newRow.newFont, new SolidBrush(__newRow.newColor), __calcWidth + skip, __calcPoint + ((_isEdit) ? 4 : 2));
                            e.DrawString(__strDisplay, __newRow.newFont, new SolidBrush(__newRow.newColor), __calcWidth + skip, __calcPoint);
                        }
                    }
                    __calcWidth = __calcWidth + __getColumn._widthPoint;
                } // for
            }
        }

        /// <summary>
        /// แสดงยอดรวม
        /// </summary>
        /// <param name="row"></param>
        /// <param name="e"></param>
        void _displayTotal(int row, Graphics e)
        {
            if (_beforeDisplayTotal != null)
            {
                this._beforeDisplayTotal(this);
            }
            float __calcPoint = (row + 1) * _cellHeight;
            float __calcWidth = _displayStartY;
            _columnType __getColumn = new _columnType();
            for (int __column = _columnFirst; __column < _columnList.Count; __column++)
            {
                bool __strCut = false;
                __getColumn = (_columnType)_columnList[__column];
                if (__getColumn._isHide == false && __getColumn._totalDisplay)
                {
                    string __strDisplay = "";
                    switch (__getColumn._type)
                    {
                        case 2:
                        case 3:
                        case 5:
                            string __format2 = Utils._numberUtils._getFormatNumber(__getColumn._format);
                            __strDisplay = string.Format(__format2, (decimal)__getColumn._total) + " ";
                            break;
                    }
                    SizeF __stringSize = e.MeasureString(__strDisplay, this._getFont);
                    if (__stringSize.Width > __getColumn._widthPoint)
                    {
                        while (e.MeasureString(__strDisplay, this._getFont).Width > __getColumn._widthPoint - 5 && __strDisplay.Length > 1)
                        {
                            __strDisplay = __strDisplay.Remove(__strDisplay.Length - 1, 1);
                            __strCut = true;
                        }
                        if (__strCut == true) __strDisplay += "..";
                    }
                    float __skip = (__getColumn._widthPoint - ((SizeF)e.MeasureString(__strDisplay, this._getFont)).Width) - 2;
                    e.DrawString(__strDisplay, this._getFont, new SolidBrush(Color.Black), __calcWidth + __skip, __calcPoint + ((_isEdit) ? 4 : 2));
                }
                __calcWidth += __getColumn._widthPoint;
            } // for
        }



        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (this._processKeyEnable)
            {
                int __rowPerPage = (int)(_calcHeight() / _cellHeight) - 1;
                int __count = 0;
                int __newRow = this._selectRow;
                Keys __keyCode = (Keys)(int)keyData & Keys.KeyCode;
                _lastKeyData = __keyCode;
                if (this._keyDown != null)
                {
                    if (this._keyDown(this, this._selectRow, this._selectColumn, __keyCode) == true)
                    {
                        return true;
                    }
                }
                if ((keyData & Keys.Shift) == Keys.Shift && (__keyCode == Keys.Tab))
                {
                    cellFlowPrevColumn();
                    return true;
                }
                else
                    if ((keyData & Keys.Shift) == Keys.Shift && (__keyCode == Keys.Enter))
                {
                    if (this._isEdit)
                    {
                        cellFlowPrevColumn();
                        return true;
                    }
                }
                else
                {
                    switch (keyData)
                    {
                        case Keys.Tab:
                        case Keys.Enter:
                            if (this._isEdit)
                            {
                                cellFlowNextColumn();
                                return true;
                            }
                            break;
                        case Keys.Up:
                            if (_selectRow > 0)
                            {
                                if (this._isEdit)
                                {
                                    _inputCell(this._selectRow - 1, this._selectColumn);
                                }
                                else
                                {
                                    if (this._selectRow > 0)
                                    {
                                        this._selectRow--;

                                        // toe movecursor
                                        if ((this._selectRow) < _rowFirst)
                                        {
                                            _rowFirst--;
                                        }
                                        this.Invalidate();
                                    }
                                }
                            }
                            return true;
                        case Keys.Down:
                            {
                                if (this._isEdit)
                                {
                                    _inputCell(this._selectRow + 1, this._selectColumn);
                                }
                                else
                                {
                                    if (this._selectRow < this._rowData.Count - 1)
                                    {
                                        this._selectRow++;

                                        // check cursor
                                        //int __rowPerPage = (int)(_calcHeight() / _cellHeight) - 1;
                                        if (((this._selectRow + 1) - __rowPerPage) > _rowFirst)
                                        {
                                            _rowFirst++;
                                        }
                                        this.Invalidate();
                                    }
                                }

                            }
                            return true;
                        case Keys.PageUp:
                            for (int __loop = 0; __loop < __rowPerPage; __loop++)
                            {
                                if (__newRow > 0)
                                {
                                    __newRow--;
                                    __count++;
                                }
                            } // for
                            _rowFirst -= __count;
                            if (_rowFirst < 0) _rowFirst = 0;
                            _inputCell(__newRow, this._selectColumn);
                            return true;
                        case Keys.PageDown:
                            for (int __loop = 0; __loop < __rowPerPage; __loop++)
                            {
                                if (__newRow < _rowData.Count - 1)
                                {
                                    __newRow++;
                                    __count++;
                                }
                            } // for
                            _rowFirst += __count;
                            if (_rowFirst > _vScrollBar1.Maximum)
                                _rowFirst = _vScrollBar1.Maximum;
                            _inputCell(__newRow, this._selectColumn);
                            return true;
                        case Keys.Insert:
                            if (this._isEdit)
                            {
                                if (_removeLastControl())
                                {
                                    _selectClear();
                                    if (AddRow)
                                    {
                                        _addRow(__newRow);
                                    }
                                    _inputCell(__newRow, this._selectColumn);
                                }
                                return true;
                            }
                            break;
                        case Keys.Escape:
                            {
                                if (this.showSelectedCellHighlight == true)
                                {
                                    this.selectedCell.Clear();
                                }
                            }
                            break;
                    }
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion
    }


    /// <summary>
    /// ก่้อนจะทำการตรวจสอบข้อมูลตัวเลขบน Column Number
    /// </summary>
    /// <param name="sender">NumberBox Object</param>
    /// <param name="valueStr">Value</param>
    public delegate void beforeCellNumberBoxCheckNumberValue(object sender, string valueStr, int row, int columNumber);

    /// <summary>
    /// DoubleClick บน Grid
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="e">ตามโครงสร้าง</param>
    public delegate void MouseDoubleClickHandler(object sender, GridCellEventArgs e);
    /// <summary>
    /// Click บน Grid เอาไว้ตรวจสอบตอนเลือกรายการ
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="e">ตามโครงสร้าง</param>
    public delegate void MouseClickHandler(object sender, GridCellEventArgs e);
    /// <summary>
    /// Click บน Grid ตรง Object (Clip)
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="e">ตามโครงสร้าง</param>
    public delegate void ClipMouseClickHandler(object sender, GridCellEventArgs e);
    /// <summary>
    /// ก่อน Add Row Data
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="e">ตามโครงสร้าง</param>
    public delegate object beforeAddRowHandler(object sender, object originalObject, int row, int column, string columnName);
    /// <summary>
    /// ก่อนทำการค้นหาข้อมูล
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="e">ตามโครงสร้าง</param>
    public delegate void SearchEventHandler(object sender, GridCellEventArgs e);
    /// <summary>
    /// หลังจาก Update Cell จะให้ทำอะไรต่อ
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    public delegate void AfterCellUpdateEventHandler(object sender, int row, int column);
    /// <summary>
    /// Before Update จะตรวจสอบข้อมูลอะไรก่อน ถ้า Return true คืออนุญาติให้ update ลง cell
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="e">ตามโครงสร้าง</param>
    public delegate Boolean BeforeCellUpdateEventHandler(object sender, GridCellEventArgs e);
    /// <summary>
    /// ในกรณี ComboBox Grid จะไปขอ Programmer ว่าต้องการให้มีรายการใดบ้าง
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="row">Row</param>
    /// <param name="column">Column</param>
    /// <returns></returns>
    public delegate object[] CellComboBoxItemEventHandler(object sender, int row, int column);
    /// <summary>
    /// ในกรณี ComboBox Grid จะไปขอ Programmer จะให้แสดงแต่ละบรรทัดอะไรบ้าง
    /// </summary>
    /// <param name="sender">ส่งจาก Grid ไหน</param>
    /// <param name="row">Row</param>
    /// <param name="column">Column</param>
    /// <returns></returns>
    public delegate string CellComboBoxItemGetDisplay(object sender, int row, int column, string columnName, int select);
    /// <summary>
    /// เพิ่มบรรทัด
    /// </summary>
    /// <param name="row">เลขบรรทัด เริ่มจาก 0</param>
    public delegate void AfterSelectRowEventHandler(object sender, int row);
    public delegate void AfterAddRowEventHandler(object sender, int row);
    public delegate bool KeyDownEventHandler(object sender, int row, int column, Keys keyCode);
    public delegate bool TotalCheckEventHandler(object sender, int row, int column);
    public delegate void BeforeDisplayTotalHandler(object sender);
    public delegate void AfterCalcTotalEventHandler(object sender);
    public delegate bool QueryForRowRemoveCheckEventHandler(_myGrid sender, int row);
    public delegate bool QueryForInsertCheckEventHandler(_myGrid sender, int row);
    public delegate bool QueryForUpdateCheckEventHandler(_myGrid sender, int row);
    public delegate string QueryForUpdateWhereEventHandler(_myGrid sender, int row);
    public delegate QueryForInsertPerRowType QueryForInsertPerRowEventHandler(_myGrid sender, int row);
    public delegate void LostFocusCellEventHandler(object sender, int row, int column, string columnName);
    public delegate void FocusCellEventHandler(object sender, int row, int column, string columnName);
    public delegate _myGridMoveColumnType MoveNextColumnEventHandler(_myGrid sender, int newRow, int newColumn);
    public delegate _myGridMoveColumnType MovePrevColumnEventHandler(_myGrid sender, int newRow, int newColumn);
    public delegate Boolean BeforeInputCellEventHandler(_myGrid sender, int row, int column);
    public delegate BeforeDisplayRowReturn BeforeDisplayRowEventHandler(_myGrid sender, int row, int columnNumber, string columnName, BeforeDisplayRowReturn senderRow, _columnType columnType, ArrayList rowData);
    //SOMRUK
    public delegate BeforeDisplayRowReturn BeforeDisplayRenderRowEventHandler(_myGrid sender, int row, int columnNumber, string columnName, BeforeDisplayRowReturn senderRow, _columnType columnType, ArrayList rowData, Graphics e);

    // TOE
    public delegate void AfterRemoveRowEventHandler(object sender);
    public delegate object BeforeLoadDataToColumnObject(object sender, int row, int column);

    public delegate void AfterImportDataWork(object sender);
}
