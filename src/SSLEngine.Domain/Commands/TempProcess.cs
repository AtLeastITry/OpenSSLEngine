using SSLEngine.Abstraction;
using System;
using System.Diagnostics;
using System.IO;

namespace SSLEngine.Domain.Commands
{
    internal class TempProcess : IDisposable
    {
        private readonly Process _process;
        private readonly ISSLResourceHandler _sslResourceHandler;

        public TempProcess(ISSLResourceHandler sslResourceHandler)
        {
            _sslResourceHandler = sslResourceHandler;

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

        public void Dispose()
        {
            _process.Dispose();

            _sslResourceHandler.Clean();
        }
    }
}
