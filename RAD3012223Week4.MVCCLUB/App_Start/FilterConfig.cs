using System.Web;
using System.Web.Mvc;

namespace RAD3012223Week4.MVCCLUB
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
