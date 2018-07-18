using Castle.DynamicProxy;
using System;

namespace MD.Logger.Interceptors
{
    public interface IInterceptLogger
    {
        void Write(IInvocation invocation, Exception ex);
    }
}
