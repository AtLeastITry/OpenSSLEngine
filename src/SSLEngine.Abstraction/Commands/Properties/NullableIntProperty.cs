using System;
using System.Collections.Generic;
using System.Text;

namespace SSLEngine.Abstraction.Commands.Properties
{
    internal class NullableIntProperty : CommandProperty<int?>
    {
        public NullableIntProperty(int? value, string alias) : base(value, alias)
        {
        }

        public override string ToString()
        {
            if (!Value.HasValue)
                return "";

            return $" {Alias} {Value}";
        }
    }
}
