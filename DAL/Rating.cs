using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class Rating
    {
        public DataSet GetRatings(string connString, int distroEditionId)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Rating WHERE distroEditionId = '" + distroEditionId + "'";
            return conn.GetData(connString, query);
        }

        public int Insert(string connString, int distroEditionId, int userId, float usability)
        {
            DBConn conn = new DBConn();
            String query = "INSERT INTO [dbo].[tbl_Rating] ([DistroEditionId],[UserId],[Usability]) Values (@DistroEditionId, @UserId, @Usability)";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@DistroEditionId", SqlDbType = SqlDbType.Int, Value= distroEditionId},
                new SqlParameter() {ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value= userId},
                new SqlParameter() {ParameterName = "@Usability", SqlDbType = SqlDbType.Decimal, Value= usability}
            };

            return conn.InsertData(connString, query, sp);
        }

        public int Update(string connString, int distroEditionId, int userId, float ratingUsability, float ratingStability)
        {
            DBConn conn = new DBConn();
            String query = "UPDATE [dbo].[tbl_Rating] SET [Usability] = @Usability, [Stability] = @Stability WHERE distroEditionId = @distroEditionId and userId= @userId";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@Usability", SqlDbType = SqlDbType.Decimal, Value= ratingUsability },
                new SqlParameter() {ParameterName = "@Stability", SqlDbType = SqlDbType.Decimal, Value= ratingStability },
                new SqlParameter() {ParameterName = "@DistroEditionId", SqlDbType = SqlDbType.Int, Value= distroEditionId},
                new SqlParameter() {ParameterName = "@UserId", SqlDbType = SqlDbType.Int, Value= userId}
            };

            return conn.UpdateData(connString, query, sp);
        }

    }
}
