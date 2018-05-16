using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(architecture.Startup))]
namespace architecture
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
