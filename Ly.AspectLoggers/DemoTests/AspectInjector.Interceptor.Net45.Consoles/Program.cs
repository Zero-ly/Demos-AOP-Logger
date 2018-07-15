using AspectInjector.Interceptor.Net45.Consoles.Logger;
using System;

namespace AspectInjector.Interceptor.Net45.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new ConsoleLogger();
            console.Write("T");

            ConsoleLogger.Write2("T");

            Console.ReadKey();
        }
    }
}
