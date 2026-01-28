using BizFlowControl;
using DailyLoan.Data.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class ContractPeriodPaymentRepository : RepositoryBase<ContractPeriodPayment>
    {
        public ContractPeriodPaymentRepository() : base()
        {

        }

        public void UpSertContractPeriodPayment(ContractPeriodPayment[] contractPeriodPayments)
        {
            TransactionConnection txn = this.connecton.CreateTransactionConnection();

            try
            {
                string upsertSql = 
                    "INSERT INTO " + ContractPeriodPayment.TABLE_NAME +
                    " (contract_no, period_no, pay_amount, pay_detail, pay_principal_amount, pay_interest_amount) " +
                    " values(@contract_no, @period_no, @pay_amount, @pay_detail, @pay_principal_amount, @pay_interest_amount) " +
                    " ON CONFLICT (contract_no, period_no) " +
                    " DO UPDATE SET " +
                    " pay_amount = EXCLUDED.pay_amount " +
                    " , pay_detail = EXCLUDED.pay_detail " +
                    " , pay_principal_amount = EXCLUDED.pay_principal_amount " +
                    " , pay_interest_amount = EXCLUDED.pay_interest_amount ; ";

                foreach (var contractPeriodPayment in contractPeriodPayments)
                {

                    var payDetail = JsonConvert.SerializeObject(contractPeriodPayment.pay_detail);

                    //var paramJson = new Npgsql.NpgsqlParameter("@pay_detail", NpgsqlTypes.NpgsqlDbType.Jsonb)
                    //{
                    //    Value = payDetail
                    //};

                    var parameters = new BizFlowControl.ExecuteParams();
                    parameters.Add("@contract_no", contractPeriodPayment.contract_no);
                    parameters.Add("@period_no", contractPeriodPayment.period_no);
                    parameters.Add("@pay_amount", contractPeriodPayment.pay_amount);
                    parameters.Add("@pay_detail", new BizFlowControl.JsonBParameter()
                    {
                        Value = payDetail
                    });
                    parameters.Add("@pay_principal_amount", contractPeriodPayment.pay_principal_amount);
                    parameters.Add("@pay_interest_amount", contractPeriodPayment.pay_interest_amount);

                    txn.ExecuteCommand(upsertSql, parameters);
                }

                txn.CommitTransaction();
            }
            catch
            {
                txn.RollbackTransaction();
                throw;
            }
          
        }

    }
}
