namespace OpenSSLEngine.Abstraction
{
    public interface IOpenSSLPathProvider
    {
        string GetOpenSSLStartPath(string tempPath);
        string GetOpenSSLConfigPath(string tempPath);
    }
}
