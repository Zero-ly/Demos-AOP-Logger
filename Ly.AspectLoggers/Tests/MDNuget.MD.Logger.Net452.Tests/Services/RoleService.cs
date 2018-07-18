using AspectInjector.Broker;
using MDLogger.Interceptors;
using System;

namespace MDNuget.MD.Logger.Net452.Tests.Services
{
    [Inject(typeof(DefaultInterceptor))]
    public class RoleService
    {
        public virtual void GetRoleDetail(string roleId)
        {
            Console.WriteLine("RoleService.GetRoleDetail:roleId=" + roleId);
            throw new Exception("abc");
        }

        public static void GetRoleName(string roleId)
        {
            Console.WriteLine("RoleService.GetRoleName:roleId=" + roleId);
        }
    }
}
