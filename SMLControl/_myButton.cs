using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public class _myButton : Button
    {
        public string ButtonText = "";
        public string _name = "";
        public string _resource_name = "";
        public int _row = 0;
        public int _column = 0;
        public int _maxColumn = 0;
        //
        private System.Windows.Forms.TextImageRelation _textImageRelationResult = TextImageRelation.ImageBeforeText;
        private Boolean _useVisualStyleBackColorResult = false;
        public _languageEnum _lastLanguage = _languageEnum.Null;
        private string _resultFixed = "";

        //public new Boolean AutoSize = true;

        public _myButton()
        {
            // this.AutoSize = true;
            this.Padding = new Padding(0, 0, 0, 0);
            this.Margin = new Padding(1, 0, 1, 0);
            this.myTextImageRelation = TextImageRelation.ImageBeforeText;
            this.Invalidated += new InvalidateEventHandler(_myButton_Invalidated);
        }

        void _myButton_Invalidated(object sender, InvalidateEventArgs e)
        {
            if (_myGlobal._language != this._lastLanguage)
            {
                _lastLanguage = _myGlobal._language;
                if (this._resultFixed.Length > 0)
                {
                    this.ButtonText = _myGlobal._resource(this._resultFixed);
                    this.Invalidate();
                }
            }
        }

        public Boolean myUseVisualStyleBackColor
        {
            set
            {
                this._useVisualStyleBackColorResult = value;
            }
            get
            {
                return this._useVisualStyleBackColorResult;
            }
        }

        public System.Windows.Forms.TextImageRelation myTextImageRelation
        {
            set
            {
                this._textImageRelationResult = value;
            }
            get
            {
                return this._textImageRelationResult;
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
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            if (_myGlobal._language != this._lastLanguage)
            {
                _lastLanguage = _myGlobal._language;
                if (_resultFixed != null && this._resultFixed.Length > 0)
                {
                    this.Text = this.ButtonText = _myGlobal._resource(this._resultFixed);
                    this.Invalidate();
                }
            }
            base.OnPaint(pevent);
        }
    }
}
