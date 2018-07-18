using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Castle.Interceptor.Core.Tests.Logger
{
    //[Intercept(typeof(IInterceptor))]
    public class ConsoleLogger : ILogger
    {
        //必须是虚方法
        public virtual void Write()
        {
            Console.WriteLine("你调用ConsoleLogger的Write方法");
        }
    }
}
