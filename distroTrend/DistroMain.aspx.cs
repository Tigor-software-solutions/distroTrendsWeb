using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using distroTrend.Model;

namespace distroTrend
{
    public partial class DistroMain
        : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string distroCode = Convert.ToString(Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_CODE]);

            Distro distro = GetDistros().Where(x => x.Code == distroCode).SingleOrDefault();

            if (distro != null)
            {
                lblName.Text = distro.Name;
                lblDescription.Text = distro.Description;
            }
        }

        private List<Distro> GetDistros()
        {
            List<Distro> listDistro = new List<Distro>();

            Distro objDistro = new Distro
            {
                Code = "UBT",
                Name = "Ubuntu"
            };
            listDistro.Add(objDistro);

            objDistro = new Distro
            {
                Code = "Mint",
                Name = "LinuxMint"
            };
            listDistro.Add(objDistro);

            return listDistro;
        }
    }
}