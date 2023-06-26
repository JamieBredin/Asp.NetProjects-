using System.Web;
using System.Web.Mvc;

namespace Week09.MVC.S00211357
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
