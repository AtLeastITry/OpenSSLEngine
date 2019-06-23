using System;
using System.Collections.Generic;
using System.Text;

namespace SSLEngine.Abstraction.Commands.Properties
{
    internal class IntProperty : CommandProperty<int>
    {
        public IntProperty(int value, string alias) : base(value, alias)
        {
        }

        public override string ToString()
        {
            return $" {Alias} {Value}";
        }
    }
}
