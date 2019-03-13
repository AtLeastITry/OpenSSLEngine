using OpenSSLEngine.Abstraction.Commands;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSSLEngine.Core.Domain
{
    public class OpenSSLCommand<TOptions, TInput>: ICommand<TOptions, TInput>
        where TOptions : ICommandOptions
        where TInput : ICommandInput
    {
        private readonly IOpenSSLPathProvider _openSSLPathProvider;

        public OpenSSLCommand(IOpenSSLPathProvider openSSLPathProvider)
        {
            if (openSSLPathProvider == null)
                throw new ArgumentNullException(nameof(openSSLPathProvider));

            _openSSLPathProvider = openSSLPathProvider;
        }

        public Process BuildProcess()
        {
            var process = new Process();
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.ErrorDialog = false;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = _openSSLPathProvider.BuildPath();
            return process;
        }

        private void internalExecute(TOptions options, TInput input)
        {
            using (var process = this.BuildProcess())
            {
                process.Start();

                process.StandardInput.WriteLine($"req {options.BuildArguments()}");

                Thread.Sleep(1000);

                foreach (var item in input)
                {
                    process.StandardInput.WriteLine(item);
                }

                process.StandardInput.WriteLine("exit");
            }
        }

        public void Execute(TOptions options, TInput input)
        {
            this.internalExecute(options, input);
        }

        public Task ExecuteAsync(TOptions options, TInput input)
        {
            this.internalExecute(options, input);

            return Task.CompletedTask;
        }
    }
}
