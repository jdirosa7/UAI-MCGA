using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MCGA_Safari.UI.Web.Startup))]
namespace MCGA_Safari.UI.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
