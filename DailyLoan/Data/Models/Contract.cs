using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class Contract
    {
        public const string TABLE_NAME = "txn_contract";

        public int id { get; set; }

        public String contract_no { get; set; }

        public DateTime contract_date { get; set; }

        public String loan_type { get; set; }

        public String route_code { get; set; }

        public String customer_code { get; set; }

        // public String product_group { get; set; }

        public String description { get; set; }

        public decimal principle_amount { get; set; }

        public decimal interest_rate { get; set; }

        public decimal total_interest { get; set; }

        public int num_of_period { get; set; }

        public decimal amount_per_period { get; set; }

        public decimal total_contract_amount { get; set; }

        public DateTime first_period_date { get; set; }

        public DateTime last_period_date { get; set; }

        public decimal total_pay_amount { get; set; }

        public int contract_status { get; set; }

        public LoanType loanType { get; set; }

        public Route route { get; set; }

        public Customer customer { get; set; }

        public List<ContractPeriod> ContractPeriods { get; set; }

        public int pay_count { get; set; }

    }

    public class ContractBalance : Contract
    {
        public List<ContractPeriodBalance> ContractPeriodBalances { get; set; }

        public static ContractBalance PhaseFromContract(Contract contract)
        {
            ContractBalance contractBalance = new ContractBalance();
            contractBalance.id = contract.id;
            contractBalance.contract_no = contract.contract_no;
            contractBalance.contract_date = contract.contract_date;
            contractBalance.loan_type = contract.loan_type;
            contractBalance.route_code = contract.route_code;
            contractBalance.customer_code = contract.customer_code;
            contractBalance.description = contract.description;
            contractBalance.principle_amount = contract.principle_amount;
            contractBalance.interest_rate = contract.interest_rate;
            contractBalance.total_interest = contract.total_interest;
            contractBalance.num_of_period = contract.num_of_period;
            contractBalance.amount_per_period = contract.amount_per_period;
            contractBalance.first_period_date = contract.first_period_date;
            contractBalance.last_period_date = contract.last_period_date;
            contractBalance.total_contract_amount = contract.total_contract_amount;
            contractBalance.description = contract.description;
            contractBalance.total_pay_amount = contract.total_pay_amount;
            contractBalance.contract_status = contract.contract_status;

            return contractBalance;
        }
    }

    public enum ContractStatus
    {
        Normal = 0,
        Close = 1,
    }

}
