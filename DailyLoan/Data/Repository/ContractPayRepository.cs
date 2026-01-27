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

        public List<ContractPay> ListPaymentByContract(string contractNo)
        {
            List<ContractPay> list = new List<ContractPay>();

            string query =
                @"WITH contract_payment as (
                select id, doc_date, doc_time, doc_no, contract_no, total_amount from txn_payment where contract_no = @contract_no
                union all
                select d.id, p.doc_date, p.doc_time, d.doc_no, d.contract_no, d.total_amount from txn_route_payment_detail  as d
                join txn_route_payment as p on p.doc_no = d.doc_no
                where d.contract_no = @contract_no
                )
                select id, doc_date, doc_time, doc_no, contract_no, total_amount 
                from contract_payment order by doc_date,doc_time, id";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@contract_no", contractNo);
            DataSet ds = this.connecton.QueryData(query, parameters);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ContractPay item = new ContractPay();
                item.id = Convert.ToInt32(dr["id"]);
                item.doc_date = Convert.ToDateTime(dr["doc_date"]);
                item.doc_time = dr["doc_time"].ToString();
                item.doc_no = dr["doc_no"].ToString();
                item.contract_no = dr["contract_no"].ToString();
                item.total_amount = Convert.ToDecimal(dr["total_amount"]);

                list.Add(item);
            }

            return list;
        }

        public ContractPay GetContractPaymentByDocNo(string docNo)
        {
            string query =
                @"SELECT txn_payment.id, txn_payment.doc_date, txn_payment.doc_time, txn_payment.doc_no, txn_payment.contract_no, txn_payment.total_amount, txn_contract.customer_code, mst_customer.name_1 as cust_name
                FROM  txn_payment 
                JOIN txn_contract ON txn_contract.contract_no = txn_payment.contract_no
                JOIN mst_customer on mst_customer.code = txn_contract.customer_code
                WHERE txn_payment.doc_no = @doc_no ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@doc_no", docNo);

            DataSet ds = this.connecton.QueryData(query, parameters);
            if (ds.Tables.Count > 0)
            {
                DataTable table = ds.Tables[0];
                if (table.Rows.Count > 0)
                {
                    ContractPay contractPay = new ContractPay();
                    DataRow dr = table.Rows[0];
                    contractPay.id = Convert.ToInt32(dr["id"]);
                    contractPay.doc_date = Convert.ToDateTime(dr["doc_date"]);
                    contractPay.doc_time = dr["doc_time"].ToString();
                    contractPay.doc_no = dr["doc_no"].ToString();
                    contractPay.contract_no = dr["contract_no"].ToString();
                    contractPay.total_amount = Convert.ToDecimal(dr["total_amount"]);
                    contractPay.contract = new Contract();
                    contractPay.contract.customer_code = dr["customer_code"].ToString();
                    contractPay.contract.customer = new Customer();
                    contractPay.contract.customer.name_1 = dr["cust_name"].ToString();


                    return contractPay;
                }

            }
            return null;
        }

        public void DeletePayment(string docNo)
        {
            string deleteQuery = @"DELETE FROM txn_payment WHERE doc_no = @doc_no; ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@doc_no", docNo);

            this.connecton.ExecuteCommand(deleteQuery, parameters);

        }
    }
}
