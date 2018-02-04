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

            RegisterServices(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IDataCacheService, DataCacheService>();
            container.RegisterType<IDataService, DataService>();
        }
    }
}