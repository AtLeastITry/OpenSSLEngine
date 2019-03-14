using OpenSSLEngine.Abstraction.Commands;
using System;
using System.Diagnostics;
using System.Threading;
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

        private ProcessStartInfo BuildProcessInfo()
        {
            return new ProcessStartInfo()
            {
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = _openSSLPathProvider.GetOpenSSLStartPath()
            };
        }

        private static Task WaitForUserInputAsync(Process process)
        {
            //while (!CheckProcessThreads(process.Threads));
            Thread.Sleep(1000);

            return Task.CompletedTask;
        }

        private static void WaitForUserInput(Process process)
        {
            //while (!CheckProcessThreads(process.Threads)) ;
            Thread.Sleep(1000);

            return;
        }

        private static bool CheckProcessThreads(ProcessThreadCollection threads)
        {
            foreach(ProcessThread thread in threads)
            {
                if (thread.ThreadState == System.Diagnostics.ThreadState.Wait && (thread.WaitReason == ThreadWaitReason.UserRequest || thread.WaitReason == ThreadWaitReason.LpcReply))
                {
                    return true;
                }
            }

            return false;
        }

        public void Execute(TOptions options, TInput input)
        {
            using (var process = Process.Start(this.BuildProcessInfo()))
            {
                process.StandardInput.WriteLine($"{options} -config {_openSSLPathProvider.GetOpenSSLConfigPath()}");

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
            using (var process = Process.Start(this.BuildProcessInfo()))
            {
                process.StandardInput.WriteLine($"{options} -config {_openSSLPathProvider.GetOpenSSLConfigPath()}");

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
