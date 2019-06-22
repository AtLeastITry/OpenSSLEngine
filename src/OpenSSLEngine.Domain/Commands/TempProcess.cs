using OpenSSLEngine.Abstraction;
using System;
using System.Diagnostics;
using System.IO;

namespace OpenSSLEngine.Domain.Commands
{
    internal class TempProcess : IDisposable
    {
        private readonly Process _process;
        private readonly IOpenSSLResourceHandler _openSSLResourceHandler;

        public TempProcess(IOpenSSLResourceHandler openSSLResourceHandler)
        {
            _openSSLResourceHandler = openSSLResourceHandler;

            _openSSLResourceHandler.Extract();

            var processInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = _openSSLResourceHandler.GetOpenSSLStartPath()
            };

            _process = Process.Start(processInfo);
        }

        public StreamWriter StandardInput => _process.StandardInput;

        public void Dispose()
        {
            _process.Dispose();

            _openSSLResourceHandler.Clean();
        }
    }
}
