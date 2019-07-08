using SSLEngine.Abstraction;
using SSLEngine.Abstraction.Commands.Req;
using System;

namespace SSLEngine.Domain
{
    public class ReqCommand : OpenSSLCommand<ReqOptions, ReqInput>
    {
        private readonly ISSLResourceHandler _sslResourceHandler;

        public ReqCommand(ISSLEngineProcessFactory sslEngineProcessFactory, ISSLResourceHandler sslResourceHandler) : base(sslEngineProcessFactory)
        {
            if (sslResourceHandler == null)
                throw new ArgumentNullException(nameof(sslResourceHandler));

            _sslResourceHandler = sslResourceHandler;
        }

        protected override string BuildCommand(ReqOptions options)
        {
            return $"{options} -config {_sslResourceHandler.GetOpenSSLConfigPath()}";
        }
    }
}
