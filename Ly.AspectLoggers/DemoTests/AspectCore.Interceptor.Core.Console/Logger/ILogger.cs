using AspectCore.Extensions.AspectScope;
using AspectCore.Interceptor.Core.Interceptors;

namespace AspectCore.Interceptor.Core.Consoles.Logger
{
    public interface ILogger
    {
        [AspectCoreInterceptor(Scope = Scope.None)]
        void None();

        [AspectCoreInterceptor(Scope = Scope.Nested)]
        void Nested();

        [AspectCoreInterceptor(Scope = Scope.Aspect)]
        void Aspect();
    }
}
