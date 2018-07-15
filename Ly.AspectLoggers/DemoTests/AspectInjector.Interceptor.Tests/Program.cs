using AspectInjectorT.Interceptor.Tests.Services;
using System;

namespace AspectInjectorT.Interceptor.Tests
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
