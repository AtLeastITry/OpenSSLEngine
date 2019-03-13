using System.Threading.Tasks;

namespace OpenSSLEngine.Abstraction.Commands
{
    public interface ICommand<TOptions, TInput>
        where TOptions : ICommandOptions
        where TInput : ICommandInput
    {
        void Execute(TOptions options, TInput input);
        Task ExecuteAsync(TOptions options, TInput input);
    }
}
