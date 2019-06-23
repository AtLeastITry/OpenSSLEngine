using System;

namespace SSLEngine.Windows
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
