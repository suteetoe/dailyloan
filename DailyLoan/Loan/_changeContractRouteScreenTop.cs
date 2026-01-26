using DailyLoan.Data.Repository;
using DailyLoan.Screen.Route;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Loan
{
    public class _changeContractRouteScreenTop : SMLControl._myScreen
    {
        RouteRepository routeRepository = new RouteRepository();
        public _changeContractRouteScreenTop()
        {
            this._maxColumn = 1;
            this.AddTextField(new SMLControl.TextField() { Row = 0, Column = 0, FieldCode = "route_code", FieldName = "สาย", MaxLength = 50, IsSearch = true, Required = true });

            this._textBoxSearch += _changeContractRouteScreenTop__textBoxSearch;
            this._textBoxChanged += _changeContractRouteScreenTop__textBoxChanged;
        }

        private void _changeContractRouteScreenTop__textBoxChanged(object sender, string name)
        {
            string routeCode = this._getDataStr("route_code");
            var route = this.routeRepository.GetRouteByCode(routeCode);
            if (route != null)
            {
                this._setDataStr("route_code", route.code, route.name_1, true);

            }
        }

        private void _changeContractRouteScreenTop__textBoxSearch(object sender, string name)
        {
            SearchRouteForm searchRouteForm = new SearchRouteForm();
            searchRouteForm.AfterSelectData += (rowData) =>
            {
                this._setDataStr("route_code", rowData["code"].ToString());
                searchRouteForm.Close();
            };
            this.StartSearchForm(searchRouteForm, "route_code");
        }
    }
}
