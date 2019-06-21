using OpenSSLEngine.Abstraction;
using System.IO;
using System.Reflection;

namespace OpenSSLEngine.Windows
{
    internal class OpenSSLResourceExtractor : IOpenSSLResourceExtractor
    {
        private const string _resourcePrefix = "OpenSSLEngine.Windows.lib.";
        private string _libDirectory;
        private string _cnfDirectory => $"{_libDirectory}\\cnf\\";
        private string _pemDirecotry => $"{_libDirectory}\\PEM\\";
        private string _demoDirecotry => $"{_pemDirecotry}\\demoSRP\\";

        public OpenSSLResourceExtractor()
        {
        }

        public void Extract(string tempPath)
        {
            _libDirectory = $"{tempPath}\\lib\\";

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
    }
}
