using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Citadel_Lib.Startup))]
namespace Citadel_Lib
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
