namespace OpenSSLEngine.Abstraction
{
    internal class CommandOptionFormatter
    {
        public static string Format(bool? value, string alias)
        {
            if (!value.HasValue)
                return "";

            return Format(value.Value, alias);
        }

        public static string Format(bool value, string alias)
        {
            if (!value)
                return "";

            return $" {alias}";
        }

        public static string Format(string value, string alias)
        {
            if (string.IsNullOrEmpty(value))
                return "";

            return $" {alias} {value}";
        }

        public static string Format(int? value, string alias)
        {
            if (!value.HasValue)
                return "";

            return Format(value.Value, alias);
        }

        public static string Format(int value, string alias)
        {
            return $" {alias} {value}";
        }
    }
}
