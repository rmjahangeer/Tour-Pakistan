using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using TP.Implementation.Identity;
using TP.Implementation.Services;
using TP.Interfaces.IServices;
using TP.Models.IdentityModels;

namespace TP.Implementation
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            UnityConfig.UnityContainer = unityContainer;
            TP.Repository.TypeRegistrations.RegisterType(unityContainer);
            unityContainer.RegisterType<IAspNetUserService, AspNetUserService>();
            unityContainer.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            unityContainer.RegisterType<IDashboardService, DashboardService>();
            unityContainer.RegisterType<ILogger, LoggerService>();
            unityContainer.RegisterType<IProvinceService, ProvinceService>();
            unityContainer.RegisterType<ICateogryService, CategoryService>();
        }
    }
}
