using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SSLEngine.Abstraction;
using SSLEngine.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SSLEngine.Core
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSSl(this IServiceCollection source, Action<SSLEngineOptions> options = null)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.AddSSlDomain();

            source.TryAdd(GetServices());


            source.Configure(
                options ?? 
                new Action<SSLEngineOptions>(o => o.EnableParallelExecution = false)
            );

            SSLEngineFactory.Initialize(() => source.BuildServiceProvider().GetService<ISSLEngine>());

            return source;
        }

        private static IEnumerable<ServiceDescriptor> GetServices()
        {
            yield return ServiceDescriptor.Scoped<ISSLEngine, SSLEngine>();
        }
    }
}
