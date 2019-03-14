using OpenSSLEngine.Abstraction.Commands;
using System.IO;
using System.Reflection;

namespace OpenSSLEngine.Linux
{
    internal class OpenSSlPathProvider : IOpenSSLPathProvider
    {
        public string GetOpenSSLConfigPath()
        {
            throw new System.NotImplementedException();
        }

        public string GetOpenSSLStartPath()
        {
            throw new System.NotImplementedException();
        }
    }
}
