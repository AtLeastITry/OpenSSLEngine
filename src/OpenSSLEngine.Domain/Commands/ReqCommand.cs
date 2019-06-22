using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Abstraction.Commands.Req;

namespace OpenSSLEngine.Domain
{
    public class ReqCommand : OpenSSLCommand<ReqOptions, ReqInput>
    {
        public ReqCommand(IOpenSSLResourceHandler openSSLResourceHandler) : base(openSSLResourceHandler)
        {
        }

        protected override string BuildCommand(ReqOptions options)
        {
            return $"{options} -config {_openSSLResourceHandler.GetOpenSSLConfigPath()}";
        }
    }
}
