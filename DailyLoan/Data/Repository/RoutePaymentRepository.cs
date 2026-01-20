using BizFlowControl;
using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class RoutePaymentRepository : RepositoryBase<RoutePayment>
    {
        public RoutePaymentRepository() : base()
        {

        }

        public String NextDocNo(string docTypeCode, DateTime date, string format)
        {
            AutoRunning __autoRunning = new AutoRunning(docTypeCode, format, date);
            string queryGetLastDoc = __autoRunning.NextRunningQuery(RoutePayment.TABLE_NAME, "doc_no");

            string lastDoc = this.connecton.ExecuteScalar<string>(queryGetLastDoc);

            if (string.IsNullOrEmpty(lastDoc))
            {
                lastDoc = "";
            }
            string newDocNo = __autoRunning.NextRunning(lastDoc);

            return newDocNo;
        }

        public void CreateRoutePayment(RoutePayment routePayment)
        {
            TransactionConnection txn = this.connecton.CreateTransactionConnection();

            try
            {
                string sqlInsertPaymentRoute =
                    @"INSERT INTO " + RoutePayment.TABLE_NAME + @" (doc_no, doc_date, doc_time, route_code, total_route_amount, create_by) 
                  VALUES(@doc_no, @doc_date, @doc_time, @route_code, @total_route_amount, @create_by); ";

                var parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@doc_no", routePayment.doc_no);
                parameters.Add("@doc_date", routePayment.doc_date);
                parameters.Add("@doc_time", routePayment.doc_time);
                parameters.Add("@route_code", routePayment.route_code);
                parameters.Add("@total_route_amount", routePayment.total_route_amount);
                parameters.Add("@create_by", App.UserId);

                txn.ExecuteCommand(sqlInsertPaymentRoute, parameters);
                string sqlInsertPaymentRouteDetail =
                    @"INSERT INTO " + RoutePaymentDetail.TABLE_NAME + @" (doc_no, contract_no, total_amount, line_number) 
                  VALUES(@doc_no, @contract_no, @total_amount, @line_number); ";

                int rowNumber = 0;
                foreach (var detail in routePayment.Details)
                {
                    var detailParameters = new BizFlowControl.ExecuteParams();
                    detailParameters.Add("@doc_no", routePayment.doc_no);
                    detailParameters.Add("@contract_no", detail.contract_no);
                    detailParameters.Add("@total_amount", detail.total_amount);
                    detailParameters.Add("@line_number", ++rowNumber);

                    txn.ExecuteCommand(sqlInsertPaymentRouteDetail, detailParameters);
                }

                txn.CommitTransaction();
            }
            catch (Exception)
            {
                txn.RollbackTransaction();
                throw;
            }
        }
    }
}
