using System.Web;
using System.Web.Mvc;

namespace LuisMiguelBR.Unidad4.Practica1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
