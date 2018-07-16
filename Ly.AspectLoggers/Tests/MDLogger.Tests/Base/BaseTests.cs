using Ly.Tests.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDLogger.Tests.Base
{
    public class BaseTests
    {
        public static void Can_create_default_instance()
        {
            var i = Default(typeof(int));

            var f = Default(typeof(float));
            var a = Default(typeof(A));                 //内部List 为null

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
