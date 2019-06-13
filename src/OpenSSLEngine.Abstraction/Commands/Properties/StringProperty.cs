using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands.Properties
{
    internal class StringProperty : CommandProperty<string>
    {
        public StringProperty(string value, string alias) : base(value, alias)
        {
        }

        public override string ToString()
        {
            if (string.IsNullOrEmpty(Value))
                return "";

            return $" {Alias} {Value}";
        }
    }
}
