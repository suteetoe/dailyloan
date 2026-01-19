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

        public DateTime first_period_date { get; set; }

        public LoanType loanType { get; set; }

        public Route route { get; set; }

        public Customer customer { get; set; }

        public List<ContractPeriod> ContractPeriods { get; set; }

    }

}
