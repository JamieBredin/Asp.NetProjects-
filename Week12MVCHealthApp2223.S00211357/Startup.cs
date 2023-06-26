using Microsoft.Owin;
using Owin;
using Tracker.WebAPIClient;

[assembly: OwinStartupAttribute(typeof(Week12MVCHealthApp2223.S00211357.Startup))]
namespace Week12MVCHealthApp2223.S00211357
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "Rad301 2223 Week 12Lab", Task: "Implementing Doctor Patient Controller");
            ConfigureAuth(app);
        }
    }
}
