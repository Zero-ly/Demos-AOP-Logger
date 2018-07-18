using MDNuget.MD.Logger.Net452.Tests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDNuget.MD.Logger.Net452.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var role = new RoleService();
                role.GetRoleDetail("abc-def-g");
            }
            catch (Exception ex)
            {
                Console.WriteLine("d");
            }

            Console.WriteLine("end");
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
