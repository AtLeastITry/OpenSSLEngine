using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using SSLEngine.Abstraction.Commands;
using SSLEngine.Abstraction.Commands.Pkcs12;
using SSLEngine.Abstraction.Commands.Req;
using SSLEngine.Linux;
using SSLEngine.OSX;
using SSLEngine.Windows;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SSLEngine.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSSlDomain(this IServiceCollection source)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                source.AddWindowsSSL();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                source.AddLinuxSSL();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                source.AddOSXSSL();
            }

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.TryAdd(GetCommands());
            source.TryAdd(GetServices());

            return source;
        }

        private static IEnumerable<ServiceDescriptor> GetCommands()
        {
            yield return ServiceDescriptor.Scoped<ICommand<ReqOptions, ReqInput>, ReqCommand>();
            yield return ServiceDescriptor.Scoped<ICommand<Pkcs12Options, Pkcs12Input>, Pkcs12Command>();
        }

        private static IEnumerable<ServiceDescriptor> GetServices()
        {
            yield return ServiceDescriptor.Scoped<ISSLEngineProcessFactory, SSLEngineProcessFactory>();
        }
    }
}
