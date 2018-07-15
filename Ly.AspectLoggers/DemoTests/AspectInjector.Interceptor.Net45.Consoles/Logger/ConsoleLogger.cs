using AspectInjector.Broker;
using AspectInjector.Interceptor.Net45.Interceptors;
using System;

namespace AspectInjector.Interceptor.Net45.Consoles.Logger
{
    [Inject(typeof(ExceptionTraceAspect))]
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
