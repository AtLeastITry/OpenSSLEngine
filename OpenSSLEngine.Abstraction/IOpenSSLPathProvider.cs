namespace OpenSSLEngine.Abstraction
{
    public interface IOpenSSLPathProvider
    {
        string BuildOpenSSLStartPath();
        string BuildOpenSSLConfigPath();
    }
}
