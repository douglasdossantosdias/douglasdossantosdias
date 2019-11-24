using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Gerobra.Startup))]
namespace Gerobra
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
