using SSLEngine.Abstraction;
using System;
using System.Threading;

namespace SSLEngine.Core
{
    public class SSLEngineFactory
    {
        private static Func<ISSLEngine> _func;

        public static ISSLEngine Create()
        {
            return _func.Invoke();
        }

        internal static void Initialize(Func<ISSLEngine> createFunc)
        {
            _func = createFunc;
        }
    }
}
