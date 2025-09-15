using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myNumberBox : _myTextBox
    {

        /// <summary>ค่าที่น้อยที่สุด</summary>
        private decimal __minValueResult;
        /// <summary>ค่าที่มากที่สุด</summary>
        private decimal __maxValueResult;
        /// <summary>ทศนิยม</summary>
        private decimal __pointResult;
        /// <summary>เก็บค่าไว้</summary>
        private decimal __doubleResult = 0;
        /// <summary>รูปแบบ</summary>
        private string __formatResult = "";
        /// <summary>สีปรกติ</summary>
        private Color __default_colorResult = Color.Black;
        public decimal __oldResult = 0;
        public event AfterSelectCalculatorHandler _afterSelectCalculator;

        private Boolean __hiddenNumberValueResult = false;

        public event _onCustomSearchClick _customSearchClick;
        public delegate void _onCustomSearchClick(object sender, EventArgs e);
        public _myNumberBox(int iconType)
        {
            this._init();
            this._iconType = iconType;
        }

        public _myNumberBox()
        {
            this._init();
        }

        void _init()
        {
            this._iconSearch.Image = Properties.Resources.IconCalc;
            this._icon = true;
            this._iconSearch.Click += new EventHandler(_iconSearch_Click);
            this.textBox.TextAlign = HorizontalAlignment.Right;
            this.textBox.Enter += new EventHandler(textBox_Enter);
            this.textBox.Leave += new EventHandler(textBox_Leave);
            this.textBox.KeyUp += new KeyEventHandler(textBox_KeyUp);
            this.BackColor = Color.Transparent;
        }

        public Boolean _hiddenNumberValue
        {
            get
            {
                return __hiddenNumberValueResult;
            }

            set
            {
                __hiddenNumberValueResult = value;

                if (__hiddenNumberValueResult == true)
                {
                    this.textBox.PasswordChar = '*';
                }
                else
                {
                    this.textBox.PasswordChar = '\0';
                }
            }
        }

        void _iconSearch_Click(object sender, EventArgs e)
        {
            if (_customSearchClick != null)
            {
                _customSearchClick(sender, e);
            }
            else
            {
                try
                {
                    this.Focus();
                    this.textBox.Focus();
                    this.textBox.SelectAll();
                    //_CalculatorPanel __calcultor = new _CalculatorPanel();
                    //__calcultor.Text = "Calculator";
                    //__calcultor._Format += new EventHandler<_CalculatorFormatEventArgs>(__calcultor__Format);
                    //__calcultor._ResultControl = this;
                    //int newLocationX = this._iconSearch.Width - __calcultor.Width;
                    //int newLocationY = this._iconSearch.Height;
                    //Point x = this._iconSearch.PointToScreen(new Point(newLocationX, newLocationY));
                    //__calcultor.DesktopLocation = x;
                    //__calcultor.StartPosition = FormStartPosition.Manual;
                    ////__calcultor.ShowDialog(this.Parent); // toe
                    //__calcultor.ShowDialog();
                }
                catch (Exception ex)
                {
                    string __ex = ex.ToString();
                }
            }
        }

        void __calcultor__Format(object sender, _CalculatorFormatEventArgs e)
        {
            this.textBox.Text = e._FormattedResult;
            _checkNumber();
            _refresh();
            if (_afterSelectCalculator != null)
            {
                _afterSelectCalculator((decimal)e._Result);
            }
        }
        void textBox_Enter(object sender, EventArgs e)
        {
            string __format = this.getFormat();
            this.textBox.Text = (__doubleResult == 0) ? "" : string.Format(__format, __doubleResult);
        }

        public decimal _minValue { get { return __minValueResult; } set { __minValueResult = value; } }
        public decimal _maxValue { get { return __maxValueResult; } set { __maxValueResult = value; } }
        public decimal _point { get { return __pointResult; } set { __pointResult = value; } }
        public decimal _double { get { return __doubleResult; } set { __doubleResult = value; } }
        public string _format { get { return __formatResult; } set { __formatResult = value; } }
        public Color _default_color { get { return __default_colorResult; } set { __default_colorResult = value; } }

        public decimal _setDataNumber
        {
            set
            {
                this._double = value;
                this.__oldResult = value;
                this._textFirst = value.ToString();
                this._refresh();

            }
        }
        void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            _checkNumber();
            try
            {
                this.textBox.ForeColor = (this.textBox.Text.Length == 0) ? _default_color : (Convert.ToDecimal(this.textBox.Text) < 0) ? Color.Red : _default_color;
            }
            catch
            {
                this.textBox.ForeColor = _default_color;
            }
        }

        public string getFormat()
        {
            string __format = this._format;
            decimal __point = this._point;
            if (__format.Length > 0 && __format[0] == 'm')
            {
                __point = Utils._numberUtils._decimalPhase(__format.Remove(0, 1));
                __format = "";
            }
            if (__format.Length == 0)
            {
                __format = "{0:n" + __point.ToString() + "}";
            }
            return __format;
        }

        public void _refresh()
        {
            string __format = getFormat();
            this.textBox.Text = (_double == 0) ? "" : string.Format(__format, _double);
            this.textBox.ForeColor = (_double < 0) ? Color.Red : _default_color;
            if (this.textBox.Text.Length == 0)
            {
                _double = 0;
            }
            else
            {
                try
                {
                    _double = Convert.ToDecimal(this.textBox.Text);
                }
                catch
                {
                    _double = 0;
                    // Debugger.Break();
                }
            }
            // this.Invalidate();
        }

        void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _checkNumber();
                _refresh();
            }
            catch
            {
            }
        }


        public bool _checkNumber()
        {
            if (_beforeCheckNumberValue != null)
            {
                this._beforeCheckNumberValue(this, this.textBox.Text);
            }

            try
            {
                string __text = this.textBox.Text;
                /*if (__text.IndexOf('=') == 0)
                {
                    __text = __text.Substring(1);
                }*/

                _mathParser __formula = new _mathParser();
                _double = (decimal)__formula.Calculate(__text);
                //Decimal numberCalc = (decimal)__formula.Calculate(__text);

                //// formt number
                //string __format = this.getFormat();
                //string __result = string.Format(__format, numberCalc);

                //_double = MyLib._myGlobal._decimalPhase(__result);
            }
            catch
            {
                _double = 0;
            }
            this.Invalidate();
            return (true);
        }

        public delegate void beforeNumberBoxCheckValue(object sender, string valueStr);
        public event beforeNumberBoxCheckValue _beforeCheckNumberValue;
    }
}
