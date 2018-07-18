using Autofac.Builder;
using Autofac.Features.Scanning;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;
using Autofac.Extras.DynamicProxy;

namespace Autofac.Engine
{
    /// <summary>
    /// ToTest
    /// </summary>
    public static class ContainerBuilderExtensions
    {
        public static void RegisterMapper(this ContainerBuilder builder, ITypeFinder typeFinder, string assembleFullname, params string[] endsWithTypeNames)
        {
            Assembly[] assemblies;
            if (string.IsNullOrEmpty(assembleFullname))
                assemblies = typeFinder.GetAssemblies().ToArray();
            else
                assemblies = typeFinder.GetAssemblies().Where(a => a.ManifestModule.Name.Equals(assembleFullname, StringComparison.OrdinalIgnoreCase)).ToArray();

            builder.RegisterMapper(assemblies, endsWithTypeNames);
        }

        public static void RegisterMapper(this ContainerBuilder builder, Assembly[] assemblies, params string[] endsWithTypeNames)
        {
            if (assemblies == null || assemblies.Length == 0)
                return;

            for (int i = 0; i < endsWithTypeNames.Length; i++)
            {
                var endsName = endsWithTypeNames[i];
                builder.RegisterAssemblyTypes(assemblies)
                        .Where(c => c.Name.EndsWith(endsName))
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope()
                        .EnableInterfaceInterceptors();
            }
        }

        #region Not Work,  ToTest
        //for (int i = 0; i<endsWithTypeNames.Length; i++)
        //{
        //    var endsName = endsWithTypeNames[i];
        //    builder.RegisterMapper(assemblies, c => c.Name.EndsWith(endsName))
        //    .AsImplementedInterfaces().InstancePerLifetimeScope();
        //}

        //private static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterMapper(this ContainerBuilder builder, Assembly[] assemblies, Func<Type, bool> predicate)
        //{
        //    if (assemblies == null || assemblies.Length == 0)
        //        assemblies = new Assembly[0];

        //    return builder.RegisterAssemblyTypes(assemblies).Where(predicate);
        //}
        #endregion
    }
}
