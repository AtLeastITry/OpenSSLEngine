using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OpenSSLEngine.Abstraction.Commands;
using OpenSSLEngine.Abstraction.Commands.Pkcs12;
using OpenSSLEngine.Abstraction.Commands.Req;
using OpenSSLEngine.Core.Domain;
using OpenSSLEngine.Linux;
using OpenSSLEngine.OSX;
using OpenSSLEngine.Windows;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace OpenSSLEngine.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddOpenSSlDomain(this IServiceCollection source)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                source.AddWindowsOpenSSL();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                source.AddLinuxOpenSSL();
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                source.AddOSXOpenSSL();
            }

            if (source == null)
                throw new ArgumentNullException(nameof(source));

            source.TryAdd(GetCommands());

            return source;
        }

        private static IEnumerable<ServiceDescriptor> GetCommands()
        {
            yield return ServiceDescriptor.Scoped<ICommand<ReqOptions, ReqInput>, ReqCommand>();
            yield return ServiceDescriptor.Scoped<ICommand<Pkcs12Options, Pkcs12Input>, Pkcs12Command>();
        }
    }
}
