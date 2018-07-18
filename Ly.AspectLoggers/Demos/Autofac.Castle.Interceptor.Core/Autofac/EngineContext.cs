using System;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace Autofac.Engine
{
    public partial class EngineContext
    {
        #region Fields X1
        private static IContainer _container;

        public static IContainer Container
        {
            get
            {
                return _container;
            }
        }
        #endregion

        #region Fields X2
        private static IServiceProvider _serviceProvider { get; set; }
        private static IServiceProvider GetServiceProvider()
        {
            if (_serviceProvider == null)
                _serviceProvider = new AutofacServiceProvider(_container);

            //ToImprove  Microsoft.AspNetCore.Http.HttpContext.IServiceProvider

            return _serviceProvider;
        }
        public static IServiceProvider ServiceProvider => _serviceProvider;
        #endregion

        #region Utilities
        protected static IContainer RegisterDependencies(IServiceCollection services = null)
        {
            var containerBuilder = new ContainerBuilder();

            var typeFinder = new AppDomainTypeFinder();
            containerBuilder.RegisterInstance(typeFinder).SingleInstance();

            var dependencyTypes = typeFinder.FindClassesOfType<IDependencyRegistrar>();
            var dependencyInstances = new List<IDependencyRegistrar>();
            foreach (var dependency in dependencyTypes)
            {
                dependencyInstances.Add((IDependencyRegistrar)Activator.CreateInstance(dependency));
            }


            dependencyInstances = dependencyInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in dependencyInstances)
                dependencyRegistrar.Register(containerBuilder, typeFinder);

            if (services != null)
                containerBuilder.Populate(services);

            _container = containerBuilder.Build();
            return _container;
        }

        #endregion

        #region Init Methods
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void Initialize(IServiceCollection services = null)
        {
            //ToImprove Initialize
            RegisterDependencies(services);
        }
        #endregion
    }
}
