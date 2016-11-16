using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Logging;
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

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    //Add Cors support to the service
        //    services.AddCors(options => options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()));

        //}



    }
}
