using System.Web;
using System.Web.Mvc;
using ExhibitGrid.Filters;

namespace ExhibitGrid
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new AuthFilter());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
