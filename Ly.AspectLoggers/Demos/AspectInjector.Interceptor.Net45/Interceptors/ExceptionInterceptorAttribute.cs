using AspectInjector.Broker;
using System;
using System.Reflection;

namespace AspectInjector.Interceptor.Net45.Interceptors
{
    [Aspect(Aspect.Scope.Global)]
    public class ExceptionInterceptorAttribute : Attribute
    {

        //编译不了...使用dll的方式时，编译不了。
        // 可以考虑 定义 父类，只处理 日志，由客户端 实现AOP, 这样也能实现 注入配置信息


        private int i;
        public ExceptionInterceptorAttribute()
        {

        }

        [Advice(Advice.Type.Around, Advice.Target.Method)]
        public object TraceAround([Advice.Argument(Advice.Argument.Source.Type)]Type type, [Advice.Argument(Advice.Argument.Source.Arguments)]object[] args, [Advice.Argument(Advice.Argument.Source.Target)]Func<object[], object> action, [Advice.Argument(Advice.Argument.Source.Method)]MethodInfo methodInfo)
        {
            Console.WriteLine(i);
            return null;
        }

        #region Utilities
        #endregion
    }
}
