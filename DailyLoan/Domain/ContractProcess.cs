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

            paymentProcess.CalcPrincipleAndInterest();

            var processResult = paymentProcess.GetResult();
            contractPeriodPaymentRepository.UpSertContractPeriodPayment(processResult.ToArray());
            int paySuccessCount = paymentProcess.PaySuccessPeriodCount();

            bool isPayAmountChanged = contract.total_pay_amount.CompareTo(paymentProcess.totalPayAmount) != 0;
            bool isPayCountChanged = contract.pay_count != paySuccessCount;
            bool isPayPrincipalChanged = contract.total_paid_principle.CompareTo(paymentProcess.TotalPaidPrincipal) != 0;
            bool isPayInterestChanged = contract.total_paid_interest.CompareTo(paymentProcess.TotalPaidInterest) != 0;

            if (isPayAmountChanged || isPayCountChanged || isPayPrincipalChanged || isPayInterestChanged)
            {
                contractRepository.UpdateContractTotalPayAmount(contract.contract_no, paymentProcess.totalPayAmount, paySuccessCount, paymentProcess.TotalPaidPrincipal, paymentProcess.TotalPaidInterest);
            }

            if (contract.total_contract_amount.CompareTo(paymentProcess.totalPayAmount) == 0)
            {
                contractRepository.UpdateContractCloseStatus(contract.contract_no, (int)ContractStatus.Close);
            }
            else if (contract.total_contract_amount.CompareTo(paymentProcess.totalPayAmount) != 0 && contract.contract_status == 1)
            {
                contractRepository.UpdateContractCloseStatus(contract.contract_no, (int)ContractStatus.Normal);
            }
        }
    }
}
