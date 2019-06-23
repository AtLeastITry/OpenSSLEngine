using SSLEngine.Abstraction;
using SSLEngine.Abstraction.Commands;
using SSLEngine.Abstraction.Commands.Pkcs12;
using SSLEngine.Abstraction.Commands.Req;
using System;
using System.Threading.Tasks;

namespace SSLEngine.Core
{
    internal class SSLEngine : ISSLEngine
    {
        private readonly ICommand<Pkcs12Options, Pkcs12Input> _pkcsS12Command;
        private readonly ICommand<ReqOptions, ReqInput> _reqCommand;

        public SSLEngine(ICommand<Pkcs12Options, Pkcs12Input> pkcsS12Command, ICommand<ReqOptions, ReqInput> reqCommand)
        {
            if (pkcsS12Command == null)
                throw new ArgumentNullException(nameof(pkcsS12Command));
            if (reqCommand == null)
                throw new ArgumentNullException(nameof(reqCommand));

            _pkcsS12Command = pkcsS12Command;
            _reqCommand = reqCommand;
        }

        public void Pkcs12(Pkcs12Options options)
        {
            _pkcsS12Command.Execute(options, new Pkcs12Input());
        }

        public Task Pkcs12Async(Pkcs12Options options)
        {
            return _pkcsS12Command.ExecuteAsync(options, new Pkcs12Input());
        }

        public void Req(ReqOptions options, ReqInput input)
        {
            _reqCommand.Execute(options, input);
        }

        public Task ReqAsync(ReqOptions options, ReqInput input)
        {
            return _reqCommand.ExecuteAsync(options, input);
        }
    }
}
