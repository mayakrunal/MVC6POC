using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IdentityPOC.Startup))]
namespace IdentityPOC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
