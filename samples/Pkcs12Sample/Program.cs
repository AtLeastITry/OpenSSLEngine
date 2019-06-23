using Microsoft.Extensions.DependencyInjection;
using SSLEngine.Abstraction;
using SSLEngine.Abstraction.Commands.Pkcs12;
using SSLEngine.Core;
using SSLEngine.Domain;
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
            services.AddSSl();
            var serviceProvider = services.BuildServiceProvider();
            var SSLEngine = serviceProvider.GetRequiredService<ISSLEngine>();

            var certificatesPath = $"{Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)}\\certificates";

            await SSLEngine.Pkcs12Async(
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
