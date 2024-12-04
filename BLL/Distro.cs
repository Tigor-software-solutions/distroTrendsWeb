using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BLL
{
    public class Distro
    {
        public DataSet GetDistroAsDataSet(string connString)
        {
            DAL.Distro objDistro = new DAL.Distro();

            return objDistro.GetDistro(connString);
        }
        public List<distroTrend.Model.Distro> GetDistro(string connString)
        {
            DAL.Distro objDistro = new DAL.Distro();

            DataSet ds = objDistro.GetDistro(connString);

            var distroList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Distro
                {
                    Id = dataRow.Field<int>("Id"),
                    Code = dataRow.Field<string>("Code"),
                    Name = dataRow.Field<string>("Name"),
                    Description = dataRow.Field<string>("Description"),
                    HomePage = dataRow.Field<string>("HomePage"),
                    ImageURL = dataRow.Field<string>("ImageURL")
                }).ToList();

            return distroList;
        }

        public distroTrend.Model.Distro GetDistro(string connString, string code)
        {
            DAL.Distro objDistro = new DAL.Distro();

            DataSet ds = objDistro.GetDistro(connString, code);

            var distroList = ds.Tables[0].AsEnumerable()
                .Select(dataRow => new distroTrend.Model.Distro
                {
                    Id = dataRow.Field<int>("Id"),
                    Code = dataRow.Field<string>("Code"),
                    Name = dataRow.Field<string>("Name"),
                    Description = dataRow.Field<string>("Description"),
                    HomePage = dataRow.Field<string>("HomePage"),
                    ImageURL = dataRow.Field<string>("ImageURL")
                }).FirstOrDefault();

            return distroList;
        }

        public int Update(string connString, int id, string description)
        {
            DAL.Distro objDistro = new DAL.Distro();

            return objDistro.Update(connString, id, description);
        }

        public int Update(string connString, int id, distroTrend.Model.Distro distro)
        {
            DAL.Distro objDistro = new DAL.Distro();

            return objDistro.Update(connString, id, distro);
        }
        public int Insert(string connString, distroTrend.Model.Distro distro)
        {
            DAL.Distro objDistro = new DAL.Distro();

            return objDistro.Insert(connString, code: distro.Code, name: distro.Name, description: distro.Description, imageURL: distro.ImageURL, homePage: distro.HomePage);
        }
    }
}
