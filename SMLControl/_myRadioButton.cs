using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myRadioButton : System.Windows.Forms.RadioButton
    {
        public string __name = "";
        public string __resource_name = "";
        public int __row;
        public int __column;
        public object __value;
        private string _resultFixed = "";
        public _languageEnum _lastLanguage = _languageEnum.Null;
        //
        public _myRadioButton()
        {
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (_myGlobal._language != this._lastLanguage)
            {
                _lastLanguage = _myGlobal._language;
                if (this._resultFixed.Length > 0)
                {
                    this.Text = _myGlobal._resource(this._resultFixed);
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
    }

}
