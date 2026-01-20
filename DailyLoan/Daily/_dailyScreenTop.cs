using DailyLoan.Data.Repository;
using DailyLoan.Screen.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Daily
{
    public class _dailyScreenTop : SMLControl._myScreen
    {
        RouteRepository routeRepository = new RouteRepository();
        public _dailyScreenTop()
        {
            this._maxColumn = 1;

            this.AddDateField(new SMLControl.DateField() { Row = 0, Column = 0, FieldCode = "contract_date", FieldName = "วันที่", Required = true });
            this.AddTextField(new SMLControl.TextField() { Row = 1, Column = 0, FieldCode = "route", FieldName = "สาย", MaxLength = 50, IsSearch = true, Required = true });

            this._textBoxSearch += _dailyScreenTop__textBoxSearch;
            this._textBoxChanged += _dailyScreenTop__textBoxChanged;
        }

        private void _dailyScreenTop__textBoxChanged(object sender, string name)
        {
            if (name.Equals("route"))
            {
                string routeCode = this._getDataStr("route");
                var route = routeRepository.GetRouteByCode(routeCode);
                if (route != null)
                {
                    this._setDataStr("route", route.code, route.name_1, true);

                }
            }
        }

        private void _dailyScreenTop__textBoxSearch(object sender, string name)
        {
            if (name.Equals("route"))
            {
                SearchRouteForm searchRouteForm = new SearchRouteForm();
                searchRouteForm.AfterSelectData += (rowData) =>
                {
                    this._setDataStr("route", rowData["code"].ToString());
                    searchRouteForm.Close();
                };
                searchRouteForm.ShowDialog();
            }
        }
    }
}
