using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MD.Logger.Interceptors
{
    public class ExceptionInterceptor : Interceptor, IExceptionInterceptor
    {
        public ExceptionInterceptor(IInterceptLogger interceptLogger)
            : base(interceptLogger)
        {

        }

        public void Intercept(IInvocation invocation)
        {
            base.InterceptWithException(invocation);
        }
    }
}
