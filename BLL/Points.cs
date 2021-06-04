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
    }
}
