using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BizFlowControl
{
    public class DBConnection
    {

        NpgsqlConnection connection;

        public Boolean Connected
        {
            get
            {
                return this.connection.State == System.Data.ConnectionState.Open;
            }
        }

        public DBConnection(string connectionString)
        {
            connection = new NpgsqlConnection(connectionString);
        }

        public Boolean TestConnect()
        {
            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public Boolean Disconnect()
        {
            try
            {
                this.connection.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public DataSet QueryData(string query)
        {
            if (!this.Connected)
            {
                throw new Exception("Database not connected.");
            }

            DataSet result = new DataSet();
            try
            {
                using (var da = new NpgsqlDataAdapter(query, this.connection))
                {
                    da.Fill(result, "result");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;
        }

        public void ExecuteCommand(string query)
        {
            if (!this.Connected)
            {
                throw new Exception("Database not connected.");
            }

            try
            {
                using (var cmd = new NpgsqlCommand(query, this.connection))
                {
                    int rowsAffected = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean DatabaseExists(string databaseName)
        {
            if (!this.Connected)
            {
                throw new Exception("Database not connected.");
            }

            string __queryCheckDatabase = "select datname from pg_database where datname = @databasename";

            try
            {
                using (var command = new NpgsqlCommand(__queryCheckDatabase, this.connection))
                {
                    command.Parameters.Add("@databasename", NpgsqlTypes.NpgsqlDbType.Text).Value = databaseName;

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            if (reader.Read())
                            {
                                string datName = reader["datname"].ToString();

                                if (datName == databaseName)
                                {
                                    return true;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return false;
        }

        public Boolean CreateDatabase(string databaesName)
        {
            if (!this.Connected)
            {
                throw new Exception("Database not connected.");
            }

            string databaseNameLower = databaesName.ToLower();
            if (this.DatabaseExists(databaseNameLower))
            {
                throw new Exception("Database already exists.");
            }

            string __queryCreateDatabase = "CREATE DATABASE " + databaseNameLower + " ;";
            try
            {
                using (var command = new NpgsqlCommand(__queryCreateDatabase, this.connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

     public TransactionConnection CreateTransactionConnection()
        {
            if (!this.Connected)
            {
                throw new Exception("Database not connected.");
            }

            return new TransactionConnection(this.connection);
        }

    }
}
