using Autofac;
using Autofac.Engine;
using Castle.DynamicProxy;
using MD.Logger.Interceptors;

namespace MD.Logger
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 0;

        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
            builder.RegisterType<InterceptLogger>().As<IInterceptLogger>().InstancePerDependency();
            builder.RegisterType<DefaultInterceptor>().As<IInterceptor>().InstancePerDependency();
            builder.RegisterType<DefaultInterceptor>().As<IDefaultInterceptor>().InstancePerDependency();
            builder.RegisterType<ExceptionInterceptor>().As<IExceptionInterceptor>().InstancePerDependency();
        }
    }
}




//V2.0

//using Autofac.Castle.Interceptor.Core.Interceptors;
//using Autofac.Engine;
//using Castle.DynamicProxy;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Autofac.Castle.Interceptor.Core
//{
//    public class DependencyRegistrar : IDependencyRegistrar
//    {
//        public int Order => 1;

//        public void Register(ContainerBuilder builder, ITypeFinder typeFinder)
//        {
//            builder.RegisterType<AutofacCastleInterceptor>().As<IInterceptor>().InstancePerDependency();
//        }
//    }
//}
