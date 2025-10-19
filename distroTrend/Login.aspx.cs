using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Google;
using System;
using System.Web;

namespace distroTrend
{
    public partial class Loign : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GoogleLoginButton_Click(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
            {
                RedirectUri = "/Default.aspx"
            }, "Google");
        }
    }
}