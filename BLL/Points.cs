using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class Points
    {
        public List<distroTrend.Model.Points> GetPoints()
        {
            DAL.Points objVersion = new DAL.Points();

            DataSet ds = objVersion.GetPoints();

            var pointsList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Points
                {
                    distroId = dataRow.Field<int>("distroId"),
                    Date = dataRow.Field<DateTime>("Date"),
                    TotalPoints = dataRow.Field<decimal>("TotalPoints")

                }).ToList();

            return pointsList;
        }

        public distroTrend.Model.Points GetPoints(string connString, int distroId, DateTime date)
        {
            DAL.Points objPoints = new DAL.Points();

            distroTrend.Model.Points points = new distroTrend.Model.Points()
            {
                distroId = distroId,
                Date = date
            };

            distroTrend.Model.Points pointsDb = objPoints.Select(connString, points);

            return pointsDb;
        }
        public int Insert(string connString, distroTrend.Model.Points points)
        {
            DAL.Points objVersion = new DAL.Points();

            return objVersion.Insert(connString, points);
        }
        public int Update(string connString, distroTrend.Model.Points points)
        {
            DAL.Points objVersion = new DAL.Points();

            return objVersion.Update(connString, points);
        }
    }
}
