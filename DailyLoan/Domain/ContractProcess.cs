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
        HolidayRepository holidayRepository = new HolidayRepository();

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

        public void CheckLoadPeriodInrdinaryHoliday()
        {
            string queryCheckPeriodInrdinaryHoliday = @"
select distinct txn_contract_period.contract_no, mst_loan_type.working_holiday_type
from txn_contract_period 
join txn_contract on txn_contract.contract_no = txn_contract_period.contract_no 
join mst_loan_type on mst_loan_type.code = txn_contract.loan_type
where txn_contract.contract_status = 0
and (
(mst_loan_type.working_holiday_type = 1 and ((extract (DOW from due_date)) in (0,6) ))
or (mst_loan_type.working_holiday_type = 1 and ((extract (DOW from due_date)) in (0) ))
or (exists (select date_holiday from mst_holiday where mst_holiday.date_holiday=txn_contract_period.due_date))
)
";

            var ds = App.DBConnection.QueryData(queryCheckPeriodInrdinaryHoliday);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                List<Holiday> holidays = holidayRepository.ListHoliday(new DateTime());
                List<DateTime> Dateholidays = holidays.Select(h => h.holiday_date).ToList();


                for (int row = 0; row < ds.Tables[0].Rows.Count; row++)
                {
                    string contractNo = ds.Tables[0].Rows[row][0].ToString();
                    int workingHolidayType = Convert.ToInt32(ds.Tables[0].Rows[row][1]);

                    var contract = contractRepository.FindContractByContractNo(contractNo);

                    if (contract != null)
                    {

                        LoanPeriod newPeriodProcess = new LoanPeriod(contract.total_contract_amount, contract.num_of_period, contract.amount_per_period, contract.first_period_date, 0);
                        newPeriodProcess.ProcessDay = (ProcessDay)workingHolidayType;
                        newPeriodProcess.AddHolidays(Dateholidays.ToArray());
                        newPeriodProcess.CalcPeriodAmount();
                        List<PayPeriod> payPeriods = newPeriodProcess.PayPeriods.ToList();

                        // diff period date
                        //foreach (var period in contract.ContractPeriods)
                        //{
                        //    var newPeriod = payPeriods.Where(p => p.PeriodNumber == period.period_no).FirstOrDefault();
                        //    if (newPeriod != null && newPeriod.PayDueDate.Date.CompareTo(period.due_date.Date) != 0)
                        //    {
                        //        contractRepository.UpdateContractPeriodDueDate(contractNo, period.period_no, newPeriod.PayDueDate);
                        //    }
                        //}

                        var diffPeriod = newPeriodProcess.DiffContractPeriodDate(contract.ContractPeriods.ToArray());
                        if (diffPeriod.Count > 0)
                        {
                            foreach (var period in diffPeriod)
                            {
                                contractRepository.UpdateContractPeriodDueDate(contractNo, period.PeriodNumber, period.PayDueDate);
                            }
                        }

                    }
                }
            }
        }




    }
}
