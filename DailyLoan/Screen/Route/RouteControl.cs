using DailyLoan.Control;
using DailyLoan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DailyLoan.Screen.Route
{
    public class RouteControl : DailyLoan.Control.ManageDataList
    {
        private RouteDetailScreen routeDetailScreen;
        private RouteRepository routeRepository = new RouteRepository();

        public RouteControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 30, ColumnCode = "code", ColumnName = "รหัสสาย" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 70, ColumnCode = "name_1", ColumnName = "ชื่อสาย" });
            this._dataListGrid.Invalidate();
        }

        private void InitializeComponent()
        {
            this.routeDetailScreen = new DailyLoan.Screen.Route.RouteDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.titlePanel.Title = "สาย";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.routeDetailScreen);
            // 
            // routeDetailScreen
            // 
            this.routeDetailScreen._isChange = false;
            this.routeDetailScreen.BackColor = System.Drawing.Color.Transparent;
            this.routeDetailScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeDetailScreen.Location = new System.Drawing.Point(0, 0);
            this.routeDetailScreen.Name = "routeDetailScreen";
            this.routeDetailScreen.Size = new System.Drawing.Size(367, 583);
            this.routeDetailScreen.TabIndex = 0;
            // 
            // RouteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "RouteControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        protected override void ClearScreen()
        {
            this.routeDetailScreen._clear();
            this.routeDetailScreen._enabedControl("code", true);
        }

        protected override string LoadDataListQuery()
        {
            string query = "SELECT code, name_1 from mst_route ";
            return query;
        }

        protected override bool LoadDataToScreen(RowDataSelect selectedRow, bool isEdit = false)
        {
            string code = selectedRow["code"];
            var r = routeRepository.GetRouteByCode(code);
            if (r != null)
            {
                this.routeDetailScreen.LoadDataFromModel(r);
                this.routeDetailScreen._enabedControl("code", false);
                return true;
            }
            return false;
        }

        protected override bool OnSaveData()
        {
            string requireText = this.routeDetailScreen._checkEmtryField();
            if (requireText != "")
            {
                MessageBox.Show(requireText, "เตือน", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            DailyLoan.Data.Models.Route r = new DailyLoan.Data.Models.Route();
            r.code = this.routeDetailScreen._getDataStr("code");
            r.name_1 = this.routeDetailScreen._getDataStr("name_1");

            if (this.formMode == FormMode.EDIT)
            {
                routeRepository.UpdateRoute(r);
            }
            else
            {
                routeRepository.CreateRoute(r);
            }
            return true;
        }

        protected override bool OnDeleteData(RowDataSelect rowSelected)
        {
            try
            {
                routeRepository.DeleteRoute(rowSelected["code"]);

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
