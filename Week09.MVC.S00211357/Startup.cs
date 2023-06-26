using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week09.MVC.S00211357.Startup))]
namespace Week09.MVC.S00211357
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
