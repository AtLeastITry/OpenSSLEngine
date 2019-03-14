using OpenSSLEngine.Abstraction.Commands;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OpenSSLEngine.Domain
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
            process.StartInfo.FileName = _openSSLPathProvider.BuildOpenSSLStartPath();
            return process;
        }

        private static Task WaitForUserInputAsync(Process process)
        {
            while (!CheckProcessThreads(process.Threads));

            return Task.CompletedTask;
        }

        private static void WaitForUserInput(Process process)
        {
            while (!CheckProcessThreads(process.Threads)) ;

            return;
        }

        private static bool CheckProcessThreads(ProcessThreadCollection threads)
        {
            foreach(ProcessThread thread in threads)
            {
                if (thread.ThreadState == ThreadState.Wait && (thread.WaitReason == ThreadWaitReason.UserRequest || thread.WaitReason == ThreadWaitReason.LpcReply))
                {
                    return true;
                }
            }

            return false;
        }

        public void Execute(TOptions options, TInput input)
        {
            using (var process = this.BuildProcess())
            {
                process.Start();
                process.StandardInput.WriteLine($"{options.BuildArguments()} -config {_openSSLPathProvider.BuildOpenSSLConfigPath()}");
                process.StandardInput.WriteLine($"req {options.BuildArguments()}");

                foreach (var item in input)
                {
                    WaitForUserInput(process);
                    process.StandardInput.WriteLine(item);
                }

                WaitForUserInput(process);
                process.StandardInput.WriteLine("exit");
            }
        }

        public async Task ExecuteAsync(TOptions options, TInput input)
        {
            using (var process = this.BuildProcess())
            {
                process.Start();

                process.StandardInput.WriteLine($"{options.BuildArguments()} -config {_openSSLPathProvider.BuildOpenSSLConfigPath()}");

                foreach (var item in input)
                {
                    await WaitForUserInputAsync(process);
                    process.StandardInput.WriteLine(item);
                }

                await WaitForUserInputAsync(process);
                process.StandardInput.WriteLine("exit");
            }
        }
    }
}
