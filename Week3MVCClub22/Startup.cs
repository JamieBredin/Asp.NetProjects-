using Microsoft.Owin;
using Owin;
using Tracker.WebAPIClient;

[assembly: OwinStartupAttribute(typeof(Week3MVCClub22.Startup))]
namespace Week3MVCClub22
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ActivityAPIClient.Track(StudentID: "S00211357",
                StudentName: "Jamie Bredin",
                activityName: "Rad301 22 Week 3 Lab 1",
                Task: "Finshed Lab");

            ConfigureAuth(app);
        }
    }
}
