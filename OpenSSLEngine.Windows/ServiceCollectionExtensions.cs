using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Abstraction.Commands;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace OpenSSLEngine.Windows
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddWindowsOpenSSL(this IServiceCollection source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.TryAdd(GetWindowsServices());

            return source;
        }

        private static IEnumerable<ServiceDescriptor> GetWindowsServices()
        {
            yield return ServiceDescriptor.Singleton<IOpenSSLPathProvider, OpenSSlPathProvider>();
            yield return ServiceDescriptor.Singleton<IOpenSSLResourceExtractor, OpenSSLResourceExtractor>();
        }
    }
}
