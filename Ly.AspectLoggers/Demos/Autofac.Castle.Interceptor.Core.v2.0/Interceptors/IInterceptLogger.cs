using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Castle.Interceptor.Core
{
    public interface IInterceptLogger
    {
        void Write(IInvocation invocation, Exception ex);
    }
}
