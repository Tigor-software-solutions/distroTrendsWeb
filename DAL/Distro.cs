using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Distro
    {
        public DataSet GetDistro()
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Distro";
            return conn.GetData(query);
        }
        public DataSet GetDistro(string sqlConn)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Distro";
            return conn.GetData(query, sqlConn);
        }

        public DataSet GetDistro(string code, string sqlConn)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Distro WHERE Code = '"+ code + "'";
            return conn.GetData(query, sqlConn);
        }

        public int Insert(string sqlConn, string code, string name, string description, string homePage)
        {
            DBConn conn = new DBConn();
            String query = "INSERT INTO [dbo].[tbl_Distro] ([Code],[Name],[Description],[HomePage]) Values (@Code, @Name, @Description, @HomePage)";
           
            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Code", SqlDbType = SqlDbType.NVarChar, Value= code},
                new SqlParameter() {ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value= name},
                new SqlParameter() {ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value= description},
                new SqlParameter() {ParameterName = "@HomePage", SqlDbType = SqlDbType.NVarChar, Value= homePage}
            };

            return conn.InsertData(sqlConn, query, sp);
        }

        public int Update(string connectionString, int id, string description)
        {
            DBConn conn = new DBConn();
            String query = "UPDATE [dbo].[tbl_Distro] SET [Description] = @Description WHERE Id = @Id";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value= id},
                new SqlParameter() {ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value= description}
            };

            return conn.UpdateData(connectionString, query, sp);
        }

        public int Update(string connectionString, int id, distroTrend.Model.Distro distro)
        {
            DBConn conn = new DBConn();
            String query = "UPDATE [dbo].[tbl_Distro] SET [Description] = @Description, ImageURL = @ImageURL WHERE Id = @Id";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value= id},
                new SqlParameter() {ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value= distro.Description},
                new SqlParameter() {ParameterName = "@ImageURL", SqlDbType = SqlDbType.NVarChar, Value= distro.ImageURL}
            };

            return conn.UpdateData(connectionString, query, sp);
        }
    }
}
