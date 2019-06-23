using SSLEngine.Abstraction.Commands.Pkcs12;
using SSLEngine.Abstraction.Commands.Req;
using System.Threading.Tasks;

namespace SSLEngine.Abstraction
{
    public interface ISSLEngine
    {
        Task ReqAsync(ReqOptions options, ReqInput input);
        void Req(ReqOptions options, ReqInput input);
        Task Pkcs12Async(Pkcs12Options options);
        void Pkcs12(Pkcs12Options options);
    }
}
