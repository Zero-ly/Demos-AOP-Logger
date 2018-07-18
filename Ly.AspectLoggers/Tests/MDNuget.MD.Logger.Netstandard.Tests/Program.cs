using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using MD.Logger.Interceptors;
using MDNuget.Tests.Services;
using System;

namespace MDNuget.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerX2 = T3();
            var loggerX2 = containerX2.Resolve<IRoleService>();
            loggerX2.GetRoleDetail();

            Console.ReadKey();
        }

        private static IContainer T3()
        {
            var containerBuilder = new ContainerBuilder();

            #region Class注入
            containerBuilder.RegisterType<RoleService>().As<IRoleService>()
                .InterceptedBy(typeof(IInterceptor)).EnableClassInterceptors();
            #endregion

            //注册
            containerBuilder.RegisterType<DefaultInterceptor>().As<IInterceptor>().InstancePerDependency();
            containerBuilder.RegisterType<InterceptLogger>().As<IInterceptLogger>().InstancePerDependency();

            var build = containerBuilder.Build();
            return build;
        }
    }
}
