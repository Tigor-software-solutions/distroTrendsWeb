using distroTrend.Model;
using System;
using System.Data;
using System.Linq;

namespace distroTrend
{
    public partial class DistroMain
        : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string distroCode = Convert.ToString(Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_CODE]);

            BLL.Distro objDistro = new BLL.Distro();
            Distro distro = objDistro.GetDistro().Where(x => x.Code.Trim() == distroCode).SingleOrDefault();

            if (distro != null)
            {
                lblName.Text = distro.Name;
                lblDescription.Text = distro.Description;

                if (!string.IsNullOrWhiteSpace(distro.HomePage))
                {
                    hlUrl.Text = "Click here to visit the website";
                    hlUrl.NavigateUrl = distro.HomePage;
                }
                else
                    hlUrl.Text = "Not set";
            }
        }
    }
}