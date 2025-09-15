using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myGroupBox : System.Windows.Forms.GroupBox
    {
        public string __tableName = "";
        public string __name = "";
        public string __resource_name = "";
        public bool __query = false;
        /// <summary>
        /// จำนวน Column ใน GroupBox
        /// </summary>
        public int __maxColumn = 0;
        /// <summary>
        /// จำนวน Column ใน Screen
        /// </summary>
        public int __maxColumnPanel = 0;
        public int __row;
        public int __column;
        public int __rowCount;
        public _languageEnum _lastLanguage = _languageEnum.Null;
        private string _resultFixed = "";
        //
        public _myGroupBox()
        {
            this.DoubleBuffered = true;
            /*this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UseTextForAccessibility, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.CacheText, true);*/
            //
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_myGlobal._language != this._lastLanguage)
            {
                _lastLanguage = _myGlobal._language;
                if (this._resultFixed.Length > 0)
                {
                    this.Text = _myGlobal._resource(this._resultFixed);
                    this.Invalidate();
                }
            }
            base.OnPaint(e);
        }

        [Category("_SML")]
        [Description("ใช้ Query (กรณี Radio Butoon)")]
        [DefaultValue(false)]
        public bool Query
        {
            get
            {
                return __query;
            }
            set
            {
                __query = value;
            }
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
            }
        }
    }
}
