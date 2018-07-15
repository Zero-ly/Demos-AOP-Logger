using Castle.DynamicProxy;
using CastleDynamicProxy.Interceptor.Core.Interceptors;
using CastleDynamicProxy.Interceptor.Core.Tests.Logger;
using System;

namespace CastleDynamicProxy.Interceptor.Core.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator();

            Console.ReadKey();
        }

        static void Generator()
        {
            ProxyGenerator generator = new ProxyGenerator();

            var proxy = generator.CreateClassProxy<ConsoleLogger>(new CastleProxyInterceptor());
            proxy.Write();
        }
    }
}
