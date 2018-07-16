using MD.Loger.Net45.v0._8.Tests.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MDTests
{
    public class ExceptionInterceptorTests
    {
        [Fact]
        [Trait("Group", "ExceptionLogger")]
        public void Can_inject_virtual_method()
        {
            var role = new SmsService();
            role.Write("abc-def-g");
        }

        [Fact]
        [Trait("Group", "ExceptionLogger")]
        public void Can_inject_static_method()
        {
            SmsService.Write2("xyz-uvw-o");
        }
    }
}
