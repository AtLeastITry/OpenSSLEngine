using Microsoft.Extensions.DependencyInjection;
using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Abstraction.Commands.Pkcs12;
using OpenSSLEngine.Core;
using OpenSSLEngine.Domain;
using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace Pkcs12Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddOpenSSl();
            var serviceProvider = services.BuildServiceProvider();
            var openSSLEngine = serviceProvider.GetRequiredService<IOpenSSLEngine>();

            var certificatesPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\certificates";

            await openSSLEngine.Pkcs12Async(
                options: new Pkcs12Options
                {
                    Export = true,
                    In = $"{certificatesPath}\\test.cer",
                    InKey = $"{certificatesPath}\\test.key",
                    Out = $"{Path.GetTempPath()}\\test.pfx",
                    PassOut = "pass:1234"
                }
            );
        }
    }
}
