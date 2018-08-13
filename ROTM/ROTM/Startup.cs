using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ROTM.Startup))]
namespace ROTM
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
