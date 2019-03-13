using System;
using System.Linq;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands.Pkcs12
{
    public class Pkcs12Options : ICommandOptions
    {
        #region Shared options
        /// <summary>
        /// This specifies filename of the PKCS#12 file to be parsed. 
        ///  Standard input is used by default.
        /// </summary>
        [OptionAlias("-in")]
        public string In { get; set; }
        /// <summary>
        /// The filename to write certificates and private keys to, standard output by defaul
        /// They are all written in PEM format.
        /// </summary>
        [OptionAlias("-out")]
        public string Out { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-passin")]
        public string PassIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-passout")]
        public string PassOut { get; set; }
        #endregion

        #region Parsing options
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-password")]
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-noout")]
        public bool NoOut { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-clcerts")]
        public bool ClCerts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-cacerts")]
        public bool CaCerts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-nocerts")]
        public bool NoCerts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-nokeys")]
        public bool NoKeys { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-info")]
        public bool Info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-des")]
        public bool Des { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-des3")]
        public bool Des3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-idea")]
        public bool Idea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-")]
        public AES? AES { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-")]
        public ARIA? ARIA { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-")]
        public Camellia? Camellia { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-nodes")]
        public bool Nodes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-nomacver")]
        public bool NoMACVer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-twopass")]
        public bool TwoPass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        #endregion

        #region File creation options
        [OptionAlias("-export")]
        public bool Export { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-inkey")]
        public string InKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-name")]
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-certfile")]
        public string CertFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-caname")]
        public string CaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-pass")]
        public string Pass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-chain")]
        public bool Chain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-descert")]
        public bool DesCert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-keypbe")]
        public string KeyPBE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-certpbe")]
        public string CertPBE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-keyex")]
        public bool KeyEx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-keysig")]
        public bool KeySig { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-macalg")]
        public string MACAlg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-nomaciter")]
        public bool NoMACIter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-noiter")]
        public bool NoIter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-maciter")]
        public bool MACIter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-nomac")]
        public bool NoMAC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-rand")]
        public string Rand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-CAfile")]
        public string CAFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-CApath")]
        public string CAPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-no-CAfile")]
        public bool NoCAFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-no-CApath")]
        public bool NoCAPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [OptionAlias("-CSP")]
        public string CSP { get; set; }
        #endregion
        public string BuildArguments()
        {
            var sb = new StringBuilder();
            sb.Append("pkcs12 ");
            foreach (var prop in typeof(Pkcs12Options).GetProperties())
            {
                OptionAliasAttribute alias = (OptionAliasAttribute)prop.GetCustomAttributes(true).First(a => a.GetType() == typeof(OptionAliasAttribute));

                if (prop.PropertyType == typeof(bool))
                {
                    if ((bool)prop.GetValue(this))
                    {
                        sb.Append(" ");
                        sb.Append(alias.Value);
                    }
                }
                else if (prop.PropertyType == typeof(string))
                {
                    var val = (string)prop.GetValue(this);
                    if (!string.IsNullOrEmpty(val))
                    {
                        sb.Append(" ");
                        sb.Append(alias.Value);
                        sb.Append(" ");
                        sb.Append(val);
                    }
                }
                else if (prop.PropertyType == typeof(AES?))
                {
                    var val = (AES?)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        sb.Append(" ");
                        sb.Append(alias.Value);
                        sb.Append(val.ToString());
                    }
                }
                else if (prop.PropertyType == typeof(ARIA?))
                {
                    var val = (ARIA?)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        sb.Append(" ");
                        sb.Append(alias.Value);
                        sb.Append(val.ToString());
                    }
                }
                else if (prop.PropertyType == typeof(Camellia?))
                {
                    var val = (Camellia?)prop.GetValue(this);
                    if (val.HasValue)
                    {
                        sb.Append(" ");
                        sb.Append(alias.Value);
                        sb.Append(val.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}
