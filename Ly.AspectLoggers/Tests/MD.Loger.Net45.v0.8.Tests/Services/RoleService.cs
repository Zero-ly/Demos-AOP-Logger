using AspectInjector.Broker;
using MD.Loger.Net45.v0._8.Tests.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.Loger.Net45.v0._8.Tests.Services
{
    [Inject(typeof(ExceptionLogger))]
    public class RoleService
    {
        public virtual void GetRoleDetail(string roleId)
        {
            Console.WriteLine("RoleService.GetRoleDetail:roleId=" + roleId);
        }

        public static void GetRoleName(string roleId)
        {
            Console.WriteLine("RoleService.GetRoleName:roleId=" + roleId);
        }
    }
}
