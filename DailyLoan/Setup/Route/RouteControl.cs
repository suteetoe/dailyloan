using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Setup.Route
{
    public class RouteControl : DailyLoan.Control.ManageDataList
    {
        private RouteDetailScreen routeDetailScreen2;

        public RouteControl()
        {
            InitializeComponent();

            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 30, ColumnCode = "code", ColumnName = "รหัสสาย" });
            this._dataListGrid.AddGridColumn(new SMLControl.GridTextColumn() { WidthPercent = 70, ColumnCode = "name_1", ColumnName = "ชื่อสาย" });
            this._dataListGrid.Invalidate();
        }

        private void InitializeComponent()
        {
            this.routeDetailScreen2 = new DailyLoan.Setup.Route.RouteDetailScreen();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            this.titlePanel.Title = "สาย";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.routeDetailScreen2);
            // 
            // routeDetailScreen2
            // 
            this.routeDetailScreen2._isChange = false;
            this.routeDetailScreen2.BackColor = System.Drawing.Color.Transparent;
            this.routeDetailScreen2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.routeDetailScreen2.Location = new System.Drawing.Point(0, 0);
            this.routeDetailScreen2.Name = "routeDetailScreen2";
            this.routeDetailScreen2.Size = new System.Drawing.Size(367, 583);
            this.routeDetailScreen2.TabIndex = 0;
            // 
            // RouteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.Name = "RouteControl";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
