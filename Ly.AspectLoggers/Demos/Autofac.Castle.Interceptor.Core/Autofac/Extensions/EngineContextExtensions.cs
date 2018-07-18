using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Autofac.Engine
{
    public static class EngineContextExtensions
    {
        public static IServiceProvider EngineInitialize(this IServiceCollection services)
        {
            EngineContext.Initialize(services);
            return EngineContext.ServiceProvider;
        }
    }

    public partial class EngineContext
    {
        #region ServiceProvider's  Resolve Methods
        public static T Resolve<T>() where T : class
        {
            return (T)GetServiceProvider().GetRequiredService(typeof(T));
        }
        public static object Resolve(Type type)
        {
            return GetServiceProvider().GetRequiredService(type);
        }

        /// <summary>
        /// 已弃用,ToArray有点多余了。
        /// </summary>
        //public static T[] ResolveAll<T>()
        //{
        //    return GetServiceProvider().GetService<IEnumerable<T>>().ToArray();
        //}
        public static IEnumerable<T> ResolveAll<T>()
        {
            return GetServiceProvider().GetService<IEnumerable<T>>();
        }
        #endregion

        #region (testing) Container's resole methods 
        public static T Resolve<T>(string key) where T : class
        {
            return Container.ResolveKeyed<T>(key);
        }
        public static IEnumerable<T> ResolveAll<T>(string key)
        {
            return Container.ResolveKeyed<IEnumerable<T>>(key);
        }

        public static bool TryResolve<T>(out T instance)
        {
            return Container.TryResolve<T>(out instance);
        }
        public static bool TryResolve(Type serviceType, out object instance)
        {
            return Container.TryResolve(serviceType, out instance);
        }
        //public static T ResolveUnregistered<T>() where T : class
        //{
        //    return Container.ResolveUnregistered(typeof(T)) as T;
        //}
        //public static object ResolveUnregistered(Type type)
        //{
        //    return Container.ResolveUnregistered(type);
        //}
        #endregion
    }
}
