using Castle.DynamicProxy;
using Polly;
using System;

namespace Autofac.Castle.Interceptor.Core
{
    public abstract class BaseInterceptor : IInterceptor
    {
        #region Fields
        private readonly IInterceptLogger _interceptLogger;
        #endregion

        public BaseInterceptor(IInterceptLogger interceptLogger)
        {
            _interceptLogger = interceptLogger;
        }

        public abstract void Intercept(IInvocation invocation);

        #region Intercept Methods
        /// <summary>
        /// 拦截方法
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void InterceptWithDefault(IInvocation invocation)
        {
            try
            {
                Retry(() => invocation.Proceed());
            }
            catch (Exception ex)
            {
                _interceptLogger.Write(invocation, ex);
            }
        }

        public void InterceptWithException(IInvocation invocation)
        {
            try
            {
                Retry(() => invocation.Proceed());
            }
            catch (Exception ex)
            {
                _interceptLogger.Write(invocation, ex);
                throw ex;
            }
        }

        protected virtual void Retry(Action action, int retryCount = 1)
        {
            Policy.Handle<Exception>().Retry(retryCount).Execute(action);
        }
        #endregion
    }
}
