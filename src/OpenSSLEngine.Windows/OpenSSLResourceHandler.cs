using Microsoft.Extensions.Options;
using OpenSSLEngine.Abstraction;
using System;
using System.IO;
using System.Reflection;

namespace OpenSSLEngine.Windows
{
    internal class OpenSSLResourceHandler : IOpenSSLResourceHandler
    {
        private const string _resourcePrefix = "OpenSSLEngine.Windows.lib.";
        private string _path;
        private string _libDirectory => $"{_path}\\lib\\";
        private string _cnfDirectory => $"{_libDirectory}\\cnf\\";
        private string _pemDirecotry => $"{_libDirectory}\\PEM\\";
        private string _demoDirecotry => $"{_pemDirecotry}\\demoSRP\\";
        private bool _extracted;
        private OpenSSLEngineOptions _options;

        public OpenSSLResourceHandler(IOptions<OpenSSLEngineOptions> options)
        {
            if (options == null)
                throw new ArgumentNullException(nameof(options));

            _options = options.Value;

            if (!_options.EnableParallelExecution)
                _path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
        public string GetOpenSSLConfigPath()
        {
            if (!_extracted)
                throw new ResourcesNotExtractedException();

            return $@"{_path}\lib\openssl.cfg";
        }

        public string GetOpenSSLStartPath()
        {
            if (!_extracted)
                throw new ResourcesNotExtractedException();

            return $@"{_path}\lib\openssl.exe";
        }

        public void Extract()
        {
            if (_options.EnableParallelExecution)
                _path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), Guid.NewGuid().ToString());

            if (_options.EnableParallelExecution || !_extracted)
            {
                Directory.CreateDirectory(_libDirectory);
                Directory.CreateDirectory(_cnfDirectory);
                Directory.CreateDirectory(_pemDirecotry);
                Directory.CreateDirectory(_demoDirecotry);

                var assembly = Assembly.GetAssembly(typeof(ServiceCollectionExtensions));

                foreach (var resource in assembly.GetManifestResourceNames())
                {
                    Stream stream = assembly.GetManifestResourceStream(resource);
                    byte[] bytes = new byte[(int)stream.Length];
                    stream.Read(bytes, 0, bytes.Length);
                    File.WriteAllBytes(BuildPath(resource), bytes);
                }

                _extracted = true;
            }
        }

        private string BuildPath(string resourceName)
        {
            resourceName = resourceName.Replace(_resourcePrefix, "");

            if (resourceName.Contains("cnf"))
            {
                return $"{_cnfDirectory}{resourceName.Replace("cnf.", "")}";
            }

            if (resourceName.Contains("demoSRP"))
            {
                return $"{_demoDirecotry}{resourceName.Replace("PEM.demoSRP.", "")}";
            }

            if (resourceName.Contains("PEM"))
            {
                return $"{_pemDirecotry}{resourceName.Replace("PEM.", "")}";
            }

            return $"{_libDirectory}{resourceName}";
        }

        public void Clean()
        {
            if (_options.EnableParallelExecution)
                Directory.Delete(_path, true);
        }
    }
}
