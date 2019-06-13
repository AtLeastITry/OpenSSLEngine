using Microsoft.Extensions.DependencyInjection;
using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Abstraction.Commands.Req;
using OpenSSLEngine.Core;
using System.IO;
using System.Threading.Tasks;

namespace ReqSample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddOpenSSl();
            var serviceProvider = services.BuildServiceProvider();
            var openSSLEngine = serviceProvider.GetRequiredService<IOpenSSLEngine>();

            await openSSLEngine.ReqAsync(
                options: new ReqOptions
                {
                    NewKey = "rsa:2048",
                    Nodes = true,
                    KeyOut = $"{Path.GetTempPath()}\\test.key",
                    X509 = true,
                    Days = 365,
                    Out = $"{Path.GetTempPath()}\\test.cer"
                },
                input: new ReqInput
                {
                    CommonName = "",
                    CountryName = "",
                    EmailAddress = "",
                    LocalityName = "",
                    OrganizationalUnitName = "",
                    OrganizationName = "",
                    StateOrProvinceName = ""
                }
            );
        }
    }
}
