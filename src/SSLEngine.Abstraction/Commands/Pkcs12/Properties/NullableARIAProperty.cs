using SSLEngine.Abstraction.Commands.Pkcs12.Types;

namespace SSLEngine.Abstraction.Commands.Pkcs12.Properties
{
    internal class NullableARIAProperty : CommandProperty<ARIA?>
    {
        public NullableARIAProperty(ARIA? value, string alias) : base(value, alias)
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
