using AspectInjector.Broker;
using MD.Logger.Interceptors;
using System;
using System.Reflection;

namespace AspectLoggerX
{
    [Aspect(Aspect.Scope.Global)]
    public class ExceptionLogger : BaseInterceptor
    {
        [Advice(Advice.Type.Around, Advice.Target.Method)]
        public object TraceAround(
            [Advice.Argument(Advice.Argument.Source.Arguments)] object[] args,
            [Advice.Argument(Advice.Argument.Source.Instance)] object _this,
            [Advice.Argument(Advice.Argument.Source.Method)] MethodBase method,
            [Advice.Argument(Advice.Argument.Source.Name)] string name,
            [Advice.Argument(Advice.Argument.Source.ReturnType)] Type retType,
            [Advice.Argument(Advice.Argument.Source.Target)] Func<object[], object> target)
        {
            try
            {
                var result = base.Retry(() => target(args));
                return result;
            }
            catch (Exception ex)
            {
                base.WriteLog(ex, args, method);
                throw new Exception("", ex);
            }
        }
    }
}
