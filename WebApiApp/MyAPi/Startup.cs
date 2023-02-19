using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using System.Security.Claims;
using Microsoft.Owin.Security.OAuth;


[assembly: OwinStartup(typeof(MyAPi.Startup))]

namespace MyAPi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            ConfigureOAuth(app);

            WebApiConfig.Register(config);
            app.UseWebApi(config);

        }

        public void ConfigureOAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions serverOptions = new OAuthAuthorizationServerOptions();

            serverOptions.TokenEndpointPath = new Microsoft.Owin.PathString("/token");
            serverOptions.AccessTokenExpireTimeSpan = TimeSpan.FromDays(1);
            serverOptions.AllowInsecureHttp = true;
            serverOptions.Provider = new SimpleAuthorizationServerProvider();

            app.UseOAuthAuthorizationServer(serverOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
