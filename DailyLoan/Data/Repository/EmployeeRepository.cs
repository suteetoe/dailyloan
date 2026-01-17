using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>
    {
        public EmployeeRepository() : base()
        {

        }



        public DataTable SearchEmployee(int page, int size)
        {
            Paginator paginator = new Paginator(page, size);
            string pageFilterQuery = paginator.GetPaginationQuery();
            string query = "SELECT code, name_1 FROM " + Employee.TABLE_NAME + " " + pageFilterQuery;

            var ds = connecton.QueryData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public int CountEmployee()
        {
            string query = "SELECT COUNT(*) AS total FROM " + Employee.TABLE_NAME;

            var ds = connecton.QueryData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                return Convert.ToInt32(row["total"]);
            }
            return 0;
        }

        public DataTable GetEmployeeByCode(string code)
        {
            DataTable result = null;

            string query = "SELECT code, name_1 FROM " + Employee.TABLE_NAME + " WHERE code = '" + code + "'";
            var ds = connecton.QueryData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                result = ds.Tables[0];
            }
            return result;
        }

        public Employee CreateEmployee(Employee employee)
        {
            string insertQuery =
                @"INSERT INTO " + Employee.TABLE_NAME + @" (code, name_1) 
                  VALUES(@code, @name_1); ";

            var parameters = new  BizFlowControl.ExecuteParams();
            parameters.Add("@code", employee.code);
            parameters.Add("@name_1", employee.name_1);

            connecton.ExecuteCommand(insertQuery, parameters);
            return employee;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            string updateQuery =
                @"UPDATE " + Employee.TABLE_NAME + @" 
                  SET name_1 = @name_1
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", employee.code);
            parameters.Add("@name_1", employee.name_1);

            connecton.ExecuteCommand(updateQuery, parameters);
            return employee;
        }

        public void DeleteEmployee(string code)
        {
            string deleteQuery =
                @"DELETE FROM " + Employee.TABLE_NAME + @" 
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", code);

            connecton.ExecuteCommand(deleteQuery, parameters);
        }

    }
}
