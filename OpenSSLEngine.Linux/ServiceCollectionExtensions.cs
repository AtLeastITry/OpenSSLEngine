using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenSSLEngine.Abstraction.Commands;
using System;
using System.Collections.Generic;

namespace OpenSSLEngine.Linux
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddLinuxOpenSSL(this IServiceCollection source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.TryAdd(GetWindowsServices());

            return source;
        }

        private static IEnumerable<ServiceDescriptor> GetWindowsServices()
        {
            yield return ServiceDescriptor.Scoped<IOpenSSLPathProvider, OpenSSlPathProvider>();
        }
    }
}
