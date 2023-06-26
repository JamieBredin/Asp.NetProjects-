using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tracker.WebAPIClient;

namespace Week82022.MVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ActivityAPIClient.Track(StudentID: "S00211357", StudentName: "Jamie Bredin", activityName: "RAD301 Week 8 Lab 2223", Task: "Creating Customized Views ");
        }
    }
}
