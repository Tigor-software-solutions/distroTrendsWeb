using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using NLog;
using Owin;

[assembly: OwinStartup(typeof(distroTrend.Startup))]

namespace distroTrend
{
    public class Startup
    {
        static Logger logger = LogManager.GetCurrentClassLogger();
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Login.aspx")
            });

            app.SetDefaultSignInAsAuthenticationType(CookieAuthenticationDefaults.AuthenticationType);

            string clientSecret = System.Configuration.ConfigurationManager.AppSettings[Helper.Constants.AP_SETTINGS_CLIENT_SECRET_GOOGLE];

            if (clientSecret == "SetGoogleClientSecret")
                logger.Warn("Google Client Secret is NOT set. Google SSO won't work!");

            app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            {
                ClientId = "551968508102-soavh9v8kv30nk3p0cbdr656k7mgrohp.apps.googleusercontent.com",
                ClientSecret = clientSecret,
                CallbackPath = new PathString("/signin-google")
            });
        }
    }
}