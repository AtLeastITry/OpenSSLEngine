using SSLEngine.Domain.Commands;

namespace SSLEngine.Domain
{
    public interface ISSLEngineProcessFactory
    {
        SSLEngineProcess Create();
    }
}
