using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FitnessMVC.Startup))]
namespace FitnessMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
