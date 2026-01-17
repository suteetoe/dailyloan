using DailyLoan.Control;
using DailyLoan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.Holiday
{
    public class HolidayControl : DailyLoan.Control.ManageDataList
    {
        private HolidayDetailScreen holidayDetailScreen;
        private HolidayRepository holidayRepository = new HolidayRepository();

        public HolidayControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridDateColumn() { WidthPercent = 20, ColumnCode = "date_holiday", ColumnName = "วันที่" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 80, ColumnCode = "remark", ColumnName = "รายละเอียด" });
            this._dataListGrid.Invalidate();
        }

        private void InitializeComponent()
        {
            this.holidayDetailScreen = new HolidayDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.Title = "กำหนดวันหยุด";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.holidayDetailScreen);
            // 
            // _dataLoadingTimer
            // 
            this._dataLoadingTimer.Enabled = true;
            // 
            // holidayDetailScreen
            // 
            this.holidayDetailScreen._isChange = false;
            this.holidayDetailScreen.BackColor = System.Drawing.Color.Transparent;
            this.holidayDetailScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.holidayDetailScreen.Location = new System.Drawing.Point(0, 0);
            this.holidayDetailScreen.Name = "holidayDetailScreen";
            this.holidayDetailScreen.Size = new System.Drawing.Size(359, 529);
            this.holidayDetailScreen.TabIndex = 0;
            // 
            // HolidayControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "HolidayControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        protected override string LoadDataListQuery()
        {
            string query = "SELECT date_holiday, remark FROM  mst_holiday ";
            return query;
        }

        protected override void ClearScreen()
        {
            this.holidayDetailScreen._clear();
            this.holidayDetailScreen._enabedControl("date_holiday", true);

        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            this.ClearScreen();
            string holiday_date_str = selectedRow["date_holiday"];
            DateTime doliday_date = SMLControl.Utils._dateUtil.PhaseDateFromQuery(holiday_date_str);
            var holiday = holidayRepository.GetHolidayByDate(doliday_date);
            if (holiday != null)
            {
                this.holidayDetailScreen.LoadHolidayData(holiday);
                return true;
            }
            return false;
        }

        protected override bool OnSaveData()
        {
            var holiday = this.holidayDetailScreen.GetHoliday();

            if (this.formMode == FormMode.EDIT)
            {
                holidayRepository.UpdateHoliday(holiday);
            }
            else
            {
                holidayRepository.CreateHoliday(holiday);
            }
            return true;
        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                string holiday_date_str = rowSelected["date_holiday"];
                DateTime doliday_date = SMLControl.Utils._dateUtil.PhaseDateFromQuery(holiday_date_str);

                holidayRepository.DeleteHoliday(doliday_date);

                MessageBox.Show("ลบข้อมูลเรียบร้อยแล้ว", "ลบข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ไม่สามารถลบข้อมูลได้\n" + ex.Message, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            return false;
        }
    }
}
