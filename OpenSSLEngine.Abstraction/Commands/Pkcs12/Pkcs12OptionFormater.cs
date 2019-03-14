using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands.Pkcs12
{
    internal class Pkcs12OptionFormater : CommandOptionFormatter
    {
        public static string Format(AES? value, string alias)
        {
            if (!value.HasValue)
                return "";

            return Format(value.Value, alias);
        }

        public static string Format(AES value, string alias)
        {
            return $" {alias} {value}";
        }

        public static string Format(ARIA? value, string alias)
        {
            if (!value.HasValue)
                return "";

            return Format(value.Value, alias);
        }

        public static string Format(ARIA value, string alias)
        {
            return $" {alias} {value}";
        }

        public static string Format(Camellia? value, string alias)
        {
            if (!value.HasValue)
                return "";

            return Format(value.Value, alias);
        }

        public static string Format(Camellia value, string alias)
        {
            return $" {alias} {value}";
        }
    }
}
