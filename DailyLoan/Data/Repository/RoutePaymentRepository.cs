using BizFlowControl;
using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public RoutePayment GetRoutePaymentByDocNo(string docNo)
        {
            string queryRoutePaymentHeader =
                @"SELECT doc_date, doc_no, txn_route_payment.route_code, mst_route.name_1 as route_name , total_route_amount 
                FROM txn_route_payment 
                JOIN mst_route on mst_route.code = txn_route_payment.route_code
                WHERE doc_no = @doc_no ";

            string queryRoutePaymentDetail =
                @"SELECT txn_route_payment_detail.contract_no, txn_contract.customer_code, mst_customer.name_1 as customer_name, txn_route_payment_detail.total_amount
                FROM txn_route_payment_detail
                JOIN txn_contract on txn_contract.contract_no = txn_route_payment_detail.contract_no
                JOIN mst_customer on mst_customer.code = txn_contract.customer_code
                WHERE txn_route_payment_detail.doc_no = @doc_no
                order by txn_route_payment_detail.line_number
                ";

            var parameters = new BizFlowControl.ExecuteParams();
            parameters.Add("@doc_no", docNo);
            var routePayment = this.connecton.QueryData(queryRoutePaymentHeader, parameters);
            var routePaymentDetails = this.connecton.QueryData(queryRoutePaymentDetail, parameters);


            if (routePayment.Tables.Count > 0)
            {
                RoutePayment result = new RoutePayment();
                var headerRow = routePayment.Tables[0].Rows[0];
                result.doc_no = headerRow["doc_no"].ToString();
                result.doc_date = Convert.ToDateTime(headerRow["doc_date"]);
                result.route_code = headerRow["route_code"].ToString();
                result.route = new Route()
                {
                    code = headerRow["route_code"].ToString(),
                    name_1 = headerRow["route_name"].ToString()
                };
                result.total_route_amount = Convert.ToDecimal(headerRow["total_route_amount"]);

                result.Details = new List<RoutePaymentDetail>();

                if (routePaymentDetails.Tables.Count > 0)
                {
                    DataTable detailTable = routePaymentDetails.Tables[0];
                    for (int row = 0; row < detailTable.Rows.Count; row++)
                    {
                        result.Details.Add(new RoutePaymentDetail()
                        {
                            contract_no = detailTable.Rows[row]["contract_no"].ToString(),
                            customer_code = detailTable.Rows[row]["customer_code"].ToString(),
                            customer_name = detailTable.Rows[row]["customer_name"].ToString(),
                            total_amount = Convert.ToDecimal(detailTable.Rows[row]["total_amount"])

                        });
                    }
                }

                return result;
            }

            return null;

        }

        public void DeleteRoutePayment(string docNo)
        {
            TransactionConnection txn = this.connecton.CreateTransactionConnection();

            try
            {
                string sqlDeletePaymentRouteDetail =
                    @"DELETE FROM " + RoutePaymentDetail.TABLE_NAME + @" WHERE doc_no = @doc_no; ";

                var parameters = new BizFlowControl.ExecuteParams();
                parameters.Add("@doc_no", docNo);

                txn.ExecuteCommand(sqlDeletePaymentRouteDetail, parameters);

                string sqlDeletePaymentRoute =
                    @"DELETE FROM " + RoutePayment.TABLE_NAME + @" WHERE doc_no = @doc_no; ";

                txn.ExecuteCommand(sqlDeletePaymentRoute, parameters);

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
