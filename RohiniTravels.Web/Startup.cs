using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RohiniTravels.Web.Startup))]
namespace RohiniTravels.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
