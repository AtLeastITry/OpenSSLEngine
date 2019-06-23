using SSLEngine.Abstraction.Commands.Pkcs12.Properties;
using SSLEngine.Abstraction.Commands.Pkcs12.Types;
using SSLEngine.Abstraction.Commands.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SSLEngine.Abstraction.Commands.Pkcs12
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
        /// The PKCS#12 file (i.e. input file) password source. For more information about the format of arg see the PASS PHRASE ARGUMENTS section in openssl(1).
        /// </summary>
        public string PassIn { get; set; }
        /// <summary>
        /// Pass phrase source to encrypt any outputted private keys with. For more information about the format of arg see the PASS PHRASE ARGUMENTS section in openssl(1).
        /// </summary>
        public string PassOut { get; set; }
        #endregion

        #region Parsing
        /// <summary>
        /// With -export, -password is equivalent to -passout. Otherwise, -password is equivalent to -passin.
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// This option inhibits output of the keys and certificates to the output file version of the PKCS#12 file.
        /// </summary>
        public bool NoOut { get; set; }
        /// <summary>
        /// Only output client certificates (not CA certificates).
        /// </summary>
        public bool ClCerts { get; set; }
        /// <summary>
        /// Only output CA certificates (not client certificates).
        /// </summary>
        public bool CaCerts { get; set; }
        /// <summary>
        /// No certificates at all will be output.
        /// </summary>
        public bool NoCerts { get; set; }
        /// <summary>
        /// No private keys will be output.
        /// </summary>
        public bool NoKeys { get; set; }
        /// <summary>
        /// Output additional information about the PKCS#12 file structure, algorithms used and iteration counts.
        /// </summary>
        public bool Info { get; set; }
        /// <summary>
        /// Use DES to encrypt private keys before outputting.
        /// </summary>
        public bool Des { get; set; }
        /// <summary>
        /// Use triple DES to encrypt private keys before outputting, this is the default.
        /// </summary>
        public bool Des3 { get; set; }
        /// <summary>
        /// Use IDEA to encrypt private keys before outputting.
        /// </summary>
        public bool Idea { get; set; }
        /// <summary>
        /// Use AES to encrypt private keys before outputting.
        /// </summary>
        public AES? AES { get; set; } = default(AES?);
        /// <summary>
        /// Use ARIA to encrypt private keys before outputting.
        /// </summary>
        public ARIA? ARIA { get; set; } = default(ARIA?);
        /// <summary>
        /// Use Camellia to encrypt private keys before outputting.
        /// </summary>
        public Camellia? Camellia { get; set; } = default(Camellia?);
        /// <summary>
        /// Don't encrypt the private keys at all.
        /// </summary>
        public bool Nodes { get; set; }
        /// <summary>
        /// Don't attempt to verify the integrity MAC before reading the file.
        /// </summary>
        public bool NoMACVer { get; set; }
        /// <summary>
        /// Prompt for separate integrity and encryption passwords: most software always assumes these are the same so this option will render such PKCS#12 files unreadable. Cannot be used in combination with the options -password, -passin (if importing) or -passout (if exporting).
        /// </summary>
        public bool TwoPass { get; set; }
        #endregion

        #region File creation
        /// <summary>
        /// This option specifies that a PKCS#12 file will be created rather than parsed.
        /// </summary>
        public bool Export { get; set; }
        /// <summary>
        /// File to read private key from. If not present then a private key must be present in the input file. If no engine is used, the argument is taken as a file; if an engine is specified, the argument is given to the engine as a key identifier.
        /// </summary>
        public string InKey { get; set; }
        /// <summary>
        /// This specifies the "friendly name" for the certificate and private key. This name is typically displayed in list boxes by software importing the file.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// A filename to read additional certificates from.
        /// </summary>
        public string CertFile { get; set; }
        /// <summary>
        /// This specifies the "friendly name" for other certificates. This option may be used multiple times to specify names for all certificates in the order they appear. Netscape ignores friendly names on other certificates whereas MSIE displays them.
        /// </summary>
        public string CaName { get; set; }
        /// <summary>
        /// The PKCS#12 file (i.e. output file) password source. For more information about the format of arg see the PASS PHRASE ARGUMENTS section in openssl(1).
        /// </summary>
        public string Pass { get; set; }
        /// <summary>
        /// If this option is present then an attempt is made to include the entire certificate chain of the user certificate. The standard CA store is used for this search. If the search fails it is considered a fatal error.
        /// </summary>
        public bool Chain { get; set; }
        /// <summary>
        /// Encrypt the certificate using triple DES, this may render the PKCS#12 file unreadable by some "export grade" software. By default the private key is encrypted using triple DES and the certificate using 40 bit RC2.
        /// </summary>
        public bool DesCert { get; set; }
        /// <summary>
        /// These options allow the algorithm used to encrypt the private key and certificates to be selected. Any PKCS#5 v1.5 or PKCS#12 PBE algorithm name can be used (see NOTES section for more information). If a cipher name (as output by the list-cipher-algorithms command is specified then it is used with PKCS#5 v2.0. For interoperability reasons it is advisable to only use PKCS#12 algorithms.
        /// </summary>
        public string KeyPBE { get; set; }
        /// <summary>
        /// These options allow the algorithm used to encrypt the private key and certificates to be selected. Any PKCS#5 v1.5 or PKCS#12 PBE algorithm name can be used (see NOTES section for more information). If a cipher name (as output by the list-cipher-algorithms command is specified then it is used with PKCS#5 v2.0. For interoperability reasons it is advisable to only use PKCS#12 algorithms.
        /// </summary>
        public string CertPBE { get; set; }
        /// <summary>
        /// Specifies that the private key is to be used for key exchange or just signing. This option is only interpreted by MSIE and similar MS software. Normally "export grade" software will only allow 512 bit RSA keys to be used for encryption purposes but arbitrary length keys for signing. The -keysig option marks the key for signing only. Signing only keys can be used for S/MIME signing, authenticode (ActiveX control signing) and SSL client authentication, however due to a bug only MSIE 5.0 and later support the use of signing only keys for SSL client authentication.
        /// </summary>
        public bool KeyEx { get; set; }
        /// <summary>
        /// Specifies that the private key is to be used for key exchange or just signing. This option is only interpreted by MSIE and similar MS software. Normally "export grade" software will only allow 512 bit RSA keys to be used for encryption purposes but arbitrary length keys for signing. The -keysig option marks the key for signing only. Signing only keys can be used for S/MIME signing, authenticode (ActiveX control signing) and SSL client authentication, however due to a bug only MSIE 5.0 and later support the use of signing only keys for SSL client authentication.
        /// </summary>
        public bool KeySig { get; set; }
        /// <summary>
        /// Specify the MAC digest algorithm. If not included them SHA1 will be used.
        /// </summary>
        public string MACAlg { get; set; }
        /// <summary>
        /// These options affect the iteration counts on the MAC and key algorithms. Unless you wish to produce files compatible with MSIE 4.0 you should leave these options alone. To discourage attacks by using large dictionaries of common passwords the algorithm that derives keys from passwords can have an iteration count applied to it: this causes a certain part of the algorithm to be repeated and slows it down. The MAC is used to check the file integrity but since it will normally have the same password as the keys and certificates it could also be attacked.By default both MAC and encryption iteration counts are set to 2048, using these options the MAC and encryption iteration counts can be set to 1, since this reduces the file security you should not use these options unless you really have to.Most software supports both MAC and key iteration counts.MSIE 4.0 doesn't support MAC iteration counts so it needs the -nomaciter option.
        /// </summary>
        public bool NoMACIter { get; set; }
        /// <summary>
        /// These options affect the iteration counts on the MAC and key algorithms. Unless you wish to produce files compatible with MSIE 4.0 you should leave these options alone. To discourage attacks by using large dictionaries of common passwords the algorithm that derives keys from passwords can have an iteration count applied to it: this causes a certain part of the algorithm to be repeated and slows it down. The MAC is used to check the file integrity but since it will normally have the same password as the keys and certificates it could also be attacked.By default both MAC and encryption iteration counts are set to 2048, using these options the MAC and encryption iteration counts can be set to 1, since this reduces the file security you should not use these options unless you really have to.Most software supports both MAC and key iteration counts.MSIE 4.0 doesn't support MAC iteration counts so it needs the -nomaciter option.
        /// </summary>
        public bool NoIter { get; set; }
        /// <summary>
        /// This option is included for compatibility with previous versions, it used to be needed to use MAC iterations counts but they are now used by default.
        /// </summary>
        public bool MACIter { get; set; }
        /// <summary>
        /// Don't attempt to provide the MAC integrity.
        /// </summary>
        public bool NoMAC { get; set; }
        /// <summary>
        /// A file or files containing random data used to seed the random number generator. Multiple files can be specified separated by an OS-dependent character. The separator is ; for MS-Windows, , for OpenVMS, and : for all others.
        /// </summary>
        public string Rand { get; set; }
        /// <summary>
        /// Writes random data to the specified file upon exit. This can be used with a subsequent -rand flag.
        /// </summary>
        public string WriteRand { get; set; }
        /// <summary>
        /// CA storage as a file.
        /// </summary>
        public string CAFile { get; set; }
        /// <summary>
        /// CA storage as a directory. This directory must be a standard certificate directory: that is a hash of each subject name (using x509 -hash) should be linked to each certificate.
        /// </summary>
        public string CAPath { get; set; }
        /// <summary>
        /// Do not load the trusted CA certificates from the default file location.
        /// </summary>
        public bool NoCAFile { get; set; }
        /// <summary>
        /// Do not load the trusted CA certificates from the default directory location.
        /// </summary>
        public bool NoCAPath { get; set; }
        /// <summary>
        /// Write name as a Microsoft CSP name.
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

            foreach (var prop in this)
            {
                sb.Append(prop);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Returns enumerator for options
        /// </summary>
        /// <returns></returns>
        public IEnumerator<ICommandProperty> GetEnumerator()
        {
            yield return new StringProperty(this.In, "-in");
            yield return new StringProperty(this.Out, "-out");
            yield return new StringProperty(this.PassIn, "-passin");
            yield return new StringProperty(this.PassOut, "-passout");
            yield return new StringProperty(this.Password, "-password");
            yield return new BoolProperty(this.NoOut, "-noout");
            yield return new BoolProperty(this.ClCerts, "-clcerts");
            yield return new BoolProperty(this.CaCerts, "-cacerts");
            yield return new BoolProperty(this.NoCerts, "-nocerts");
            yield return new BoolProperty(this.NoKeys, "-nokeys");
            yield return new BoolProperty(this.Info, "-info");
            yield return new BoolProperty(this.Des, "-des");
            yield return new BoolProperty(this.Des3, "-des3");
            yield return new BoolProperty(this.Idea, "-idea");
            yield return new NullableAESProperty(this.AES, "-");
            yield return new NullableARIAProperty(this.ARIA, "-");
            yield return new NullableCamelliaProperty(this.Camellia, "-");
            yield return new BoolProperty(this.Nodes, "-nodes");
            yield return new BoolProperty(this.NoMACVer, "-nomacver");
            yield return new BoolProperty(this.TwoPass, "-twopass");
            yield return new BoolProperty(this.Export, "-export");
            yield return new StringProperty(this.InKey, "-inkey");
            yield return new StringProperty(this.Name, "-name");
            yield return new StringProperty(this.CertFile, "-certfile");
            yield return new StringProperty(this.CaName, "-caname");
            yield return new StringProperty(this.Pass, "-pass");
            yield return new BoolProperty(this.Chain, "-chain");
            yield return new BoolProperty(this.DesCert, "-descert");
            yield return new StringProperty(this.KeyPBE, "-keypbe");
            yield return new StringProperty(this.CertPBE, "-certpbe");
            yield return new BoolProperty(this.KeyEx, "-keyex");
            yield return new BoolProperty(this.KeySig, "-keysig");
            yield return new StringProperty(this.MACAlg, "-macalg");
            yield return new BoolProperty(this.NoMACIter, "-nomaciter");
            yield return new BoolProperty(this.NoIter, "-noiter");
            yield return new BoolProperty(this.MACIter, "-maciter");
            yield return new BoolProperty(this.NoMAC, "-nomac");
            yield return new StringProperty(this.Rand, "-rand");
            yield return new StringProperty(this.WriteRand, "-writerand");
            yield return new StringProperty(this.CAFile, "-CAfile");
            yield return new StringProperty(this.CAPath, "-CApath");
            yield return new BoolProperty(this.NoCAFile, "-no-CAfile");
            yield return new BoolProperty(this.NoCAPath, "-no-CApath");
            yield return new StringProperty(this.CSP, "-CSP");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
