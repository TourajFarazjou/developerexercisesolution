using System.Web.Mvc;
using Unity;
using ExerciseWebApplication.Infrastructures;
using ExerciseWebApplication.Services;

namespace ExerciseWebApplication.App_Start
{
    public static class IocConfig
    {
        public static void ConfigureIoCcontainer()
        {
            IUnityContainer container = new UnityContainer();

            container.RegisterType<IDataCacheService, DataCacheService>();
            container.RegisterType<IDataService, DataService>();
            container.RegisterType<ILocationService, LocationService>();
 
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}