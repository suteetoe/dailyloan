using DailyLoan.Data.Models;
using DailyLoan.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Domain
{
    public class ContractProcess
    {
        ContractRepository contractRepository = new ContractRepository();
        ContractPayRepository contractPayRepository = new ContractPayRepository();
        ContractPeriodPaymentRepository contractPeriodPaymentRepository = new ContractPeriodPaymentRepository();

        public ContractProcess()
        {
        }

        public void StartProcessPayment(string contractNo)
        {
            Contract contract = contractRepository.FindContractByContractNo(contractNo);
            List<ContractPay> listPayment = contractPayRepository.ListPaymentByContract(contractNo);

            LoanPaymentProcess paymentProcess = new LoanPaymentProcess(contract);
            foreach (var payment in listPayment)
            {
                paymentProcess.AddPayment(payment.doc_no, payment.doc_date, payment.doc_time, payment.total_amount);
            }

            var processResult = paymentProcess.GetResult();
            contractPeriodPaymentRepository.UpSertContractPeriodPayment(processResult.ToArray());

            if (contract.total_pay_amount.CompareTo(paymentProcess.totalPayAmount) != 0)
            {
                contractRepository.UpdateContractTotalPayAmount(contract.contract_no, paymentProcess.totalPayAmount);
            }

            if (contract.total_contract_amount.CompareTo(paymentProcess.totalPayAmount) == 0)
            {
                contractRepository.UpdateContractCloseStatus(contract.contract_no, (int)ContractStatus.Close);
            }
        }
    }
}
