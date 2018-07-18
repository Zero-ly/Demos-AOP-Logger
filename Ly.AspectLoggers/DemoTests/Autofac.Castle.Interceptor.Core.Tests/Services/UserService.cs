using Autofac.Extras.DynamicProxy;
using MD.Logger.Interceptors;
using System;
using System.Collections.Generic;
using System.Text;

namespace MDNuget.Tests.ServicesWithAutofac
{
    [Intercept(typeof(IExceptionInterceptor))]
    public class UserService : IUserService
    {
        public virtual void GetUser()
        {
            Console.WriteLine("IUserService.GetUser");
        }
    }
}
