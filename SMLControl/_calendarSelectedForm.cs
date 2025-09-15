using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SMLControl
{
    public partial class _calendarSelectedForm : Form
    {
        public _calendarSelectedForm()
        {
            InitializeComponent();

            this.monthCalendar1.DateSelected += new DateRangeEventHandler(monthCalendar1_DateSelected);
        }

        void monthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (_selectedDate != null)
            {
                _selectedDate(e.Start);
            }
            this.Close();
        }

        public event SelectDateEventHandler _selectedDate;
        /// <summary>
        /// ส่งค่าวันที่กลับเมื่อเลือก
        /// </summary>
        /// <param name="e"></param>
        public delegate void SelectDateEventHandler(DateTime e);
    }
}
