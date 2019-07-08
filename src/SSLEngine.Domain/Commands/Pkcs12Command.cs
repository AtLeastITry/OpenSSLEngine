using SSLEngine.Abstraction;
using SSLEngine.Abstraction.Commands.Pkcs12;

namespace SSLEngine.Domain
{
    public class Pkcs12Command : OpenSSLCommand<Pkcs12Options, Pkcs12Input>
    {
        public Pkcs12Command(ISSLEngineProcessFactory sslEngineProcessFactory) : base(sslEngineProcessFactory)
        {
        }
    }
}
