using Autofac;
using Autofac.Engine;
using MDNuget.Tests.ServicesWithAutofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDNuget.Tests.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterMapper("MDNuget.Tests.dll", "Service");

            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
        }
    }
}
