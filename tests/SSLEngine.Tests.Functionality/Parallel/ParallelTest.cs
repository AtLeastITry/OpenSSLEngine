using Microsoft.Extensions.DependencyInjection;
using SSLEngine.Abstraction;
using SSLEngine.Core;

namespace SSLEngine.Tests.Functionality.Parrallel
{
    public class ParallelTest
    {
        protected readonly ISSLEngine _engine;

        public ParallelTest()
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
