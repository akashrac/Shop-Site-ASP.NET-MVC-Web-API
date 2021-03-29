using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCNET.Startup))]
namespace MVCNET
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
