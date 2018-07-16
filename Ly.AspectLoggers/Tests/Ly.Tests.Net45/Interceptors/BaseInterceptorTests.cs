using Ly.Tests.Data;
using System;
using System.Collections.Generic;
using Xunit;

namespace Ly.Tests.Interceptors
{
    public class BaseInterceptorTests
    {

        [Fact]
        [Trait("Group", "Ly.Tests Base")]
        public void Can_create_default_instance()
        {
            var i = Default(typeof(int));
            Assert.Equal(i, 5);

            var f = Default(typeof(float));
            var a = Default(typeof(A));
            var dictionary = Default(typeof(Dictionary<string, int>));
            var list = Default(typeof(List<int>));

            var dictionaryA = Default(typeof(Dictionary<int, A>));
            var listA = Default(typeof(List<A>));

            #region Data
            object Default(Type type)
            {
                if (type.FullName == "System.Void")
                    return null;

                return Activator.CreateInstance(type);
            }
            #endregion
        }
    }
}