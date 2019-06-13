using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands.Properties
{
    internal class BoolProperty : CommandProperty<bool>
    {
        public BoolProperty(bool value, string alias) : base(value, alias)
        {
        }

        public override string ToString()
        {
            if (!Value)
                return "";

            return $" {Alias}";
        }
    }
}
