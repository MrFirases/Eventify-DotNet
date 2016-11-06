using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Eventify.Web.Startup))]
namespace Eventify.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
