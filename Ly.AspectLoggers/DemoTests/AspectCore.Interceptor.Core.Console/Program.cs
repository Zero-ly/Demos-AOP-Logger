using System;
using AspectCore.Extensions.AspectScope;
using AspectCore.Injector;
using AspectCore.Interceptor.Core.Consoles.Logger;

namespace AspectCore.Interceptor.Core.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            var resolver = ContainerBuild();

            var logger = resolver.Resolve<ILogger>();

            logger.None();
            logger.Nested();
            logger.Aspect();

            Console.ReadKey();
        }

        static IServiceResolver ContainerBuild()
        {
            IServiceContainer serviceContainer1 = new ServiceContainer();
            serviceContainer1.AddAspectScope();
            serviceContainer1.AddType<ILogger, ConsoleLogger>();

            return serviceContainer1.Build();
        }
    }
}
