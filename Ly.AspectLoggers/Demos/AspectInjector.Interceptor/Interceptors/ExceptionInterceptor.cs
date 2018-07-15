using System;
using System.Reflection;
using System.Text;
using AspectInjector.Broker;
using AspectInjector.Interceptor;
using Polly;

/*
 *  奇葩的Bug
 *      不知如何描述.
 *      类库中 定义了[Aspect]的拦截类,再附加了Log处理类，
 *      当引用该类库并使用[Aspect]的拦截类后，编译一直报错。
 *  解决方案      
 *      [Aspect]拦截类的命名空间要区别于其他可能会同名的空间
 *      才不会在被引用时 编译异常。
 *      
 *  而且文件还不能是 拖 到项目中的，需要是新建立的（像GRPC要新建，并复制）
*/
namespace AspectInjectorR.Interceptor.Interceptors
{
    [Aspect(Aspect.Scope.Global)]
    public class ExceptionInterceptor
    {
        [Advice(Advice.Type.Around, Advice.Target.Method)]
        public object TraceAround([Advice.Argument(Advice.Argument.Source.Type)]Type type, [Advice.Argument(Advice.Argument.Source.Arguments)]object[] args, [Advice.Argument(Advice.Argument.Source.Target)]Func<object[], object> action, [Advice.Argument(Advice.Argument.Source.Method)]MethodInfo methodInfo)
        {
            try
            {
                var result = Retry(() => action(args));
                return result;
            }
            catch (Exception ex)
            {
                WriteLog(ex, args, methodInfo);
                return Default(methodInfo.ReturnType);
            }
        }

        #region Utilities
        protected virtual object Default(Type returnType)
        {
            if (returnType.IsValueType
                || (returnType.IsGenericType && returnType.GetInterface("IList") != null))
                return Activator.CreateInstance(returnType);

            return null;
        }
        protected virtual void WriteLog(Exception ex, object[] args, MethodInfo methodInfo)
        {
            #region 获取拼接日志内容

            var parameters = methodInfo.GetParameters();
            var returnType = methodInfo.ReturnType;
            var sb1 = new StringBuilder();

            sb1.Append($"Method:[{methodInfo.Name}]|Params:[");
            for (var i = 0; i < parameters.Length; i++)
            {
                sb1.Append(args[i] != null
                    ? $"{parameters[i].Name}:{args[i]};"
                    : $"{parameters[i].Name}:null;");
            }

            var sb2 = new StringBuilder();
            sb2.Append($"]|ExceptionMessage:{ex.Message} ");

            var logInfo = sb1.ToString().TrimEnd(';') + sb2;
            #endregion

            //todo write
            var client = LogClient.GetClient("172.17.30.234:5051");
            client.Error(logInfo, methodInfo.Name);
        }
        protected virtual TResult Retry<TResult>(Func<TResult> action)
        {
            return Policy
                .Handle<Exception>()
                .Retry(1)
                .Execute(action);
        }
        #endregion
    }
}
