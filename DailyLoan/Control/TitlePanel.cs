using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Control
{
    public partial class TitlePanel : UserControl
    {
        private string titleText = "Title";

        public string Title
        {
            get { return titleText; }
            set
            {
                titleText = value;
                this._titleLabel.Text = titleText;
            }
        }


        public TitlePanel()
        {
            InitializeComponent();
        }
    }
}
