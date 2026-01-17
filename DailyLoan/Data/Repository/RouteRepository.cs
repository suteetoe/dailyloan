using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class RouteRepository : RepositoryBase<DailyLoan.Data.Models.Route>
    {
        public RouteRepository() : base()
        {
        }

        public DailyLoan.Data.Models.Route GetRouteByCode(string code)
        {

            string query = "SELECT code, name_1 FROM " + DailyLoan.Data.Models.Route.TABLE_NAME + " WHERE code = '" + code + "'";
            var ds = connecton.QueryData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {

                DailyLoan.Data.Models.Route r = new Models.Route();
                r.code = ds.Tables[0].Rows[0]["code"].ToString();
                r.name_1 = ds.Tables[0].Rows[0]["name_1"].ToString();
                return r;
            }

            return null;
        }

        public DailyLoan.Data.Models.Route CreateRoute(DailyLoan.Data.Models.Route route)
        {
            string insertQuery =
                @"INSERT INTO " + DailyLoan.Data.Models.Route.TABLE_NAME + @" (code, name_1) 
                  VALUES(@code, @name_1); ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", route.code);
            parameters.Add("@name_1", route.name_1);

            connecton.ExecuteCommand(insertQuery, parameters);

            return route;
        }

        public void UpdateRoute(DailyLoan.Data.Models.Route route)
        {
            string updateQuery =
                @"UPDATE " + DailyLoan.Data.Models.Route.TABLE_NAME + @" 
                  SET name_1 = @name_1
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", route.code);
            parameters.Add("@name_1", route.name_1);

            connecton.ExecuteCommand(updateQuery, parameters);
        }

        public void DeleteRoute(string code)
        {
            string deleteQuery =
                @"DELETE FROM " + DailyLoan.Data.Models.Route.TABLE_NAME + @" 
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", code);

            connecton.ExecuteCommand(deleteQuery, parameters);
        }

    }
}
