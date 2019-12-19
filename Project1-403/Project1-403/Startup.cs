using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Project1_403.Startup))]
namespace Project1_403
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
