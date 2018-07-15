using AspectInjector.Broker;
using MDAspectLogger;
using System;

namespace MDLogger.Tests.Services
{
    [Inject(typeof(ExceptionInterceptor))]
    public class XLogger //: ILogger
    {
        public virtual void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Write2(string msg)
        {
            throw new ArgumentException("Argu Error");
            //Console.WriteLine(msg);
        }
    }
}
