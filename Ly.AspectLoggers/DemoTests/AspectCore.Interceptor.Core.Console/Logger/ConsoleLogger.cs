using System;
using System.Collections.Generic;
using System.Text;

namespace AspectCore.Interceptor.Core.Consoles.Logger
{
    public class ConsoleLogger : ILogger
    {
        public void None()
        {
            Console.WriteLine("ConsoleLogger.None");
        }

        public void Nested()
        {
            Console.WriteLine("ConsoleLogger.Nested");
        }

        public void Aspect()
        {
            Console.WriteLine("ConsoleLogger.Aspect");
        }
    }
}
