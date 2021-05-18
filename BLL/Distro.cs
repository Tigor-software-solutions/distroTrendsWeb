using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class Distro
    {
        public DataSet GetDistroAsDataSet()
        {
            DAL.Distro objDistro = new DAL.Distro();

            return objDistro.GetDistro();
        }
        public List<distroTrend.Model.Distro> GetDistro()
        {
            DAL.Distro objDistro = new DAL.Distro();

            DataSet ds = objDistro.GetDistro();

            var distroList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Distro
                {
                    Id = dataRow.Field<int>("Id"),
                    Code = dataRow.Field<string>("Code"),
                    Name = dataRow.Field<string>("Name"),
                    Description = dataRow.Field<string>("Description"),
                    HomePage= dataRow.Field<string>("HomePage")
                }).ToList();

            return distroList;
        }
    }
}
