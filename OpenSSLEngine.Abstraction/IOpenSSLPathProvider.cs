namespace OpenSSLEngine.Abstraction.Commands
{
    public interface IOpenSSLPathProvider
    {
        string GetOpenSSLStartPath();
        string GetOpenSSLConfigPath();
    }
}
