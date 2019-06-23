using SSLEngine.Abstraction.Commands.Req.Types;

namespace SSLEngine.Abstraction.Commands.Req.Properties
{
    internal class NullableFormProperty : CommandProperty<Form?>
    {
        public NullableFormProperty(Form? value, string alias) : base(value, alias)
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
