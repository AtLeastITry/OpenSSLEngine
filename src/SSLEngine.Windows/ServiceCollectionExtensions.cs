using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SSLEngine.Abstraction;
using SSLEngine.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SSLEngine.Windows
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWindowsSSL(this IServiceCollection source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.TryAdd(GetWindowsServices());

            return source;
        }

        private static IEnumerable<ServiceDescriptor> GetWindowsServices()
        {
            yield return ServiceDescriptor.Singleton<ISSLResourceHandler, SSLResourceHandler>();
        }
    }
}
