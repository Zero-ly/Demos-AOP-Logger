using Autofac.Engine;
using Autofac.Extras.DynamicProxy;
using MDNuget.Tests.ServicesWithAutofac;
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
            builder.RegisterMapper(typeFinder, "Autofac.Castle.Interceptor.Core.Tests.dll", "Service");

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope().EnableInterfaceInterceptors();
        }
    }
}
