using Autofac.Builder;
using Autofac.Features.Scanning;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Autofac.Castle.Interceptor.Core.Autofac.Extensions
{
    /// <summary>
    /// ToTest
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        public static void RegisterMapper(this ContainerBuilder builder, string assembleFullname, params string[] endsWithTypeNames)
        {
            var typeFinder = Engine.EngineContext.Resolve<Engine.ITypeFinder>();
            var assemblies = typeFinder.GetAssemblies().Where(a => a.FullName.Equals(assembleFullname)).ToArray();

            builder.RegisterMapper(assemblies, endsWithTypeNames);
        }

        public static void RegisterMapper(this ContainerBuilder builder, Assembly[] assemblies, params string[] endsWithTypeNames)
        {
            for (int i = 0; i < endsWithTypeNames.Length; i++)
            {
                var endsName = endsWithTypeNames[i];
                builder.RegisterMapper(assemblies, c => c.Name.EndsWith(endsName))
                    .AsImplementedInterfaces().InstancePerLifetimeScope();
            }
        }

        private static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterMapper(this ContainerBuilder builder, Assembly[] assemblies, Func<Type, bool> predicate)
        {
            return builder.RegisterAssemblyTypes(assemblies).Where(predicate);
        }
    }
}
