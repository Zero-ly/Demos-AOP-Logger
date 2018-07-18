using System;
using System.Collections.Generic;
using System.Text;

namespace MDNuget.Tests.Services
{
    public class RoleService : IRoleService
    {
        public virtual void GetRoleDetail()
        {
            Console.WriteLine("GetRoleDetail");
        }
    }
}
