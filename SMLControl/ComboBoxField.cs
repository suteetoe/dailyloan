using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMLControl
{
    public class ComboBoxField : BaseField
    {
        public Boolean ShowLaabelCoutner { get; set; } = false;

        public Boolean IsQuery { get; set; } = true;

        public List<string> LabelOptionsList { get; set; } = new List<string>();
    }

    public class ComboBoxItem
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public ComboBoxItem(string value, string text)
        {
            this.Value = value;
            this.Text = text;
        }

        public override string ToString()
        {
            return this.Text;
        }
    }
}
