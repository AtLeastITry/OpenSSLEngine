using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenSSLEngine.Abstraction;
using System;
using System.Collections.Generic;

namespace OpenSSLEngine.OSX
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOSXOpenSSL(this IServiceCollection source)
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
