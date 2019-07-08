using Microsoft.Extensions.Options;
using SSLEngine.Abstraction;
using SSLEngine.Domain.Commands;

namespace SSLEngine.Domain
{
    internal class SSLEngineProcessFactory : ISSLEngineProcessFactory
    {
        private readonly ISSLResourceHandler _sslResourceHandler;
        private readonly bool _useParallellExecution;

        public SSLEngineProcessFactory(ISSLResourceHandler sslResourceHandler, IOptions<SSLEngineOptions> options)
        {
            _sslResourceHandler = sslResourceHandler;
            _useParallellExecution = options.Value.EnableParallelExecution;
        }

        public SSLEngineProcess Create()
        {
            return new SSLEngineProcess(_sslResourceHandler, _useParallellExecution);
        }
    }
}
