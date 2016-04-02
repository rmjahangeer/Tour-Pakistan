using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace tourPakistan
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters, IUnityContainer container)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
