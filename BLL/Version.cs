using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class Version
    {
        public List<distroTrend.Model.Version> GetVersions(string connString, int distroId)
        {
            DAL.Version objVersion = new DAL.Version();

            DataSet ds = objVersion.GetVersion(connString);

            var versionList = ds.Tables[0].AsEnumerable()
                .Where(x => x.Field<int>("DistroEditionId") == distroId)
                .Select(dataRow => new distroTrend.Model.Version
                {
                    DistroEditionId = dataRow.Field<int>("DistroEditionId"),
                    Name = dataRow.Field<string>("Name")
                })
                .ToList();

            return versionList;
        }
    }
}
