using OpenSSLEngine.Abstraction;

namespace OpenSSLEngine.Windows
{
    internal class OpenSSlPathProvider : IOpenSSLPathProvider
    {
        public string GetOpenSSLConfigPath(string path)
        {
            return $@"{path}\lib\openssl.cfg";
        }

        public string GetOpenSSLStartPath(string path)
        {
            return $@"{path}\lib\openssl.exe";
        }
    }
}
