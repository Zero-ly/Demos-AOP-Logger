using Autofac.Castle.Interceptor.Core.Interceptors;
using Autofac.Engine;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Castle.Interceptor.Core
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<AutofacCastleInterceptor>().As<IInterceptor>().InstancePerDependency();
        }
    }
}
