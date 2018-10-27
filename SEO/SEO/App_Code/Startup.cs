using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEO.Startup))]
namespace SEO
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
