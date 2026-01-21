using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizFlowControl
{
    public class TransactionConnection
    {
        NpgsqlConnection connection;
        NpgsqlTransaction transaction;

        public TransactionConnection(NpgsqlConnection connection)
        {
            this.connection = connection;
            this.transaction = this.connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Commit();
                this.transaction.Dispose();
                this.transaction = null;
            }

        }

        public void RollbackTransaction()
        {
            if (this.transaction != null)
            {
                this.transaction.Rollback();
                this.transaction.Dispose();
                this.transaction = null;
            }
        }

        public void ExecuteCommand(string query, ExecuteParams dataParams = null)
        {
            try
            {
                using (var cmd = new NpgsqlCommand(query, this.connection, this.transaction))
                {
                    if (dataParams != null)
                    {
                        foreach (var param in dataParams)
                        {
                            if (param.Value is NpgsqlParameter)
                            {
                                var paramCmd = (NpgsqlParameter)param.Value;

                                cmd.Parameters.Add(paramCmd);
                            }
                            else if (param.Value is JsonBParameter)
                            {
                                var jsonbParam = (JsonBParameter)param.Value;
                                var paramCmd = new NpgsqlParameter(param.Key, NpgsqlTypes.NpgsqlDbType.Jsonb)
                                {
                                    Value = jsonbParam.Value
                                };
                                cmd.Parameters.Add(paramCmd);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue(param.Key, param.Value);
                            }
                        }
                    }

                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (PostgresException ex)
            {
                throw new DBException(ex.SqlState, ex.Message);
            }
            catch (Exception ex)
            {
                throw new DBException("0", ex.Message);
            }
        }

    }
}
