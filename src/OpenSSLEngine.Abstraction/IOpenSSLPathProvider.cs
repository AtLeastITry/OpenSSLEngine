namespace OpenSSLEngine.Abstraction
{
    public interface IOpenSSLPathProvider
    {
        string GetOpenSSLStartPath();
        string GetOpenSSLConfigPath();
    }
}
