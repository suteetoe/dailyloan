using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>
    {
        public CustomerRepository() : base()
        {

        }

        public Customer CreateCustomer(Customer customer)
        {
            string insertQuery =
                @"INSERT INTO " + Customer.TABLE_NAME + @" (code, name_1, address, telephone) 
                  VALUES(@code, @name_1, @address, @telephone); ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", customer.code);
            parameters.Add("@name_1", customer.name_1);
            parameters.Add("@address", customer.address);
            parameters.Add("@telephone", customer.telephone);
            connecton.ExecuteCommand(insertQuery, parameters);

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            string updateQuery =
                @"UPDATE " + Customer.TABLE_NAME + @" 
                  SET name_1 = @name_1, address = @address, telephone = @telephone
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", customer.code);
            parameters.Add("@name_1", customer.name_1);
            parameters.Add("@address", customer.address);
            parameters.Add("@telephone", customer.telephone);
            connecton.ExecuteCommand(updateQuery, parameters);
        }

        public void DeleteCustomer(string customerCode)
        {
            string deleteQuery =
                @"DELETE FROM " + Customer.TABLE_NAME + @" 
                  WHERE code = @code; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@code", customerCode);
            connecton.ExecuteCommand(deleteQuery, parameters);
        }

        public Customer GetCustomerByCode(string code)
        {
            string query = @"SELECT code, name_1, address, telephone 
                  FROM " + Customer.TABLE_NAME + @" 
                  WHERE code = '"+ code +"'; ";

            var ds = connecton.QueryData(query);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                Customer customer = new Customer
                {
                    code = row["code"].ToString(),
                    name_1 = row["name_1"].ToString(),
                    address = row["address"].ToString(),
                    telephone = row["telephone"].ToString()
                };
                return customer;
            }
            return null;
        }

    }
}
