using AspectInjector.Broker;
using System;

namespace MDLogger.Tests
{
    [Inject(typeof(AspectLoggerX.ExceptionLogger))]
    public class SmsService //: ILogger
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
