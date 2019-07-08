using SSLEngine.Abstraction.Commands;
using SSLEngine.Domain.Commands;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SSLEngine.Domain
{
    public class OpenSSLCommand<TOptions, TInput>: ICommand<TOptions, TInput>
        where TOptions : ICommandOptions
        where TInput : ICommandInput
    {
        private readonly ISSLEngineProcessFactory _sslEngineProcessFactory;

        public OpenSSLCommand(ISSLEngineProcessFactory sslEngineProcessFactory)
        {
            if (sslEngineProcessFactory == null)
                throw new ArgumentNullException(nameof(sslEngineProcessFactory));

            _sslEngineProcessFactory = sslEngineProcessFactory;
        }

        private static Task WaitForUserInputAsync(SSLEngineProcess process)
        {
            //while (!CheckProcessThreads(process.Threads));
            Thread.Sleep(1000);

            return Task.CompletedTask;
        }

        private static void WaitForUserInput(SSLEngineProcess process)
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
            using (var process = _sslEngineProcessFactory.Create())
            {
                process.StandardInput.WriteLine(BuildCommand(options));

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
            using (var process = _sslEngineProcessFactory.Create())
            {
                process.StandardInput.WriteLine(BuildCommand(options));

                foreach (var item in input)
                {
                    await WaitForUserInputAsync(process);
                    process.StandardInput.WriteLine(item);
                }

                await WaitForUserInputAsync(process);
                process.StandardInput.WriteLine("exit");
            }
        }

        protected virtual string BuildCommand(TOptions options)
        {
            return $"{options}";
        }
    }
}
