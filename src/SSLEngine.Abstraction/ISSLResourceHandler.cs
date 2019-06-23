namespace SSLEngine.Abstraction
{
    public interface ISSLResourceHandler
    {
        void Clean();
        void Extract();
        string GetOpenSSLStartPath();
        string GetOpenSSLConfigPath();
    }
}
