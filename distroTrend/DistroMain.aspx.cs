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

            //Distro distro = GetDistros().Where(x => x.Code == distroCode).SingleOrDefault();
            BLL.Distro objDistro = new BLL.Distro();
            Distro distro = objDistro.GetDistro().Where(x => x.Code.Trim() == distroCode).SingleOrDefault();

            if (distro != null)
            {
                lblName.Text = distro.Name;
                lblDescription.Text = distro.Description;
                hlUrl.Text = "Click here to visit the website";
                hlUrl.NavigateUrl = distro.HomePage;
            }
        }
    }
}