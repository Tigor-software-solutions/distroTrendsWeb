using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DBConn
    {
        public DataSet GetData(string query, string connString = null)
        {
            string connectionString = null;
            SqlConnection sqlConn;
            SqlDataAdapter adapter;
            DataSet ds = new DataSet();

            connectionString = connString;
            
            if (connectionString == null)
                connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            sqlConn = new SqlConnection(connectionString);

            try
            {
                sqlConn.Open();

                adapter = new SqlDataAdapter(query, connectionString);
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqlConn.Close();
            }

            return ds;
        }

        public int InsertData(string connString, string query, List<SqlParameter> sp)
        {
            SqlConnection sqlConn;
            SqlCommand command;
            int result = 0;

            sqlConn = new SqlConnection(connString);

            command = new SqlCommand(query, sqlConn);

            if (sp != null)
                command.Parameters.AddRange(sp.ToArray());

            try
            {
                sqlConn.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }

            return result;
        }

        public int UpdateData(string connString, string query, List<SqlParameter> sp)
        {
            SqlConnection sqlConn;
            SqlCommand command;
            int result = 0;

            //connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            sqlConn = new SqlConnection(connString);

            command = new SqlCommand(query, sqlConn);

            if (sp != null)
            {
                //command.Parameters.AddRange(sp.ToArray());

                foreach(SqlParameter param in sp)
                {
                    if (param.Value != null)
                        command.Parameters.Add(param);
                    else
                        command.Parameters.AddWithValue(param.ParameterName, DBNull.Value);
                }
            }

            try
            {
                sqlConn.Open();
                result = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                sqlConn.Close();
            }

            return result;
        }
    }
}
