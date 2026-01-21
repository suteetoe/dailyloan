using BizFlowControl;
using DailyLoan.Data.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class ContractRepository : RepositoryBase<Contract>
    {
        public ContractRepository() : base()
        {

        }

        public void CreateContract(Contract contract)
        {
            TransactionConnection txn = this.connecton.CreateTransactionConnection();

            try
            {
                string sqlInsert =
                    @"INSERT INTO " + Contract.TABLE_NAME + @" (contract_no, contract_date, loan_type, route_code, customer_code, description, principle_amount, interest_rate, total_interest, num_of_period, amount_per_period, first_period_date, create_by) 
                  VALUES(@contract_no, @contract_date, @loan_type, @route_code, @customer_code, @description, @principle_amount, @interest_rate, @total_interest, @num_of_period, @amount_per_period, @first_period_date, @create_by); ";

                var parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@contract_no", contract.contract_no);
                parameters.Add("@contract_date", contract.contract_date);
                parameters.Add("@loan_type", contract.loan_type);
                parameters.Add("@route_code", contract.route_code);
                parameters.Add("@customer_code", contract.customer_code);
                // parameters.Add("@product_group", contract.product_group);
                parameters.Add("@description", contract.description);
                parameters.Add("@principle_amount", contract.principle_amount);
                parameters.Add("@interest_rate", contract.interest_rate);
                parameters.Add("@total_interest", contract.total_interest);
                parameters.Add("@num_of_period", contract.num_of_period);
                parameters.Add("@amount_per_period", contract.amount_per_period);
                parameters.Add("@first_period_date", contract.first_period_date);
                parameters.Add("@create_by", App.UserId);

                txn.ExecuteCommand(sqlInsert, parameters);

                string sqlInsertContracePeriod =
                    @"INSERT INTO " + ContractPeriod.TABLE_NAME + @" (contract_no, period_no, due_date, amount) 
                  VALUES(@contract_no, @period_no, @due_date, @amount); ";

                foreach (var period in contract.ContractPeriods)
                {
                    var periodParameters = new BizFlowControl.ExecuteParams();

                    periodParameters.Add("@contract_no", contract.contract_no);
                    periodParameters.Add("@period_no", period.period_no);
                    periodParameters.Add("@due_date", period.due_date);
                    periodParameters.Add("@amount", period.amount);

                    txn.ExecuteCommand(sqlInsertContracePeriod, periodParameters);
                }

                txn.CommitTransaction();
            }
            catch (Exception ex)
            {
                txn.RollbackTransaction();
                throw ex;
            }
        }

        public Contract FindContractByContractNo(string contractNo)
        {

            string queryGetContract = "SELECT * FROM " + Contract.TABLE_NAME + " WHERE contract_no = \'" + contractNo + "\'";

            string queryGetContractPeriod = "SELECT * FROM " + ContractPeriod.TABLE_NAME + " WHERE contract_no = \'" + contractNo + "\' ORDER BY period_no ASC";

            var resultContract = this.connecton.QueryData(queryGetContract);
            var resultContractPeriod = this.connecton.QueryData(queryGetContractPeriod);

            if (resultContract.Tables.Count > 0 && resultContract.Tables[0].Rows.Count > 0)
            {
                var contract = this.MapFromDataRow(resultContract.Tables[0].Rows[0]);

                if (resultContractPeriod.Tables.Count > 0)
                {
                    List<ContractPeriod> contractPeriods = new List<ContractPeriod>();

                    foreach (System.Data.DataRow row in resultContractPeriod.Tables[0].Rows)
                    {
                        var contractPeriod = new ContractPeriod();
                        contractPeriod.period_no = Convert.ToInt32(row["period_no"]);
                        contractPeriod.due_date = Convert.ToDateTime(row["due_date"]);
                        contractPeriod.amount = Convert.ToDecimal(row["amount"]);

                        contractPeriods.Add(contractPeriod);
                    }

                    contract.ContractPeriods = contractPeriods;
                }

                return contract;
            }

            return null;
        }

        public ContractBalance FindContractWithBalanceByContractNo(string contractNo)
        {
            string queryGetContract = "SELECT * FROM " + Contract.TABLE_NAME + " WHERE contract_no = \'" + contractNo + "\'";

            var resultContract = this.connecton.QueryData(queryGetContract);

            string queryGetContractPeriod =
                @"with contract_period_payment as (
                    select cp.period_no, due_date, amount, coalesce(pay_amount, 0) as pay_amount

                    from txn_contract_period as cp

                    left join txn_contract_period_payment as pay on pay.contract_no = cp.contract_no and cp.period_no = pay.period_no

                    where cp.contract_no = @contract_no
                )
                select period_no, due_date, amount, pay_amount
                , (case when(due_date < date(now()) and ((amount - pay_amount) > 0)) then (amount - pay_amount) else 0 end) as over_due_amount

                from contract_period_payment order by period_no";

            BizFlowControl.ExecuteParams parameters = new ExecuteParams();
            parameters.Add("@contract_no", contractNo);
            var resultContractPeriod = this.connecton.QueryData(queryGetContractPeriod, parameters);

            if (resultContract.Tables.Count > 0 && resultContract.Tables[0].Rows.Count > 0)
            {
                var c = this.MapFromDataRow(resultContract.Tables[0].Rows[0]);

                var contract = ContractBalance.PhaseFromContract(c);


                if (resultContractPeriod.Tables.Count > 0)
                {
                    List<ContractPeriodBalance> contractPeriodsBalance = new List<ContractPeriodBalance>();

                    foreach (System.Data.DataRow row in resultContractPeriod.Tables[0].Rows)
                    {
                        var contractPeriod = new ContractPeriodBalance();
                        contractPeriod.period_no = Convert.ToInt32(row["period_no"]);
                        contractPeriod.due_date = Convert.ToDateTime(row["due_date"]);
                        contractPeriod.amount = Convert.ToDecimal(row["amount"]);
                        contractPeriod.paid_amount = Convert.ToDecimal(row["pay_amount"]);
                        contractPeriod.over_due_amount = Convert.ToDecimal(row["over_due_amount"]);
                        contractPeriodsBalance.Add(contractPeriod);
                    }

                    contract.ContractPeriodBalances = contractPeriodsBalance;
                }

                return contract;
            }
            return null;
        }

        private Contract MapFromDataRow(DataRow row)
        {
            Contract contract = new Contract();
            contract.contract_no = row["contract_no"].ToString();
            contract.contract_date = Convert.ToDateTime(row["contract_date"]);
            contract.loan_type = row["loan_type"].ToString();
            contract.route_code = row["route_code"].ToString();
            contract.customer_code = row["customer_code"].ToString();
            contract.description = row["description"].ToString();
            contract.principle_amount = Convert.ToDecimal(row["principle_amount"]);
            contract.interest_rate = Convert.ToDecimal(row["interest_rate"]);
            contract.total_interest = Convert.ToDecimal(row["total_interest"]);
            contract.num_of_period = Convert.ToInt32(row["num_of_period"]);
            contract.amount_per_period = Convert.ToDecimal(row["amount_per_period"]);
            contract.first_period_date = Convert.ToDateTime(row["first_period_date"]);
            return contract;
        }
    }
}
