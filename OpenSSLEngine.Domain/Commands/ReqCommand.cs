﻿using OpenSSLEngine.Abstraction.Commands;
using OpenSSLEngine.Abstraction.Commands.Req;

namespace OpenSSLEngine.Domain
{
    public class ReqCommand: OpenSSLCommand<ReqOptions, ReqInput>
    {
        public ReqCommand(IOpenSSLPathProvider openSSLPathProvider) : base(openSSLPathProvider)
        {
        }
    }
}