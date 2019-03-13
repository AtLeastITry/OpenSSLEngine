using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands
{
    public class OptionAliasAttribute : Attribute
    {
        public OptionAliasAttribute(string value)
        {
            this.Value = value;
        }

        public readonly string Value;
    }
}
