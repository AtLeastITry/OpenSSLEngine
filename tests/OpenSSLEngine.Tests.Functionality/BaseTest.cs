using Microsoft.Extensions.DependencyInjection;
using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Core;

namespace OpenSSLEngine.Tests.Functionality
{
    public class BaseTest
    {
        protected readonly IOpenSSLEngine _engine;

        public BaseTest()
        {
            var services = new ServiceCollection();
            services.AddOpenSSl(options => 
            {
                options.EnableParallelExecution = true;
                options.DeleteDirectory = false;
            });
            var serviceProvider = services.BuildServiceProvider();
            _engine = serviceProvider.GetRequiredService<IOpenSSLEngine>();
        }
    }
}
