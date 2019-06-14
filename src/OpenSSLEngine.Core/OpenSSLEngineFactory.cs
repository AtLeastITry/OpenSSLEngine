﻿using OpenSSLEngine.Abstraction;
using System;
using System.Threading;

namespace OpenSSLEngine.Core
{
    public class OpenSSLEngineFactory
    {
        private static Lazy<IOpenSSLEngine> _func;

        public static IOpenSSLEngine Create()
        {
            return _func.Value;
        }

        internal static void Initialize(Func<IOpenSSLEngine> createFunc)
        {
            _func = new Lazy<IOpenSSLEngine>(createFunc, LazyThreadSafetyMode.ExecutionAndPublication);
        }
    }
}