using Microsoft.Extensions.DependencyInjection;
using SSLEngine.Abstraction;
using SSLEngine.Core;

namespace SSLEngine.Tests.Functionality
{
    public class BaseTest
    {
        protected readonly ISSLEngine _engine;

        public BaseTest()
        {
            var services = new ServiceCollection();
            services.AddSSl(options => 
            {
                options.EnableParallelExecution = true;
                options.DeleteDirectory = false;
            });
            var serviceProvider = services.BuildServiceProvider();
            _engine = serviceProvider.GetRequiredService<ISSLEngine>();
        }
    }
}
