using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Castle.Interceptor.Core.Tests
{
    //[Intercept(typeof(IInterceptor))]
    public class RoleService : IRoleService
    {
        public virtual void GetRoleDetail()
        {
            Console.WriteLine("GetRoleDetail");
        }
    }
}
