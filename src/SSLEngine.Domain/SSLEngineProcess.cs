using SSLEngine.Abstraction;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;

namespace SSLEngine.Domain.Commands
{
    public class SSLEngineProcess : IDisposable
    {
        private readonly Process _process;
        private readonly ISSLResourceHandler _sslResourceHandler;
        private readonly string _filePath;
        private readonly string _processName;
        private static Random _random;
        private static object _lock = new object();

        static SSLEngineProcess()
        {
            _random = new Random();
        }

        public SSLEngineProcess(ISSLResourceHandler sslResourceHandler, bool useParallelExecution)
        {
            _sslResourceHandler = sslResourceHandler;
            _filePath = _sslResourceHandler.GetOpenSSLStartPath();
            _processName = Path.GetFileNameWithoutExtension(_filePath);

            if (!useParallelExecution)
            {
                lock (_lock)
                {
                    WaitForProcessAvailable();
                }
            }

            _sslResourceHandler.Extract();

            var processInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = _sslResourceHandler.GetOpenSSLStartPath()
            };

            _process = Process.Start(processInfo);
        }

        public StreamWriter StandardInput => _process.StandardInput;

        private void WaitForProcessAvailable()
        {
            using (var waitHandle = new AutoResetEvent(false))
            using (var timer = new Timer(
                    callback: (e) => {
                        var currentProcess = Process.GetProcessesByName(_processName);

                        if (!currentProcess.Any())
                        {
                            waitHandle.Set();
                        }
                    },
                    state: null,
                    dueTime: TimeSpan.FromMilliseconds(_random.Next(200, 1000)),
                    period: TimeSpan.FromSeconds(2)
                )
            )
            {
                waitHandle.WaitOne();
            }
        }

        public void Dispose()
        {
            _process.Dispose();
            _sslResourceHandler.Clean();
        }
    }
}
