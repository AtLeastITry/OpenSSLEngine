using OpenSSLEngine.Abstraction.Commands.Pkcs12;
using OpenSSLEngine.Abstraction.Commands.Req;
using System.Threading.Tasks;

namespace OpenSSLEngine.Abstraction
{
    public interface IOpenSSLEngine
    {
        Task ReqAsync(ReqOptions options, ReqInput input);
        void Req(ReqOptions options, ReqInput input);
        Task Pkcs12Async(Pkcs12Options options);
        void Pkcs12(Pkcs12Options options);
    }
}
