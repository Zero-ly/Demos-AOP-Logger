using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Castle.Interceptor.Core.Tests.Logger
{
    public class X2ConsoleLogger
    {
        //必须是虚方法
        public virtual void Write()
        {
            Console.WriteLine("你调用ConsoleLogger的Write方法");
        }
    }
}
