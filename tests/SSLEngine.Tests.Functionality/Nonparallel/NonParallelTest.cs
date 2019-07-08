using Microsoft.Extensions.DependencyInjection;
using SSLEngine.Abstraction;
using SSLEngine.Core;

namespace SSLEngine.Tests.Functionality.NonParallel
{
    public class NonParallelTest
    {
        protected readonly ISSLEngine _engine;

        public NonParallelTest()
        {
            var services = new ServiceCollection();
            services.AddSSl(options => 
            {
                options.EnableParallelExecution = false;
            });
            var serviceProvider = services.BuildServiceProvider();
            _engine = serviceProvider.GetRequiredService<ISSLEngine>();
        }
    }
}
