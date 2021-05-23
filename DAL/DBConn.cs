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
            //connectionString = @"workstation id=distroTrends.mssql.somee.com;packet size=4096;user id=tigor_SQLLogin_1;pwd=o4yf9wokqh;data source=distroTrends.mssql.somee.com;persist security info=False;initial catalog=distroTrends";
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

        public int InsertData(string query, List<SqlParameter> sp)
        {
            string connectionString;
            SqlConnection sqlConn;
            SqlCommand command;
            int result = 0;

            connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            sqlConn = new SqlConnection(connectionString);

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

        public int UpdateData(string connectionString, string query, List<SqlParameter> sp)
        {
            SqlConnection sqlConn;
            SqlCommand command;
            int result = 0;

            //connectionString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            sqlConn = new SqlConnection(connectionString);

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
    }
}
