using OpenSSLEngine.Abstraction.Commands;
using OpenSSLEngine.Abstraction.Commands.Pkcs12;

namespace OpenSSLEngine.Core.Domain
{
    public class Pkcs12Command : OpenSSLCommand<Pkcs12Options, Pkcs12Input>
    {
        public Pkcs12Command(IOpenSSLPathProvider openSSLPathProvider) : base(openSSLPathProvider)
        {
        }
    }
}
