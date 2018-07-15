using Autofac.Castle.Interceptor.Core.Interceptors;
using Autofac.Castle.Interceptor.Core.Tests.Logger;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;

namespace Autofac.Castle.Interceptor.Core.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
#if UseClass
            var container = RegisterDependencies();

            //这里使用的是 接口，因此注册时也需要用EnableInterfaceInterceptors()，
            var logger = container.Resolve<ILogger>();
            logger.Write();
#else
            //测试未通过，使用Class的方式 未成功
            var containerX2 = RegisterDependenciesX2();
            var loggerX2 = containerX2.Resolve<X2ConsoleLogger>();
            loggerX2.Write();
#endif


            #region  不使用 Autofac解析出来的对象 拦截不了
            var logger2 = new ConsoleLogger();
            logger2.Write();
            #endregion

            Console.ReadKey();
        }

        private static IContainer RegisterDependencies()
        {

            var containerBuilder = new ContainerBuilder();

            #region Interface 注入
            //启动Interceptor，是Attribute的方式
            containerBuilder.RegisterType<ConsoleLogger>().As<ILogger>().EnableInterfaceInterceptors();

            ////启动Interceptor，是注册的方式 这样可以不用加Attribute
            //containerBuilder.RegisterType<CircleShape>().As<IShape>().InterceptedBy(typeof(IInterceptor)).EnableInterfaceInterceptors();
            #endregion

            //注册
            containerBuilder.RegisterType<AutofacCastleInterceptor>().As<IInterceptor>().InstancePerDependency();

            var build = containerBuilder.Build();
            return build;
        }

        /// <summary>
        /// Class注入
        /// </summary>
        /// <returns></returns>
        private static IContainer RegisterDependenciesX2()
        {
            var containerBuilder = new ContainerBuilder();

            #region Class注入
            containerBuilder.RegisterType<X2ConsoleLogger>().InterceptedBy(typeof(AutofacCastleInterceptor)).EnableClassInterceptors();
            #endregion

            //注册
            containerBuilder.Register(c => new AutofacCastleInterceptor());
            var build = containerBuilder.Build();
            return build;
        }
    }
}
