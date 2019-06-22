using System;

namespace OpenSSLEngine.Windows
{
    public class ResourcesNotExtractedException : Exception
    {
        public ResourcesNotExtractedException()
        {
        }

        public ResourcesNotExtractedException(string message) : base(message)
        {
        }
    }
}
