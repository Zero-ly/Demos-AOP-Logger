using Castle.DynamicProxy;
using Polly;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MD.Logger.Interceptors
{
    public class Interceptor //: IExceptionInterceptor, IDefaultInterceptor
    {
        #region Fields
        private readonly IInterceptLogger _interceptLogger;
        #endregion

        public Interceptor(IInterceptLogger interceptLogger)
        {
            _interceptLogger = interceptLogger;
        }

        //public abstract void Intercept(IInvocation invocation);

        #region Intercept Methods
        /// <summary>
        /// 拦截方法
        /// </summary>
        /// <param name="invocation">包含被拦截方法的信息</param>
        public void InterceptWithDefault(IInvocation invocation)
        {
            try
            {
                Debug.WriteLine("Before Proceed");
                Retry(() => invocation.Proceed());
                Debug.WriteLine("After Proceed");
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
                Debug.WriteLine("Before Proceed");
                Retry(() => invocation.Proceed());
                Debug.WriteLine("After Proceed");
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
