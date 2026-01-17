using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Setup.Holiday
{
    public partial class HolidayControl_old : UserControl
    {
        public HolidayControl_old()
        {
            InitializeComponent();

            this._searchResultGrid.AddGridColumn(new SMLControl.GridDateColumn() { WidthPercent = 20, ColumnCode = "date_holiday", ColumnName = "วันที่" });
            this._searchResultGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 80, ColumnCode = "remark", ColumnName = "รายละเอียด" });
            this._searchResultGrid.Invalidate();
        }
    }
}
