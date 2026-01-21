using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Models
{
    public class ContractPeriodPayment
    {

        public const string TABLE_NAME = "txn_contract_period_payment";

        public string contract_no { get; set; }

        public int period_no { get; set; }

        public decimal pay_amount { get; set; }

        public decimal pay_principal_amount { get; set; }

        public decimal pay_interest_amount { get; set; }

        public List<ContractPeriodPaymentDetail> pay_detail { get; set; }
    }
}
