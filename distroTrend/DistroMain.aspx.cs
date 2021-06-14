using distroTrend.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace distroTrend
{
    public partial class DistroMain
        : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Trace("Inside " + this.GetType().Name + ".Page_Load()");
            int distroId = 0;
            Distro distro = null;

            string connString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            if (Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_ID] != null)
                distroId = Convert.ToInt32(Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_ID].ToString());

            logger.Debug("Parameter distroId=" + distroId);

            BLL.Distro objDistro = new BLL.Distro();

            if (distroId > 0)
                distro = objDistro.GetDistro(connString).Where(x => x.Id == distroId).SingleOrDefault();

            if (distro != null)
            {
                lblName.Text = distro.Name;
                lblDescription.Text = distro.Description;
                if (!string.IsNullOrEmpty(distro.ImageURL))
                    //imgLogo.ImageUrl = "https://distrowatch.com/" + distro.ImageURL;
                    imgLogo.ImageUrl = distro.ImageURL;

                if (!string.IsNullOrWhiteSpace(distro.HomePage))
                {
                    hlUrl.Text = "Click here to visit the website";
                    hlUrl.NavigateUrl = distro.HomePage;
                }
                else
                    hlUrl.Text = "Not set";
            }

            if (distroId > 0)
            {
                List<distroTrend.Model.Edition> editions = GetEditions(distroId);
                if (editions.Count > 0)
                {
                    lvEditions.DataSource = editions;
                    lvEditions.DataBind();
                }

                List<distroTrend.Model.Version> versions = GetVersions(distroId);

                if (versions.Count > 0)
                {
                    lvRelease.DataSource = versions;
                    lvRelease.DataBind();
                }
            }
        }

        private List<distroTrend.Model.Edition> GetEditions(int distroId)
        {
            BLL.Edition objEdition = new BLL.Edition();
            List<distroTrend.Model.Edition> editions = objEdition.GetEditions(distroId).ToList();
            return editions;
        }
        private List<distroTrend.Model.Version> GetVersions(int distroId)
        {
            BLL.Version objVersion = new BLL.Version();
            List<distroTrend.Model.Version> versions = objVersion.GetVersions(distroId).ToList();
            return versions;
        }
    }
}