using System;

namespace SSLEngine.Abstraction.Commands
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
