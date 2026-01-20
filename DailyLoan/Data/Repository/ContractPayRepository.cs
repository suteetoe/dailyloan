using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class ContractPayRepository : RepositoryBase<ContractPay>
    {
        public ContractPayRepository() : base()
        {

        }

        public String NextDocNo(string docTypeCode, DateTime date, string format)
        {
            AutoRunning __autoRunning = new AutoRunning(docTypeCode, format, date);
            string queryGetLastDoc = __autoRunning.NextRunningQuery(ContractPay.TABLE_NAME, "doc_no");

            string lastDoc = this.connecton.ExecuteScalar<string>(queryGetLastDoc);

            if (string.IsNullOrEmpty(lastDoc))
            {
                lastDoc = "";
            }
            string newDocNo = __autoRunning.NextRunning(lastDoc);

            return newDocNo;
        }

        public void CreateContractPayment(ContractPay data)
        {
            string sqlInsert =
                @"INSERT INTO " + ContractPay.TABLE_NAME + @" (doc_no, doc_date, doc_time, contract_no, total_amount, create_by) 
                  VALUES(@doc_no, @doc_date, @doc_time, @contract_no, @total_amount, @create_by); ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@doc_no", data.doc_no);
            parameters.Add("@doc_date", data.doc_date);
            parameters.Add("@doc_time", data.doc_time);
            //parameters.Add("@cust_code", data.cust_code);
            parameters.Add("@contract_no", data.contract_no);
            parameters.Add("@total_amount", data.total_amount);
            parameters.Add("@create_by", App.UserId);

            this.connecton.ExecuteCommand(sqlInsert, parameters);
        }
    }
}
