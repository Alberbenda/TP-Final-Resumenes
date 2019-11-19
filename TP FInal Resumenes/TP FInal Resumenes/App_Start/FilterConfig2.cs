using System.Web;
using System.Web.Mvc;

namespace TP_FInal_Resumenes
{
    public class FilterConfig2
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
