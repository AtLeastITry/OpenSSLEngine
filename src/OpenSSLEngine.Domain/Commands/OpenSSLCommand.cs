using OpenSSLEngine.Abstraction;
using OpenSSLEngine.Abstraction.Commands;
using OpenSSLEngine.Domain.Commands;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace OpenSSLEngine.Domain
{
    public class OpenSSLCommand<TOptions, TInput>: ICommand<TOptions, TInput>
        where TOptions : ICommandOptions
        where TInput : ICommandInput
    {
        protected readonly IOpenSSLPathProvider _openSSLPathProvider;
        private readonly IOpenSSLResourceExtractor _openSSLResourceExtractor;

        public OpenSSLCommand(IOpenSSLPathProvider openSSLPathProvider, IOpenSSLResourceExtractor openSSLResourceExtractor)
        {
            if (openSSLPathProvider == null)
                throw new ArgumentNullException(nameof(openSSLPathProvider));
            if (openSSLResourceExtractor == null)
                throw new ArgumentNullException(nameof(openSSLResourceExtractor));

            _openSSLPathProvider = openSSLPathProvider;
            _openSSLResourceExtractor = openSSLResourceExtractor;
        }

        private TempProcess BuildProcess(string path)
        {
            return new TempProcess(path, _openSSLPathProvider, _openSSLResourceExtractor);
        }

        private static Task WaitForUserInputAsync(TempProcess process)
        {
            //while (!CheckProcessThreads(process.Threads));
            Thread.Sleep(1000);

            return Task.CompletedTask;
        }

        private static void WaitForUserInput(TempProcess process)
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
            var tempPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Guid.NewGuid().ToString());

            using (var process = BuildProcess(tempPath))
            {
                process.StandardInput.WriteLine(BuildCommand(tempPath, options));

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
            var tempPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Guid.NewGuid().ToString());

            using (var process = BuildProcess(tempPath))
            {
                process.StandardInput.WriteLine(BuildCommand(tempPath, options));

                foreach (var item in input)
                {
                    await WaitForUserInputAsync(process);
                    process.StandardInput.WriteLine(item);
                }

                await WaitForUserInputAsync(process);
                process.StandardInput.WriteLine("exit");
            }
        }

        protected virtual string BuildCommand(string path, TOptions options)
        {
            return $"{options}";
        }
    }
}
