using SMLControl.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myDateBox : _myTextBox
    {

        /// <summary>
        /// ตัวที่ใช้เก็บข้อมูล
        /// </summary>
        private DateTime __dateTimeResult = new DateTime(1000, 1, 1);
        private DateTime __dateTimeOldResult = new DateTime(1000, 1, 1);
        private Boolean __warningResult = true;
        private Boolean __lostFocustResult = true;

        public event AfterSelectCalendarHandler _afterSelectCalendar;

        public DateTime _dateTime { get { return __dateTimeResult; } set { __dateTimeResult = value; } }
        public DateTime _dateTimeOld { get { return __dateTimeOldResult; } set { __dateTimeOldResult = value; } }
        public Boolean _warning { get { return __warningResult; } set { __warningResult = value; } }
        public Boolean _lostFocust { get { return __lostFocustResult; } set { __lostFocustResult = value; } }

        public _myDateBox() : base()
        {
            this._iconSearch.Image = Properties.Resources.calendar;
            this._icon = true;
            this._iconSearch.Click += new EventHandler(IconSearch_Click);
            this.textBox.Enter += new EventHandler(textBox_Enter);
            this.textBox.Leave += new EventHandler(textBox_Leave);
            this.BackColor = Color.Transparent;
        }

        void textBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _myTextBox __result = (_myTextBox)((TextBox)sender).Parent;
                if (__result._displayLabel && __result._label != null)
                {
                    __result._label.Font = new Font(__result._label.Font, FontStyle.Regular);
                }
                if (_lostFocust)
                {
                    _checkDate(true, _warning);
                }
            }
            catch
            {
            }
        }

        public string _textQuery()
        {
            return _textQuery("");
        }

        public string _textQuery(string extraWord)
        {
            string __result = "null";
            try
            {
                IFormatProvider __culture = new CultureInfo("en-US");
                __result = _dateTime.ToString("yyyy-MM-dd", __culture);
                __result = (_dateTime.Year < 1800) ? "null" : string.Concat("\'", __result, extraWord, "\'");
            }
            catch
            {
                // Debugger.Break();
            }
            return (__result);
        }

        /// <summary>
        /// ก่อนจะบันทึกให้เปลี่ยนเป็นตัวเลขให้หมด
        /// </summary>
        public void _beforeInput()
        {
            IFormatProvider __culture = _myGlobal._cultureInfo();
            if (_dateTime.Year > 1000)
            {
                this.textBox.Text = _dateTime.ToString("d/M/yyyy", _myGlobal.DisplayCulture);
            }
            else
            {
                this.textBox.Text = "";
            }
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            _myTextBox __result = (_myTextBox)((TextBox)sender).Parent;
            if (__result._displayLabel && __result._label != null)
            {
                __result._label.Font = new Font(__result._label.Font, FontStyle.Underline);
            }
            _beforeInput();
        }

        public void _refresh()
        {
            this.textBox.Text = _dateUtil._convertDateToString(_dateTime, _myGlobal.DisplayCulture);
            this.textBox.Invalidate();
        }

        /// <summary>
        /// ตรวจสอบว่าป้อนวันที่ถูกหรือไม่
        /// </summary>
        public bool _checkDate(Boolean changeText, Boolean warning)
        {
            if (this.textBox.Text.Length > 0)
            {
                try
                {
                    int __day = _myGlobal._workingDate.Day;
                    int __month = _myGlobal._workingDate.Month;
                    int __year = _myGlobal._workingDate.Year;
                    /*Debug.Print(this.textBox.Text);
                    Debug.Print(Environment.StackTrace.ToString());*/
                    string __dateBuffer = this.textBox.Text;
                    __dateBuffer = __dateBuffer.Replace(' ', '/');
                    __dateBuffer = __dateBuffer.Replace('-', '/');
                    __dateBuffer = __dateBuffer.Replace('.', '/');
                    __dateBuffer = __dateBuffer.Replace('*', '/');
                    if (__dateBuffer.Length > 0)
                    {
                        if (__dateBuffer[__dateBuffer.Length - 1] == '/')
                        {
                            __dateBuffer = __dateBuffer.Remove(__dateBuffer.Length - 1, 1);
                        }
                    }
                    string[] __dateSplit = __dateBuffer.Split('/');
                    if (__dateBuffer.Length == 4 && Utils._numberUtils._intPhase(__dateBuffer) != 0)
                    {
                        // ddmm
                        __day = Convert.ToInt32(__dateBuffer.Substring(0, 2));
                        __month = Convert.ToInt32(__dateBuffer.Substring(2, 2));
                    }
                    else
                        if (__dateBuffer.Length == 6 && Utils._numberUtils._intPhase(__dateBuffer) != 0)
                    {
                        // ddmmyy
                        __day = Convert.ToInt32(__dateBuffer.Substring(0, 2));
                        __month = Convert.ToInt32(__dateBuffer.Substring(2, 2));
                        __year = Convert.ToInt32(__dateBuffer.Substring(4, 2));
                    }
                    else
                            if (__dateSplit.Length == 1)
                    {
                        // ป้อนแต่วันที่
                        __day = Convert.ToInt32(__dateSplit[0]);
                    }
                    else
                                if (__dateSplit.Length == 2)
                    {
                        // ป้อน วันที่+เดือน
                        __day = Convert.ToInt32(__dateSplit[0]);
                        __month = Convert.ToInt32(__dateSplit[1]);
                    }
                    else if (__dateSplit.Length >= 3)
                    {
                        // ป้อน วันที่+เดือน+ปี
                        __day = Convert.ToInt32(__dateSplit[0]);
                        string __monthNumber = __dateSplit[1];
                        /*string[] __monthNameArray = { "มกราคม", "กุมภาพันธ์", "มีนาคม", "เมษายน", "พฤษภาคม", "มิถุนายน", "กรกฎาคม", "สิงหาคม", "กันยายน", "ตุลาคม", "พฤศจิกายน", "ธันวาคม" };
                        for (int __loop = 0; __loop < 12; __loop++)
                        {
                            if (__monthNumber.Equals(__monthNameArray[__loop].ToString()))
                            {
                                __monthNumber = ((int)__loop + 1).ToString();
                                break; ;
                            }
                        }*/
                        __month = Convert.ToInt32(__monthNumber);
                        __year = Convert.ToInt32(__dateSplit[2]);
                    }
                    // ดึงวันเดือนปีปรกติ ถ้าในกรณีป้อนไม่ครบ ก็ประกอบร่างใหม่ เช่น ป้อนเฉพาะวันที่
                    if (_myGlobal._year_type == 1)
                    {
                        if (__year < 2500)
                        {
                            if (__year < 100) // toe fix 24xx for birth day
                            {
                                __year = __year + 2500;
                            }
                        }
                    }
                    else
                    {
                        if (__year < 2000)
                        {
                            if (__year < 100)
                            {
                                __year = __year + 2000;
                            }
                        }
                    }
                    __year = __year - _myGlobal.DateCultureDiff();
                    DateTime __myDate = new DateTime(__year, __month, __day);
                    if (changeText)
                    {
                        if (__myDate.Year <= 1000)
                        {
                            this.textBox.Text = "";
                        }
                    }
                    _dateTime = new DateTime(__myDate.Year, __myDate.Month, __myDate.Day);
                    if (changeText)
                    {
                        this._refresh();
                    }
                }
                catch
                {
                    // Debugger.Break();
                    if (warning)
                    {
                        // ป้อนวันที่ผิดพลาด
                        MessageBox.Show(_myGlobal._resource("format_date_error"), _myGlobal._resource("warning"), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    if (changeText)
                    {
                        this.textBox.Text = "";
                    }
                    _dateTime = new DateTime(1000, 1, 1);
                    return (false);
                }
            }
            else
            {
                _dateTime = new DateTime(1000, 1, 1);
            }
            return (true);
        }

        void IconSearch_Click(object sender, EventArgs e)
        {
            if (this.ReadOnly)
                return;

            this.Focus();
            this.textBox.Focus();
            this.textBox.SelectAll();
            _calendarSelectedForm __myDate = new _calendarSelectedForm();
            //			myDate.Location = new Point((this.IconSearch.Location.X + this.IconSearch.Width)-myDate.Width, this.IconSearch.Location.Y + this.IconSearch.Height);
            int newLocationX = this._iconSearch.Width - __myDate.Width;
            int newLocationY = this._iconSearch.Height;
            Point __x = this._iconSearch.PointToScreen(new Point(newLocationX, newLocationY));
            __myDate.DesktopLocation = __x;
            __myDate.StartPosition = FormStartPosition.Manual;
            __myDate._selectedDate += new _calendarSelectedForm.SelectDateEventHandler(myDate__selectedDate);
            __myDate.ShowDialog(this.Parent);
        }

        void myDate__selectedDate(DateTime e)
        {
            string dateDisplay = _dateUtil._convertDateToString(e, _myGlobal.DisplayCulture);
            this.textBox.Text = dateDisplay; // string.Concat(e.Day, "/", e.Month, "/", (e.Year + _myGlobal._year_add));
            _checkDate(true, _warning);
            _beforeInput();
            if (_afterSelectCalendar != null)
            {
                _afterSelectCalendar(e);
            }
        }
    }
}
