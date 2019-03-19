using OpenSSLEngine.Abstraction;
using System.IO;
using System.Reflection;

namespace OpenSSLEngine.Windows
{
    internal class OpenSSlPathProvider : IOpenSSLPathProvider
    {
        public string BuildOpenSSLConfigPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\lib\openssl.cfg";
        }

        public string BuildOpenSSLStartPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\lib\openssl.exe";
        }
    }
}
