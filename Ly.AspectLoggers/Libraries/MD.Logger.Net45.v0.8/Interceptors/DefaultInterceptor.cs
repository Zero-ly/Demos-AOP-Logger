//using AspectInjector.Broker;
//using MD.Logger.Interceptors;
//using System;
//using System.Reflection;

//namespace MD.Logger
//{
//    /// <summary>
//    /// 默认拦截器（异常发生后返回默认值）
/// 本想提供 Intercept方法的接口???
//    /// </summary>
//    public abstract class DefaultInterceptor : BaseInterceptor
//    {
//        /// <summary>
//        /// 可以使用
//        /// </summary>
//        /// <param name="args"></param>
//        /// <param name="method"></param>
//        /// <param name="returnType"></param>
//        /// <param name="target"></param>
//        /// <returns></returns>
//        [Advice(Advice.Type.Around, Advice.Target.Method)]
//        public object Intercept(
//            [Advice.Argument(Advice.Argument.Source.Arguments)] object[] args,
//            [Advice.Argument(Advice.Argument.Source.Method)] MethodBase method,
//            [Advice.Argument(Advice.Argument.Source.ReturnType)] Type returnType,
//            [Advice.Argument(Advice.Argument.Source.Target)] Func<object[], object> target)
//        {

//        }
//    }
//}
