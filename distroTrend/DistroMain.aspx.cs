using distroTrend.Model;
using NLog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;

namespace distroTrend
{
    public partial class DistroMain
        : System.Web.UI.Page
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        string _connString = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            logger.Trace("Inside " + this.GetType().Name + ".Page_Load()");
            int distroId = 0;
            Distro distro = null;

            _connString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;

            if (!IsPostBack) // Ensures dropdown is only populated once
            {
                PopulateDropdown();  // Populate the dropdown with distro data
                SelectDistroFromQueryString(); // Select the appropriate distro
            }

            if (Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_ID] != null)
                distroId = Convert.ToInt32(Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_ID].ToString());

            logger.Debug("Parameter distroId=" + distroId);

            BLL.Distro objDistro = new BLL.Distro();

            if (distroId > 0)
                distro = objDistro.GetDistro(_connString).Where(x => x.Id == distroId).SingleOrDefault();

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

        private void PopulateDropdown()
        {
            BLL.Distro objDistro = new BLL.Distro();
            List<Distro> distroList = objDistro.GetDistro(_connString).ToList();

            if (distroList.Count > 0)
            {
                ddlDistro.DataSource = distroList;
                ddlDistro.DataTextField = "Name";
                ddlDistro.DataValueField = "Id";
                ddlDistro.DataBind();
            }

            // Add a default selection if no query string exists
             ddlDistro.Items.Insert(0, new ListItem("-- Select a Distro --", "0"));
        }

        private void SelectDistroFromQueryString()
        {
            int distroId = 0;

            if (Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_ID] != null)
            {
                // Get the distro ID from query string
                distroId = Convert.ToInt32(Request.QueryString[Helper.Constants.URL_PARAMETER_DISTRO_ID]);
                ListItem selectedItem = ddlDistro.Items.FindByValue(distroId.ToString());

                if (selectedItem != null)
                {
                    ddlDistro.SelectedValue = distroId.ToString();
                }
            }
            else if (ddlDistro.Items.Count > 1)
            {
                // If no query string, select the first available distro
                ddlDistro.SelectedIndex = 1;
                distroId = Convert.ToInt32(ddlDistro.SelectedValue);
            }

            if (distroId > 0)
            {
                LoadDistroData(distroId);
            }
        }

        protected void ddlDistro_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedDistroId = Convert.ToInt32(ddlDistro.SelectedValue);
            if (selectedDistroId > 0)
            {
                LoadDistroData(selectedDistroId);
                LoadRatings(selectedDistroId);
            }
        }

        private void LoadDistroData(int distroId)
        {
            logger.Debug("Loading data for distroId=" + distroId);
            BLL.Distro objDistro = new BLL.Distro();
            Distro distro = objDistro.GetDistro(_connString).Where(x => x.Id == distroId).SingleOrDefault();

            if (distro != null)
            {
                lblName.Text = distro.Name;
                lblDescription.Text = distro.Description;
                imgLogo.ImageUrl = !string.IsNullOrEmpty(distro.ImageURL) ? distro.ImageURL : "";

                hlUrl.Text = !string.IsNullOrWhiteSpace(distro.HomePage) ? "Click here to visit the website" : "Not set";
                hlUrl.NavigateUrl = !string.IsNullOrWhiteSpace(distro.HomePage) ? distro.HomePage : "#";

                // Load Editions & Versions
                lvEditions.DataSource = GetEditions(distroId);
                lvEditions.DataBind();

                lvRelease.DataSource = GetVersions(distroId);
                lvRelease.DataBind();
            }
        }

        private void LoadRatings(int distroId)
        {
            //Load Ratings
            BLL.Rating objRating = new BLL.Rating();
            List<distroTrend.Model.Version> versions = GetVersions(distroId);
            int distroVersionLatest = versions.OrderByDescending(x => x.ReleaseDate).Select(x => x.DistroEditionId).FirstOrDefault();
            List<Rating> listRating = objRating.GetRatings(_connString, distroVersionLatest);

            int ratingUsability = 0;
            int ratingStability = 0;

            if (listRating.Count > 0)
            {
                int.TryParse(listRating[0].RatingUsability.ToString(), out ratingUsability);
                int.TryParse(listRating[0].RatingStability.ToString(), out ratingStability);
            }

            RatingUsability.CurrentRating = ratingUsability;

            if (ratingUsability > 0)
                lblRatingUsability.Text = "Your rating: " + ratingUsability;

            RatingStability.CurrentRating = ratingStability;

            if (ratingStability > 0)
                lblRatingStability.Text = "Your rating: " + ratingStability;
        }
        private List<distroTrend.Model.Edition> GetEditions(int distroId)
        {
            BLL.Edition objEdition = new BLL.Edition();
            List<distroTrend.Model.Edition> editions = objEdition.GetEditions(_connString, distroId).ToList();
            return editions;
        }
        private List<distroTrend.Model.Version> GetVersions(int distroId)
        {
            BLL.Version objVersion = new BLL.Version();
            List<distroTrend.Model.Version> versions = objVersion.GetVersions(_connString, distroId).ToList();
            return versions;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            SetControls("edit");
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            SetControls();

            bool hasUpdate = false;
            
            BLL.Distro objDistro = new BLL.Distro();
            int distroId = Convert.ToInt32(ddlDistro.SelectedItem.Value);
            _connString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            Distro distro = objDistro.GetDistro(_connString).Where(x => x.Id == distroId).SingleOrDefault();

            if (distro.Description != txtDescription.Text)
            {
                distro.Description = txtDescription.Text;
                hasUpdate = true;
            }

            if (distro.HomePage != txtUrl.Text)
            {
                distro.HomePage = txtUrl.Text;
                hasUpdate = true;
            }

            if(hasUpdate)
                objDistro.Update(_connString, distroId, distro);

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {            
            SetControls();
        }

        private void SetControls(string mode="default")
        {
            btnEdit.Visible = true;
            btnUpdate.Visible = false;
            btnCancel.Visible = false;

            txtDescription.Visible = false;
            lblDescription.Visible = true;

            txtUrl.Visible = false;
            hlUrl.Visible = true;

            if (mode != "default")
            {
                btnEdit.Visible = false;
                btnUpdate.Visible = true;
                btnCancel.Visible = true;

                txtDescription.Visible = true;
                lblDescription.Visible = false;
                txtDescription.Text = lblDescription.Text;
            
                txtUrl.Visible = true;
                hlUrl.Visible = false;
                txtUrl.Text = hlUrl.NavigateUrl;
            }
        }

        protected void btnRating_Click(object sender, EventArgs e)
        {
            int distroId = Convert.ToInt32(ddlDistro.SelectedItem.Value);
            _connString = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            
            BLL.Rating objRating = new BLL.Rating();
            int userId = 1;
            int ratingUsability = RatingUsability.CurrentRating;
            int ratingStability = RatingStability.CurrentRating;

            List<distroTrend.Model.Version> versions = GetVersions(distroId);
            int distroVersionLatest = versions.OrderByDescending(x => x.ReleaseDate).Select(x => x.DistroEditionId).FirstOrDefault();
            List<Rating> listRating = objRating.GetRatings(_connString, distroVersionLatest);

            int distroEditionId = distroVersionLatest;

            if (listRating.Count > 0)
                objRating.Update(_connString, distroEditionId, userId, ratingUsability, ratingStability);
            else
                objRating.Insert(_connString, distroEditionId, userId, ratingUsability);            
        }
    }
}