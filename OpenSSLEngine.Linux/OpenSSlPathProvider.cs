using OpenSSLEngine.Abstraction.Commands;
using System.IO;
using System.Reflection;

namespace OpenSSLEngine.Linux
{
    internal class OpenSSlPathProvider : IOpenSSLPathProvider
    {
        public string BuildPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\lib\openssl.exe";
        }
    }
}
