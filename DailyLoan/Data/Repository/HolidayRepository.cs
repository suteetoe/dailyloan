using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class HolidayRepository : RepositoryBase<Holiday>
    {
        public HolidayRepository() : base()
        {

        }

        public Holiday GetHolidayByDate(DateTime date)
        {
            DataTable result = null;

            String dateStr = SMLControl.Utils._dateUtil._convertDateToQuery(date);

            string query = "SELECT date_holiday, remark FROM " + Holiday.TABLE_NAME + " WHERE date_holiday = '" + dateStr + "'";
            var ds = connecton.QueryData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0];

                Holiday holiday = new Holiday();
                holiday.holiday_date = Convert.ToDateTime(result.Rows[0]["date_holiday"]);
                holiday.remark = result.Rows[0]["remark"].ToString();
                return holiday;
            }
            return null;

        }

        public Holiday CreateHoliday(Holiday holiday)
        {
            // String dateStr = SMLControl.Utils._dateUtil._convertDateToQuery(holiday.holiday_date);

            string insertQuery =
                @"INSERT INTO " + Holiday.TABLE_NAME + @" (date_holiday, remark, year) 
                  VALUES(@date_holiday, @remark, @year); ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@date_holiday", holiday.holiday_date);
            parameters.Add("@remark", holiday.remark);
            parameters.Add("@year", holiday.holiday_date.Year);

            connecton.ExecuteCommand(insertQuery, parameters);

            return holiday;
        }

        public void UpdateHoliday(Holiday holiday)
        {
            String dateStr = SMLControl.Utils._dateUtil._convertDateToQuery(holiday.holiday_date);

            string updateQuery =
                @"UPDATE " + Holiday.TABLE_NAME + @" 
                  SET remark = @remark
                  WHERE date_holiday = @date_holiday; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@date_holiday", dateStr);
            parameters.Add("@remark", holiday.remark);

            connecton.ExecuteCommand(updateQuery, parameters);
        }

        public void DeleteHoliday(DateTime date)
        {
            String dateStr = SMLControl.Utils._dateUtil._convertDateToQuery(date);

            string deleteQuery =
                @"DELETE FROM " + Holiday.TABLE_NAME + @" 
                  WHERE date_holiday = @date_holiday; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@date_holiday", dateStr);

            connecton.ExecuteCommand(deleteQuery, parameters);
        }
    }
}
