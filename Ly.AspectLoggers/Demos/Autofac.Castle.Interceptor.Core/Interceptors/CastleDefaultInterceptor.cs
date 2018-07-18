using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace MD.Logger.Interceptors
{
    public class DefaultInterceptor : Interceptor, IDefaultInterceptor
    {
        public DefaultInterceptor(IInterceptLogger interceptLogger)
            : base(interceptLogger)
        {

        }

        public void Intercept(IInvocation invocation)
        {
            base.InterceptWithDefault(invocation);
        }
    }
}
