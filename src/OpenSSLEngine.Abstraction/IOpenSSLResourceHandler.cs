namespace OpenSSLEngine.Abstraction
{
    public interface IOpenSSLResourceHandler
    {
        void Clean();
        void Extract();
        string GetOpenSSLStartPath();
        string GetOpenSSLConfigPath();
    }
}
