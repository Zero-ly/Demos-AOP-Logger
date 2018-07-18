using Autofac.Castle.Interceptor.Core.Interceptors;
using Autofac.Castle.Interceptor.Core.Tests.Logger;
using Autofac.Engine;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Castle.Interceptor.Core.Tests.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<ConsoleLogger>().As<ILogger>()
                .InterceptedBy(typeof(IInterceptor)).EnableClassInterceptors();

            builder.RegisterType<AutofacCastleInterceptor>().As<IInterceptor>().InstancePerLifetimeScope();
        }
    }
}
