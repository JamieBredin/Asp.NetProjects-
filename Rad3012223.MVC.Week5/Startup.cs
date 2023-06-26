using Microsoft.Owin;
using Owin;
using Tracker.WebAPIClient;

[assembly: OwinStartupAttribute(typeof(Rad3012223.MVC.Week5.Startup))]
namespace Rad3012223.MVC.Week5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301 Week6 Lab 2022", Task: "Week 6 Starting Posting Approval");
            ConfigureAuth(app);
        }
    }
}
