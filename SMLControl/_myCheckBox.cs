using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myCheckBox : System.Windows.Forms.CheckBox
    {
        public int _row;
        public int _column;
        public string _name = "";
        public string _resource_name;
        public _myLabel _label;
        public _languageEnum _lastLanguage = _languageEnum.Null;
        private string _resultFixed = "";
        /// <summary>เป็นของ Database (เอาไปใช้ตอน Query)</summary>
        public Boolean _isQuery { get { return _isQueryResult; } set { _isQueryResult = value; } }
        private Boolean _isQueryResult = true;
        public Boolean _defaultValue = false;

        public _myCheckBox()
        {
            this.AutoSize = true;
            this.KeyDown += new KeyEventHandler(_myCheckBox_KeyDown);
            this.Leave += new EventHandler(_myCheckBox_Leave);
            this.Enter += new EventHandler(_myCheckBox_Enter);
            this.HandleCreated += new EventHandler(_myCheckBox_HandleCreated);
        }

        void _myCheckBox_HandleCreated(object sender, EventArgs e)
        {
            this.Parent.Paint += new PaintEventHandler(Parent_Paint);
        }

        void _myCheckBox_Enter(object sender, EventArgs e)
        {
            this.Parent.Invalidate();
        }

        void _myCheckBox_Leave(object sender, EventArgs e)
        {
            this.Parent.Invalidate();
        }

        void Parent_Paint(object sender, PaintEventArgs e)
        {
            /*if (this.Focused)
            {
                Graphics __g = e.Graphics;
                Point __getClient = this.Location;
                Pen __myPen = new Pen(Color.Orange, 1);
                if (this.Text.Length == 0)
                {
                    Point[] __point = {
                    new Point(__getClient.X-1,__getClient.Y-1),
                    new Point(__getClient.X-1,__getClient.Y+(this.Height-1)),
                    new Point(__getClient.X+(this.Width-2),__getClient.Y+(this.Height-1)),
                    new Point(__getClient.X+(this.Width-2),__getClient.Y-1),
                    new Point(__getClient.X-1,__getClient.Y-1)
                };

                    __g.DrawLines(__myPen, __point);
                }
                else
                {
                    Point[] __point = {
                    new Point(__getClient.X-1,__getClient.Y+1),
                    new Point(__getClient.X-1,__getClient.Y+(15)),
                    new Point(__getClient.X+(13),__getClient.Y+(15)),
                    new Point(__getClient.X+(13),__getClient.Y+1),
                    new Point(__getClient.X-1,__getClient.Y+1)
                };

                    __g.DrawLines(__myPen, __point);
                }
                __myPen.Dispose();
            }*/
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (_myGlobal._language != this._lastLanguage)
            {
                _lastLanguage = _myGlobal._language;
                if (_resultFixed != null && this._resultFixed.Length > 0)
                {
                    this.Text = _myGlobal._resource(this._resultFixed);
                    this.Invalidate();
                }
            }
            base.OnPaint(pevent);
        }

        [Category("_SML")]
        [Description("Name ใช้ในการหา Resource")]
        [DisplayName("Name ใช้ในการหา Resource")]
        public string ResourceName
        {
            get
            {
                return _resultFixed;
            }
            set
            {
                _resultFixed = value;
                this.Invalidate();
            }
        }

        public void _getResource(string tableName)
        {
            /*if (ResourceName.Length != 0)
            {
                if (MyLib._myGlobal._isDesignMode )
                {
                    this.Text = tableName + "." + ResourceName;
                }
                else
                {
                    this.Text = MyLib._myResource._findResource(string.Concat(tableName, ResourceName), this.Text)._str;
                }
            }
            this.Invalidate();*/
        }

        void _myCheckBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Enter)
            {
                _cellMoveRightWork();
            }
            if (e.KeyCode == Keys.Left)
            {
                _cellMoveLeftWork();
            }
        }

        public event CellCheckBoxMoveRightHandler _cellMoveRight;
        public event CellCheckBoxMoveLeftHandler _cellMoveLeft;

        protected virtual void _cellMoveRightWork()
        {
            if (_cellMoveRight != null) _cellMoveRight(this);
        }

        protected virtual void _cellMoveLeftWork()
        {
            if (_cellMoveLeft != null) _cellMoveLeft(this);
        }
    }

    public delegate void CellCheckBoxMoveRightHandler(object sender);
    public delegate void CellCheckBoxMoveLeftHandler(object sender);
}
