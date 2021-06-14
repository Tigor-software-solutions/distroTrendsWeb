using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DAL
{
    public class Points
    {
        public DataSet GetPoints()
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM tbl_Points";
            return conn.GetData(query);
        }
        public distroTrend.Model.Points Select(string connString, distroTrend.Model.Points points)
        {
            DBConn conn = new DBConn();
            String query = "SELECT * FROM [dbo].[tbl_Points] WHERE distroId = @distroId and Date = @Date";

            distroTrend.Model.Points objPoints = new distroTrend.Model.Points();

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@distroId", SqlDbType = SqlDbType.Int, Value= points.distroId},
                new SqlParameter() {ParameterName = "@Date", SqlDbType = SqlDbType.Decimal, Value= points.Date}
            };

            DataSet ds = conn.GetData(connString, query);

            objPoints = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Points
                {
                    distroId = dataRow.Field<int>("distroId"),
                    Date = dataRow.Field<DateTime>("Date"),
                    TotalPoints = dataRow.Field<decimal>("TotalPoints")

                }).FirstOrDefault();

            return objPoints;
        }
        public int Insert(string connString, distroTrend.Model.Points points)
        {
            DBConn conn = new DBConn();
            String query = "INSERT INTO [dbo].[tbl_Points] ([distroId],[DistroWatchPoints]) VALUES (@distroId,@DistroWatchPoints)";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@distroId", SqlDbType = SqlDbType.Int, Value= points.distroId},
                new SqlParameter() {ParameterName = "@DistroWatchPoints", SqlDbType = SqlDbType.Decimal, Value= points.DistroWatchPoints}
            };

            return conn.InsertData(connString, query, sp);
        }
        public int Update(string connString, distroTrend.Model.Points points)
        {
            DBConn conn = new DBConn();
            String query = "UPDATE [dbo].[tbl_Points] SET [DistroWatchPoints] = @DistroWatchPoints WHERE distroId = @distroId";

            List<SqlParameter> sp = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@distroId", SqlDbType = SqlDbType.Int, Value= points.distroId},
                new SqlParameter() {ParameterName = "@DistroWatchPoints", SqlDbType = SqlDbType.Decimal, Value= points.DistroWatchPoints}
            };

            return conn.UpdateData(connString, query, sp);
        }
    }
}
