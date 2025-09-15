using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myLabel : System.Windows.Forms.Label
    {
        public int _row;
        public int _column = -1;
        public string _field_name;
        public string _help_name = "";
        //public string _resource_name = "";
        public string _buttomStr;
        public _languageEnum _lastLanguage = _languageEnum.Null;
        public Boolean _getResource = false;
        private string _resultFixed = "";

        public _myLabel()
        {
            this.Padding = new Padding(0, 0, 0, 0);
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

        protected override void OnPaint(PaintEventArgs e)
        {
            if (_myGlobal._language != this._lastLanguage)
            {
                this._lastLanguage = _myGlobal._language;
                if (this._resultFixed.Length > 0 && this._column == -1)
                {
                    this.Text = _myGlobal._resource(this._resultFixed);
                    this.Invalidate();
                }
            }
            base.OnPaint(e);
        }


    }

    public class _addLabelReturn
    {
        public string _label_name;
        public int _length;
        public _myLabel _label;
    }

}
