using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands.Pkcs12
{
    /// <summary>
    /// Options for the pkcs12 command.
    /// </summary>
    public class Pkcs12Options : ICommandOptions
    {
        #region Options
        #region Shared
        /// <summary>
        /// This specifies filename of the PKCS#12 file to be parsed. 
        ///  Standard input is used by default.
        /// </summary>
        public string In { get; set; }
        /// <summary>
        /// The filename to write certificates and private keys to, standard output by defaul
        /// They are all written in PEM format.
        /// </summary>
        public string Out { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PassIn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PassOut { get; set; }
        #endregion

        #region Parsing
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoOut { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool ClCerts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool CaCerts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoCerts { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoKeys { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Info { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Des { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Des3 { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Idea { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AES? AES { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        public ARIA? ARIA { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        public Camellia? Camellia { get; set; } = null;
        /// <summary>
        /// 
        /// </summary>
        public bool Nodes { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoMACVer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool TwoPass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        #endregion

        #region File creation
        public bool Export { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string InKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CertFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CaName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Chain { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool DesCert { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KeyPBE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CertPBE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool KeyEx { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool KeySig { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MACAlg { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoMACIter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoIter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool MACIter { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoMAC { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Rand { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CAFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CAPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoCAFile { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool NoCAPath { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string CSP { get; set; }
        #endregion
        #endregion

        #region Implementation of ICommandOptions
        /// <summary>
        /// Returns string that represents the options
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("pkcs12");

            foreach (var (prop, alias) in this)
            {
                sb.Append(Pkcs12OptionFormater.Format((dynamic)prop, alias));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns enumerator for options
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Tuple<object, string>> GetEnumerator()
        {
            yield return new Tuple<object, string>(this.In, "-in");
            yield return new Tuple<object, string>(this.Out, "-out");
            yield return new Tuple<object, string>(this.PassIn, "-passin");
            yield return new Tuple<object, string>(this.PassOut, "-passout");
            yield return new Tuple<object, string>(this.Password, "-password");
            yield return new Tuple<object, string>(this.NoOut, "-noout");
            yield return new Tuple<object, string>(this.ClCerts, "-clcerts");
            yield return new Tuple<object, string>(this.CaCerts, "-cacerts");
            yield return new Tuple<object, string>(this.NoCerts, "-nocerts");
            yield return new Tuple<object, string>(this.NoKeys, "-nokeys");
            yield return new Tuple<object, string>(this.Info, "-info");
            yield return new Tuple<object, string>(this.Des, "-des");
            yield return new Tuple<object, string>(this.Des3, "-des3");
            yield return new Tuple<object, string>(this.Idea, "-idea");
            yield return new Tuple<object, string>(this.AES, "-");
            yield return new Tuple<object, string>(this.ARIA, "-");
            yield return new Tuple<object, string>(this.Camellia, "-");
            yield return new Tuple<object, string>(this.Nodes, "-nodes");
            yield return new Tuple<object, string>(this.NoMACVer, "-nomacver");
            yield return new Tuple<object, string>(this.TwoPass, "-twopass");
            yield return new Tuple<object, string>(this.Export, "-export");
            yield return new Tuple<object, string>(this.InKey, "-inkey");
            yield return new Tuple<object, string>(this.Name, "-name");
            yield return new Tuple<object, string>(this.CertFile, "-certfile");
            yield return new Tuple<object, string>(this.CaName, "-caname");
            yield return new Tuple<object, string>(this.Pass, "-pass");
            yield return new Tuple<object, string>(this.Chain, "-chain");
            yield return new Tuple<object, string>(this.DesCert, "-descert");
            yield return new Tuple<object, string>(this.KeyPBE, "-keypbe");
            yield return new Tuple<object, string>(this.CertPBE, "-certpbe");
            yield return new Tuple<object, string>(this.KeyEx, "-keyex");
            yield return new Tuple<object, string>(this.KeySig, "-keysig");
            yield return new Tuple<object, string>(this.MACAlg, "-macalg");
            yield return new Tuple<object, string>(this.NoMACIter, "-nomaciter");
            yield return new Tuple<object, string>(this.NoIter, "-noiter");
            yield return new Tuple<object, string>(this.MACIter, "-maciter");
            yield return new Tuple<object, string>(this.NoMAC, "-nomac");
            yield return new Tuple<object, string>(this.Rand, "-rand");
            yield return new Tuple<object, string>(this.CAFile, "-CAfile");
            yield return new Tuple<object, string>(this.CAPath, "-CApath");
            yield return new Tuple<object, string>(this.NoCAFile, "-no-CAfile");
            yield return new Tuple<object, string>(this.NoCAPath, "-no-CApath");
            yield return new Tuple<object, string>(this.CSP, "-CSP");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
