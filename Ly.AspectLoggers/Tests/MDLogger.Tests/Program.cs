using MDLogger.Tests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDLogger.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var console = new XLogger();
            console.Write("T");

            XLogger.Write2("T");

            var s = new SmsService();
            s.Write("g");

            Console.ReadKey();
        }
    }
}
