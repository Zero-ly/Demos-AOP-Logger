using Castle.DynamicProxy;
using System;

namespace CastleDynamicProxy.Interceptor.Core.Interceptors
{
    public class CastleProxyInterceptor : IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine("Before CastleInterceptor.Intercept");
            invocation.Proceed();
            Console.WriteLine("After CastleInterceptor.Intercept");
        }
    }
}
