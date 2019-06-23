using SSLEngine.Abstraction;
using SSLEngine.Abstraction.Commands.Req;

namespace SSLEngine.Domain
{
    public class ReqCommand : OpenSSLCommand<ReqOptions, ReqInput>
    {
        public ReqCommand(ISSLResourceHandler sslResourceHandler) : base(sslResourceHandler)
        {
        }

        protected override string BuildCommand(ReqOptions options)
        {
            return $"{options} -config {_sslResourceHandler.GetOpenSSLConfigPath()}";
        }
    }
}
