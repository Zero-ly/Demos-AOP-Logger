using System;

namespace CastleDynamicProxy.Interceptor.Core.Tests.Logger
{
    public class ConsoleLogger : ILogger
    {
        public virtual void Write()
        {
            Console.WriteLine("ConsoleLogger,Write");
        }
    }
}
