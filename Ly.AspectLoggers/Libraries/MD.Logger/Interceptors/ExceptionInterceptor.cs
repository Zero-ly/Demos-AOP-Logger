using System;
using System.Reflection;
using System.Text;
using AspectInjector.Broker;
using MD.Logger;
using MD.Logger.Interceptors;
using Polly;

/*
 *  奇葩的Bug
 *      不知如何描述.
 *      类库中 定义了[Aspect]的拦截类,再附加了Log处理类，
 *      当引用该类库并使用[Aspect]的拦截类后，编译一直报错。
 *  解决方案      
 *      [Aspect]拦截类的命名空间要区别于其他可能会同名的空间
 *      才不会在被引用时 编译异常。

   而且文件还不能是 拖 到项目中的，需要是新建立的

*/
/// <summary>
/// 名称空间 尽量避免同名
/// </summary>
namespace MDAspectLogger
{
    [Aspect(Aspect.Scope.Global)]
    public class ExceptionInterceptor : BaseInterceptor
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
            //            [Advice.Argument(Advice.Argument.Source.Type)]Type type
            //[Advice.Argument(Advice.Argument.Source.Arguments)]object[] args
            //, [Advice.Argument(Advice.Argument.Source.Target)]Func<object[], object> action
            //, [Advice.Argument(Advice.Argument.Source.Method)]MethodInfo methodInfo
            try
            {
                var result = base.Retry(() => target(args));
                return result;
            }
            catch (Exception ex)
            {
                base.WriteLog(ex, args, method);
                return base.Default(retType);
            }
        }
    }
}
