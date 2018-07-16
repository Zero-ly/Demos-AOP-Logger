using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDTests
{
    class Program
    {
        static void Main(string[] args)
        {
            var tests1 = new ExceptionLoggerTests();
            tests1.Can_inject_static_method();
            tests1.Can_inject_virtual_method();

            var test2 = new ExceptionInterceptorTests();
            test2.Can_inject_static_method();
            test2.Can_inject_virtual_method();

            Console.ReadKey();
        }
    }
}
