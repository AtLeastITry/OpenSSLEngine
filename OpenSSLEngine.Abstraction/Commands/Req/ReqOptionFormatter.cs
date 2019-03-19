using System;
using System.Collections.Generic;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands.Req
{
    internal class ReqOptionFormatter : CommandOptionFormatter
    {
        public static string Format(Form? value, string alias)
        {
            if (!value.HasValue)
                return "";

            return Format(value.Value, alias);
        }

        public static string Format(Form value, string alias)
        {
            return $" {alias} {value}";
        }
    }
}
