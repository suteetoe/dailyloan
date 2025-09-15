using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public partial class _myVScrollBar : VScrollBar
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            e.Handled = true;
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            e.Handled = true;
        }
    }
}
