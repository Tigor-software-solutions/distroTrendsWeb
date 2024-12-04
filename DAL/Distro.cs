using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Distro
    {
        //public DataSet GetDistro()
        //{
        //    DBConn conn = new DBConn();
        //    String query = "SELECT * FROM tbl_Distro";
        //    return conn.GetData(query);
        //}
        public DataSet GetDistro(string connString)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Distro";
            return conn.GetData(connString, query);
        }

        public DataSet GetDistro(string connString, string code)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Distro WHERE Code = '" + code + "'";
            return conn.GetData(connString, query);
        }

        public int Insert(string connString, string code, string name, string description, string imageURL, string homePage)
        {
            DBConn conn = new DBConn();
            String query = "INSERT INTO [dbo].[tbl_Distro] ([Code],[Name],[Description],[ImageURL],[HomePage]) Values (@Code, @Name, @Description, @ImageURL, @HomePage)";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Code", SqlDbType = SqlDbType.NVarChar, Value= code},
                new SqlParameter() {ParameterName = "@Name", SqlDbType = SqlDbType.NVarChar, Value= name},
                new SqlParameter() {ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value= description ?? (object)DBNull.Value},
                new SqlParameter() {ParameterName = "@ImageURL", SqlDbType = SqlDbType.NVarChar, Value= imageURL ?? (object)DBNull.Value },
                new SqlParameter() {ParameterName = "@HomePage", SqlDbType = SqlDbType.NVarChar, Value= homePage ?? (object)DBNull.Value }
            };

            return conn.InsertData(connString, query, sp);
        }

        public int Update(string connString, int id, string description)
        {
            DBConn conn = new DBConn();
            String query = "UPDATE [dbo].[tbl_Distro] SET [Description] = @Description WHERE Id = @Id";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value= id},
                new SqlParameter() {ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value= description}
            };

            return conn.UpdateData(connString, query, sp);
        }

        public int Update(string connString, int id, distroTrend.Model.Distro distro)
        {
            DBConn conn = new DBConn();
            String query = "UPDATE [dbo].[tbl_Distro] SET [Description] = IsNull(@Description, [Description]), ImageURL = IsNull(@ImageURL, ImageURL) WHERE Id = @Id";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Id", SqlDbType = SqlDbType.Int, Value= id},
                new SqlParameter() {ParameterName = "@Description", SqlDbType = SqlDbType.NVarChar, Value= distro.Description},
                new SqlParameter() {ParameterName = "@ImageURL", SqlDbType = SqlDbType.NVarChar, Value= distro.ImageURL}
            };

            return conn.UpdateData(connString, query, sp);
        }
    }
}
