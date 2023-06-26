using System.Web;
using System.Web.Mvc;

namespace Rad3012223.MVC.Week5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
