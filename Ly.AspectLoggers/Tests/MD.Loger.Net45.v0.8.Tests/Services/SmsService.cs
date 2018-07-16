using AspectInjector.Broker;
using MD.Logger;
using MDLogger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MD.Loger.Net45.v0._8.Tests.Services
{
    [Inject(typeof(ExceptionInterceptor))]
    public class SmsService
    {
        public virtual void Write(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Write2(string msg)
        {
            throw new ArgumentException("Argu Error");
        }
    }
}
