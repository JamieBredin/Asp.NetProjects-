using Microsoft.Owin;
using Owin;
using Tracker.WebAPIClient;

[assembly: OwinStartupAttribute(typeof(RAD3012223Week4.MVClub.Startup))]
namespace RAD3012223Week4.MVClub
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ActivityAPIClient.Track(StudentID: "S00211357",
               StudentName: "Jamie Bredin",
               activityName: "Rad301 2223 Week 4 Lab 1",
               Task: "Testing Authorised Controller");

            ConfigureAuth(app);


        }
    }
}
