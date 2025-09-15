using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myComboBox : System.Windows.Forms.ComboBox
    {
        public Boolean _isQuery { get { return _isQueryResult; } set { _isQueryResult = value; } }
        private Boolean _isQueryResult = true;

        public int _row;
        public int _column;
        public string _name;
        public string[] _listName;
        public Boolean _addCounter;
        public string _tableName;
        public _myLabel _label;
        public int _oldValue = 0;
        /// <summary>
        /// ให้จำข้อมูลล่าสุด
        /// </summary>
        public Boolean _useRecentValue = false;

        /// <summary>จำนวน Column เอาไว้ให้ routine screen ใช้</summary>
        public int _maxColumn { get { return _maxColumnResult; } set { _maxColumnResult = value; } }
        private int _maxColumnResult = 1;

        public _myComboBox()
        {
            this.Font = _myGlobal._myFont;
            this.BackColor = Color.White;
            if (_myGlobal._isDesignMode == false)
            {
                this.DropDown += new EventHandler(_myComboBox_DropDown);
                this.Enter += new EventHandler(_myComboBox_Enter);
                this.Leave += new EventHandler(_myComboBox_Leave);
                this.HandleCreated += new EventHandler(_myComboBox_HandleCreated);
            }
        }

        void _myComboBox_Leave(object sender, EventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Invalidate();
        }

        void _myComboBox_Enter(object sender, EventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Invalidate();
        }

        void _myComboBox_HandleCreated(object sender, EventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Paint += new PaintEventHandler(Parent_Paint);
        }

        void Parent_Paint(object sender, PaintEventArgs e)
        {
            /*if (this.Focused)
            {
                Graphics __g = e.Graphics;
                Point __getClient = this.Location;
                Pen __myPen = new Pen(Color.Orange, 1);
                Point[] __point = {
                    new Point(__getClient.X-1,__getClient.Y-1),
                    new Point(__getClient.X-1,__getClient.Y+(this.Height)),
                    new Point(__getClient.X+(this.Width),__getClient.Y+(this.Height)),
                    new Point(__getClient.X+(this.Width),__getClient.Y-1),
                    new Point(__getClient.X-1,__getClient.Y-1)
                };
                __g.DrawLines(__myPen, __point);
                __myPen.Dispose();
            }*/
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            const int WM_KEYDOWN = 0x100;
            const int WM_SYSKEYDOWN = 0x104;

            if ((msg.Msg == WM_KEYDOWN) || (msg.Msg == WM_SYSKEYDOWN))
            {
                if (keyData == Keys.Home || keyData == Keys.End || keyData == Keys.PageDown || keyData == Keys.PageUp)
                {
                    return true;
                }
                else
                    if (keyData == Keys.F2 || keyData == Keys.Space)
                {
                    this.DroppedDown = (this.DroppedDown == true) ? false : true;
                    return true;
                }
                else
                        if (keyData == Keys.Up && this.DroppedDown == false)
                {
                    _cellMoveUpWork();
                    return true;
                }
                else
                            if (keyData == Keys.Down && this.DroppedDown == false)
                {
                    _cellMoveDownWork();
                    return true;
                }
                else
                                if (keyData == Keys.Left)
                {
                    _cellMoveLeftWork();
                    return true;
                }
                else
                                    if (keyData == Keys.Enter || keyData == Keys.Right)
                {
                    _cellMoveRightWork();
                    return true;
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        void _myComboBox_DropDown(object sender, EventArgs e)
        {
            this.DropDownWidth = this.Width;
            for (int __loop = 0; __loop < this.Items.Count; __loop++)
            {
                string __getName = this.Items[__loop].ToString();
                Graphics myGraphics = this.CreateGraphics();
                myGraphics.SmoothingMode = SmoothingMode.HighQuality;
                SizeF stringSize = myGraphics.MeasureString(__getName, _myGlobal._myFont);
                if (stringSize.Width > this.DropDownWidth - 5)
                {
                    this.DropDownWidth = (int)stringSize.Width + 5;
                }
            }
        }

        /// <summary>
        /// จะบวกหนึ่งให้เอง
        /// </summary>
        /// <returns></returns>
        public int _selectedIndex
        {
            get
            {
                return this.SelectedIndex + 1;
            }
        }

        public event CellComboBoxMoveRightHandler _cellMoveRight;
        public event CellComboBoxMoveLeftHandler _cellMoveLeft;
        public event CellComboBoxMoveDownHandler _cellMoveDown;
        public event CellComboBoxMoveUpHandler _cellMoveUp;

        protected virtual void _cellMoveDownWork()
        {
            if (_cellMoveDown != null) _cellMoveDown(this);
        }

        protected virtual void _cellMoveUpWork()
        {
            if (_cellMoveUp != null) _cellMoveUp(this);
        }

        protected virtual void _cellMoveRightWork()
        {
            if (_cellMoveRight != null) _cellMoveRight(this);
        }

        protected virtual void _cellMoveLeftWork()
        {
            if (_cellMoveLeft != null) _cellMoveLeft(this);
        }
    }

    public delegate void CellComboBoxMoveRightHandler(object sender);
    public delegate void CellComboBoxMoveLeftHandler(object sender);
    public delegate void CellComboBoxMoveUpHandler(object sender);
    public delegate void CellComboBoxMoveDownHandler(object sender);
}
