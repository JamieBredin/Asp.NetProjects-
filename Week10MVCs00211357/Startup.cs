using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Week10MVCs00211357.Startup))]
namespace Week10MVCs00211357
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
