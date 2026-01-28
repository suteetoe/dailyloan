using DailyLoan.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyLoan.Data.Repository
{
    public class ExpenseRepository : RepositoryBase<Expense>
    {
        public ExpenseRepository() : base()
        {
        }

        public Expense GetExpenseByDocNo(string docNo)
        {
            string selectSql = $@"SELECT * FROM {Expense.TABLE_NAME} 
                                      WHERE doc_no = @doc_no";

            BizFlowControl.ExecuteParams parameter = new BizFlowControl.ExecuteParams();
            parameter.Add("@doc_no", docNo);

            var result = this.connecton.QueryData(selectSql, parameter);
            if (result.Tables.Count > 0 && result.Tables[0].Rows.Count > 0)
            {
                var row = result.Tables[0].Rows[0];
                Expense expense = new Expense()
                {
                    id = Convert.ToInt32(row["id"]),
                    doc_date = Convert.ToDateTime(row["doc_date"]),
                    doc_no = row["doc_no"].ToString(),
                    remark = row["remark"].ToString(),
                    total_amount = Convert.ToDecimal(row["total_amount"])
                };
                return expense;
            }

            return null;
        }

        public void CreateExpense(Expense data)
        {
            string createSql = $@"INSERT INTO {Expense.TABLE_NAME} (doc_date, doc_no, remark, total_amount, create_by)
                                        VALUES (@doc_date, @doc_no, @remark, @total_amount, @userid)";

            BizFlowControl.ExecuteParams parameter = new BizFlowControl.ExecuteParams();
            parameter.Add("@doc_date", data.doc_date);
            parameter.Add("@doc_no", data.doc_no);
            parameter.Add("@remark", data.remark);
            parameter.Add("@total_amount", data.total_amount);
            parameter.Add("@userid", App.UserId);

            this.connecton.ExecuteCommand(createSql, parameter);

        }

        public void UpdateExpense(Expense data)
        {
            string updateSql = $@"UPDATE {Expense.TABLE_NAME} 
                                      SET doc_date = @doc_date,
                                          remark = @remark,
                                          total_amount = @total_amount,
                                          update_by = @userid
                                      WHERE doc_no = @doc_no";

            BizFlowControl.ExecuteParams parameter = new BizFlowControl.ExecuteParams();
            parameter.Add("@doc_date", data.doc_date);
            parameter.Add("@remark", data.remark);
            parameter.Add("@total_amount", data.total_amount);
            parameter.Add("@userid", App.UserId);
            parameter.Add("@doc_no", data.doc_no);

            this.connecton.ExecuteCommand(updateSql, parameter);


        }

        public void DeleteExpense(string docNo)
        {
            string deleteSql = $@"DELETE FROM {Expense.TABLE_NAME} 
                                      WHERE doc_no = @doc_no";

            BizFlowControl.ExecuteParams parameter = new BizFlowControl.ExecuteParams();
            parameter.Add("@doc_no", docNo);

            this.connecton.ExecuteCommand(deleteSql, parameter);
        }

    }


}
