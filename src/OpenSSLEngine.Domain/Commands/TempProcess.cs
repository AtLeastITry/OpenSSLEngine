using OpenSSLEngine.Abstraction;
using System;
using System.Diagnostics;
using System.IO;

namespace OpenSSLEngine.Domain.Commands
{
    internal class TempProcess : IDisposable
    {
        private readonly Process _process;
        private readonly string _path;

        public TempProcess(string path, IOpenSSLPathProvider openSSLPathProvider, IOpenSSLResourceExtractor openSSLResourceExtractor)
        {
            _path = path;

            Directory.CreateDirectory(_path);

            openSSLResourceExtractor.Extract(_path);

            var processInfo = new ProcessStartInfo()
            {
                CreateNoWindow = true,
                ErrorDialog = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                FileName = openSSLPathProvider.GetOpenSSLStartPath(_path)
            };

            _process = Process.Start(processInfo);
        }

        public StreamWriter StandardInput => _process.StandardInput;

        public void Dispose()
        {
            _process.Dispose();

            Directory.Delete(_path, true);
        }
    }
}
