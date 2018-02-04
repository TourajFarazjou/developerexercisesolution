using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Unity;

namespace ExerciseWebApplication.Infrastructures
{
    public class UnityDependencyResolver : IDependencyResolver
    {
        private IUnityContainer _UnityContainer;

        public UnityDependencyResolver(IUnityContainer unityContainer)
        {
            _UnityContainer = unityContainer;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _UnityContainer.Resolve(serviceType);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _UnityContainer.ResolveAll(serviceType);
            }
            catch (Exception)
            {
                return new List<object>();
            }
        }
    }
}