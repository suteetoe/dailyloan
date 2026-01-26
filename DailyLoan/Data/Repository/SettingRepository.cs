using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class SettingRepository : RepositoryBase<Settings>
    {
        public SettingRepository() : base()
        {
        }

        public Settings LoadSetting()
        {
            string query = "select * from sys_options";

            var result = this.connecton.QueryData(query);

            if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                var row = result.Tables[0].Rows[0];
                Settings setting = new Settings()
                {
                    npl_period = Convert.ToInt32(row["npl_period"])
                };
                return setting;
            }
            return null;
        }
    }
}
