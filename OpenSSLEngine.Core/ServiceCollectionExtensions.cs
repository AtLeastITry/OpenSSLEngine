using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Domain;
using System;
using System.Collections.Generic;

namespace OpenSSLEngine.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenSSl(this IServiceCollection source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.AddOpenSSlDomain();

            source.TryAdd(GetServices());

            OpenSSLEngineFactory.Initialize(() => source.BuildServiceProvider().GetService<IOpenSSLEngine>());

            return source;
        }

        private static IEnumerable<ServiceDescriptor> GetServices()
        {
            yield return ServiceDescriptor.Scoped<IOpenSSLEngine, OpenSSLEngine>();
        }
    }
}
