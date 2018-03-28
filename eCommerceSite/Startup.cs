using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eCommerceSite.Startup))]
namespace eCommerceSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
