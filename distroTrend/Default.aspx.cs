using System;
using System.Web.UI;

namespace distroTrend
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Context.User.Identity.IsAuthenticated)
            {
                var name = Context.User.Identity.Name;
                Response.Write("Hello, " + name);
            }
            else
            {
                //Response.Redirect("~/Login.aspx");
            }
        }
    }
}