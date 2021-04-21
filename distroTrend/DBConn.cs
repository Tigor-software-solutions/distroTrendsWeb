using System;
using System.Data;
using System.Data.SqlClient;

namespace distroTrend
{
    public class DBConn
    {
        public DataSet GetData(string query)
        {
            string connectionString;
            SqlConnection sqlConn;
            SqlDataAdapter adapter;
            DataSet ds = new DataSet();

            connectionString = @"workstation id=distroTrends.mssql.somee.com;packet size=4096;user id=tigor_SQLLogin_1;pwd=o4yf9wokqh;data source=distroTrends.mssql.somee.com;persist security info=False;initial catalog=distroTrends";

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
    }
}