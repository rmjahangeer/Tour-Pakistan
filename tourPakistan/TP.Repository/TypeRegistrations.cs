using System.Data.Entity;
using Microsoft.Practices.Unity;
using TP.Interfaces.IRepository;
using TP.Repository.BaseRepository;
using TP.Repository.Repositories;

namespace TP.Repository
{
    public static class TypeRegistrations
    {
        public static void RegisterType(IUnityContainer unityContainer)
        {
            
            unityContainer.RegisterType<IAspNetUserRepository, AspNetUserRepository>();
            unityContainer.RegisterType<DbContext, BaseDbContext>(new PerRequestLifetimeManager());
            unityContainer.RegisterType<IProvinceRepository, ProvinceRepository>();
            unityContainer.RegisterType<ICategoryRepository, CategoryRepository>();
            unityContainer.RegisterType<IAreaRepository, AreaRepository>();
            unityContainer.RegisterType<ISeasonRepository, SeasonRepository>();
            unityContainer.RegisterType<IEventRepository, EventRepository>();
            unityContainer.RegisterType<ILocationRepository, LocationRepository>();
        }
    }
}
