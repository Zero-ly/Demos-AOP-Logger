using Castle.DynamicProxy;

namespace Autofac.Castle.Interceptor.Core
{
    public class ExceptionInterceptor : BaseInterceptor
    {
        public ExceptionInterceptor(IInterceptLogger interceptLogger)
            : base(interceptLogger)
        {

        }

        public override void Intercept(IInvocation invocation)
        {
            base.InterceptWithDefault(invocation);
        }
    }
}
