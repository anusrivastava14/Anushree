using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Anushree.Startup))]
namespace Anushree
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
