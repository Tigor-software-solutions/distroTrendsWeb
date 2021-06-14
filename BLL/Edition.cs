using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class Edition
    {
        public List<distroTrend.Model.Edition> GetEditions(string connString, int distroId)
        {
            DAL.Edition objEdition = new DAL.Edition();

            DataSet ds = objEdition.GetEdition(connString, distroId);

            var editionList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Edition
                {
                    Id = dataRow.Field<int>("Id"),
                    Name = dataRow.Field<string>("Name")
                }).ToList();

            return editionList;
        }
    }
}
