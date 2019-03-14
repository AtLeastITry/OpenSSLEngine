namespace OpenSSLEngine.Abstraction.Commands
{
    public interface IOpenSSLPathProvider
    {
        string BuildOpenSSLStartPath();
        string BuildOpenSSLConfigPath();
    }
}
