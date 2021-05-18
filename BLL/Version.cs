using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class Version
    {
        public List<distroTrend.Model.Version> GetVersions(int distroId)
        {
            DAL.Version objVersion = new DAL.Version();

            DataSet ds = objVersion.GetVersion();

            var versionList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Version
                {
                    Name = dataRow.Field<string>("Name")

                }).ToList();

            return versionList;
        }
    }
}
