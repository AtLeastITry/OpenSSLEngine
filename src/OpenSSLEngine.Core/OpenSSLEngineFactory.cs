using OpenSSLEngine.Abstraction;
using System;
using System.Threading;

namespace OpenSSLEngine.Core
{
    public class OpenSSLEngineFactory
    {
        private static Func<IOpenSSLEngine> _func;

        public static IOpenSSLEngine Create()
        {
            return _func.Invoke();
        }

        internal static void Initialize(Func<IOpenSSLEngine> createFunc)
        {
            _func = createFunc;
        }
    }
}
