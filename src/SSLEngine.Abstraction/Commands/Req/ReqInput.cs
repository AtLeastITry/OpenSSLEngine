using System.Collections;
using System.Collections.Generic;

namespace SSLEngine.Abstraction.Commands.Req
{
    public class ReqInput : ICommandInput
    {
        /// <summary>
        /// Country Name (2 letter code)
        /// </summary>
        public string CountryName { get; set; }
        /// <summary>
        /// State or Province Name (full name)
        /// </summary>
        public string StateOrProvinceName { get; set; }
        /// <summary>
        /// Locality Name (eg, city)
        /// </summary>
        public string LocalityName { get; set; }
        /// <summary>
        /// Oganization Name (eg, company)
        /// </summary>
        public string OrganizationName { get; set; }
        /// <summary>
        /// Organizational Unit Name (eg, section)
        /// </summary>
        public string OrganizationalUnitName { get; set; }
        /// <summary>
        /// Common Name (e.g. server FQDN or Your name)
        /// </summary>
        public string CommonName { get; set; }
        /// <summary>
        /// Email Address
        /// </summary>
        public string EmailAddress { get; set; }

        public IEnumerator<string> GetEnumerator()
        {
            yield return CountryName;
            yield return StateOrProvinceName;
            yield return LocalityName;
            yield return OrganizationName;
            yield return OrganizationalUnitName;
            yield return CommonName;
            yield return EmailAddress;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
