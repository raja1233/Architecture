using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(architecture.Web.Startup))]
namespace architecture.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
