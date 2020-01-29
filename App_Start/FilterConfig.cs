using System.Web;
using System.Web.Mvc;

namespace Caliburn
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //Following line will cause the entire application to redirect to an error page upon exception.
            filters.Add(new HandleErrorAttribute());
            filters.Add(new AuthorizeAttribute());
        }
    }
}
