using AspectInjector.Broker;
using AspectInjectorR.Interceptor.Interceptors;
using System;

namespace AspectInjectorT.Interceptor.Tests.Services
{
    [Inject(typeof(ExceptionInterceptor))]
    public class ConsoleLogger //: ILogger
    {
        public virtual void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Write2(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
