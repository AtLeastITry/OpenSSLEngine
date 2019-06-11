using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Abstraction.Commands.Req;

namespace OpenSSLEngine.Domain
{
    public class ReqCommand : OpenSSLCommand<ReqOptions, ReqInput>
    {
        public ReqCommand(IOpenSSLPathProvider openSSLPathProvider, IOpenSSLResourceExtractor openSSLResourceExtractor) : base(openSSLPathProvider, openSSLResourceExtractor)
        {
        }
    }
}
