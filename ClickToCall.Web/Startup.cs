using System.Net;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClickToCall.Web.Startup))]
namespace ClickToCall.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            // Enable TLS v1.2 for Twilio API calls
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
        }
    }
}
