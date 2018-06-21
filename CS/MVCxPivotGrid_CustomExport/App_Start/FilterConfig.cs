using System.Web;
using System.Web.Mvc;

namespace MVCxPivotGrid_CustomExport {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}