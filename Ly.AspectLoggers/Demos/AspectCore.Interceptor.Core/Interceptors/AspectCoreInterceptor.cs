using AspectCore.DynamicProxy;
using AspectCore.Extensions.AspectScope;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AspectCore.Interceptor.Core.Interceptors
{
    public class AspectCoreInterceptor : ScopeInterceptorAttribute
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            Console.WriteLine("Before Invoke=> execute method : {0}.{1}", context.ServiceMethod.DeclaringType, context.ServiceMethod.Name);
            return context.Invoke(next);
        }

        //private string GetTraceId(AspectContext currentContext)
        //{
        //    var scheduler = (IAspectScheduler)currentContext.ServiceProvider.GetService(typeof(IAspectScheduler));
        //    var firstContext = scheduler.GetCurrentContexts().First();
        //    if (firstContext.AdditionalData.TryGetValue("trace-id", out var traceId))
        //    {
        //        return traceId.ToString();
        //    }
        //    traceId = Guid.NewGuid();
        //    firstContext.AdditionalData["trace-id"] = traceId;
        //    return traceId.ToString();
        //}
    }
}
