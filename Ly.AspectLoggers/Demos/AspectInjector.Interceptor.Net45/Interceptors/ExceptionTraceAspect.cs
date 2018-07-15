using System;
using System.Reflection;
using AspectInjector.Broker;
using Polly;

namespace AspectInjector.Interceptor.Net45.Interceptors
{
    [Aspect(Aspect.Scope.Global)]
    public class ExceptionTraceAspect
    {
        [Advice(Advice.Type.Around, Advice.Target.Constructor | Advice.Target.Method)]
        public object Around2([Advice.Argument(Advice.Argument.Source.Type)]Type type, [Advice.Argument(Advice.Argument.Source.Arguments)]object[] args, [Advice.Argument(Advice.Argument.Source.Target)]Func<object[], object> action, [Advice.Argument(Advice.Argument.Source.Method)]MethodInfo methodInfo)
        {
            Console.WriteLine("Before TraceAround");
            var result = Retry(() => action(args));
            Console.WriteLine("After TraceAround");
            return result;
        }

        private TResult Retry<TResult>(Func<TResult> action)
        {
            return Policy
                .Handle<Exception>()
                .Retry(1)
                .Execute(action);
        }
    }
}
