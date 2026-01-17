using DailyLoan.Data.Models;
using SMLControl.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class LoanTypeRepository : RepositoryBase<LoanType>
    {
        public LoanTypeRepository() : base()
        {

        }

        public LoanType GetLoanTypeByCode(string loanTypeCode)
        {
            DataTable result = null;
            string selectQuery =
                @"SELECT code, name_1, working_holiday_type 
                  FROM " + LoanType.TABLE_NAME + @" 
                  WHERE code = '" + loanTypeCode  +"'";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", loanTypeCode);

            var ds = connecton.QueryData(selectQuery);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0];

                LoanType holiday = new LoanType();

                holiday.code = result.Rows[0]["code"].ToString();
                holiday.name_1 = result.Rows[0]["name_1"].ToString();
                holiday.working_holiday_type = _numberUtils._intPhase(result.Rows[0]["working_holiday_type"].ToString());

                result.Dispose();


                return holiday;
            }
            return null;
        }

        public LoanType CreateLoanType(LoanType loantype)
        {
            string insertQuery =
                @"INSERT INTO " + LoanType.TABLE_NAME + @" (code, name_1, working_holiday_type) 
                  VALUES(@code, @name_1, @working_holiday_type); ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", loantype.code);
            parameters.Add("@name_1", loantype.name_1);
            parameters.Add("@working_holiday_type", loantype.working_holiday_type);
            connecton.ExecuteCommand(insertQuery, parameters);

            return loantype;
        }

        public void UploadLoanType(LoanType loantype)
        {
            string updateQuery =
                @"UPDATE " + LoanType.TABLE_NAME + @" 
                  SET name_1 = @name_1,
                      working_holiday_type = @working_holiday_type
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", loantype.code);
            parameters.Add("@name_1", loantype.name_1);
            parameters.Add("@working_holiday_type", loantype.working_holiday_type);

            connecton.ExecuteCommand(updateQuery, parameters);
        }

        public void DeleleteLoanType(string loadTypeCode)
        {
            string deleteQuery =
                @"DELETE FROM " + LoanType.TABLE_NAME + @" 
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", loadTypeCode);

            connecton.ExecuteCommand(deleteQuery, parameters);

        }

    }
}
