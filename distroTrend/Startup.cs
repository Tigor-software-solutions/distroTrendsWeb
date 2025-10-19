using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Owin;

[assembly: OwinStartup(typeof(distroTrend.Startup))]

namespace distroTrend
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Login.aspx")
            });

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "551968508102-soavh9v8kv30nk3p0cbdr656k7mgrohp.apps.googleusercontent.com",
                ClientSecret = System.Configuration.ConfigurationManager.AppSettings["ClientSecret_Google"],
                CallbackPath = new PathString("/signin-google")
            });
        }
    }
}