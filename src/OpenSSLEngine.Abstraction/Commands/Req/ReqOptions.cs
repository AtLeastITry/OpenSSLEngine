using OpenSSLEngine.Abstraction.Commands.Properties;
using OpenSSLEngine.Abstraction.Commands.Req.Properties;
using OpenSSLEngine.Abstraction.Commands.Req.Types;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenSSLEngine.Abstraction.Commands.Req
{
    /// <summary>
    /// Options for the req command.
    /// </summary>
    public class ReqOptions: ICommandOptions
    {
        #region Options
        /// <summary>
        /// This specifies the input format. 
        /// The DER option uses an ASN1 DER encoded form compatible with the PKCS#10. 
        /// The PEM form is the default format: it consists of the DER format base64 encoded with additional header and footer lines
        /// </summary>
        public Form? InForm { get; set; } = null;
        /// <summary>
        /// This specifies the output format, the options have the same meaning as the -inform option.
        /// </summary>
        public Form? OutForm { get; set; } = null;
        /// <summary>
        /// This specifies the input filename to read a request from or standard input if this option is not specified. 
        /// A request is only read if the creation options (-new and -newkey) are not specified.
        /// </summary>
        public string In { get; set; }
        /// <summary>
        /// The input file password source. 
        /// For more information about the format of arg see the PASS PHRASE ARGUMENTS section in <see href="https://www.openssl.org/docs/man1.0.2/man1/openssl.htmlm">openssl(1)</see>.
        /// </summary>
        public string PassIn { get; set; }
        /// <summary>
        /// This specifies the output filename to write to or standard output by default.
        /// </summary>
        public string Out { get; set; }
        /// <summary>
        /// The output file password source. For more information about the format of arg see the PASS PHRASE ARGUMENTS section in <see href="https://www.openssl.org/docs/man1.0.2/man1/openssl.htmlm">openssl(1)</see>.
        /// </summary>
        public string PassOut { get; set; }
        /// <summary>
        /// prints out the certificate request in text form.
        /// </summary>
        public bool Text { get; set; }
        /// <summary>
        /// Prints out the request subject (or certificate subject if -x509 is specified)
        /// </summary>
        public bool Subject { get; set; }
        /// <summary>
        /// Outputs the public key.
        /// </summary>
        public bool PubKey { get; set; }
        /// <summary>
        /// This option prevents output of the encoded version of the request.
        /// </summary>
        public bool NoOut { get; set; }
        /// <summary>
        /// This option prints out the value of the modulus of the public key contained in the request.
        /// </summary>
        public bool Modulus { get; set; }
        /// <summary>
        /// Verifies the signature on the request.
        /// </summary>
        public bool Verify { get; set; }
        /// <summary>
        /// this option generates a new certificate request. 
        /// It will prompt the user for the relevant field values. 
        /// The actual fields prompted for and their maximum and minimum sizes are specified in the configuration file and any requested extensions.
        /// 
        ///If the -key option is not used it will generate a new RSA private key using information specified in the configuration file.
        /// </summary>
        public bool New { get; set; }
        /// <summary>
        /// Replaces subject field of input request with specified data and outputs modified request. 
        /// The arg must be formatted as /type0=value0/type1=value1/type2=..., characters may be escaped by \ (backslash), no spaces are skipped.
        /// </summary>
        public string Subj { get; set; }
        /// <summary>
        /// a file or files containing random data used to seed the random number generator, or an EGD socket (see RAND_egd(3)). 
        /// Multiple files can be specified separated by a OS-dependent character. The separator is ; for MS-Windows, , for OpenVMS, and : for all others.
        /// </summary>
        public string Rand { get; set; }
        /// <summary>
        /// Writes random data to the specified file upon exit. 
        /// This can be used with a subsequent -rand flag.
        /// </summary>
        public string WriteRand { get; set; }
        /// <summary>
        /// this option creates a new certificate request and a new private key. The argument takes one of several forms. rsa:nbits, where nbits is the number of bits, generates an RSA key nbits in size. If nbits is omitted, i.e. -newkey rsa specified, the default key size, specified in the configuration file is used.
        ///
        ///All other algorithms support the -newkey alg:file form, where file may be an algorithm parameter file, created by the genpkey -genparam command or and X.509 certificate for a key with approriate algorithm.
        ///
        ///param:file generates a key using the parameter file or certificate file, the algorithm is determined by the parameters.algname:file use algorithm algname and parameter file file: the two algorithms must match or an error occurs.algname just uses algorithm algname, and parameters, if neccessary should be specified via -pkeyopt parameter.
        ///
        ///dsa:filename generates a DSA key using the parameters in the file filename.ec:filename generates EC key(usable both with ECDSA or ECDH algorithms), gost2001:filename generates GOST R 34.10-2001 key(requires ccgost engine configured in the configuration file). If just gost2001 is specified a parameter set should be specified by -pkeyopt paramset:X
        /// </summary>
        public string NewKey { get; set; }
        /// <summary>
        /// set the public key algorithm option opt to value. 
        /// The precise set of options supported depends on the public key algorithm used and its implementation. See KEY GENERATION OPTIONS in the genpkey manual page for more details.
        /// </summary>
        public string PKeyOpt { get; set; }
        /// <summary>
        /// This specifies the file to read the private key from. It also accepts PKCS#8 format private keys for PEM format files.
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// the format of the private key file specified in the -key argument. PEM is the default.
        /// </summary>
        public Form? KeyForm { get; set; } = null;
        /// <summary>
        /// this gives the filename to write the newly created private key to. If this option is not specified then the filename present in the configuration file is used.
        /// </summary>
        public string KeyOut { get; set; }
        /// <summary>
        /// if this option is specified then if a private key is created it will not be encrypted.
        /// </summary>
        public bool Nodes { get; set; }
        /// <summary>
        /// this specifies the message digest to sign the request with (such as -md5, -sha1). This overrides the digest algorithm specified in the configuration file.
        ///
        ///Some public key algorithms may override this choice.For instance, DSA signatures always use SHA1, GOST R 34.10 signatures always use GOST R 34.11-94 (-md_gost94).
        /// </summary>
        public bool Digest { get; set; }
        /// <summary>
        /// this allows an alternative configuration file to be specified, this overrides the compile time filename or any specified in the OPENSSL_CONF environment variable.
        /// </summary>
        public string Config { get; set; }
        /// <summary>
        /// this option causes the -subj argument to be interpreted with full support for multivalued RDNs. Example:
        ///
        /// /DC=org/DC=OpenSSL/DC=users/UID=123456+CN=John Doe
        ///
        /// If -multi-rdn is not used then the UID value is 123456+CN=John Doe.
        /// </summary>
        public bool MultiValueRdn { get; set; }
        /// <summary>
        /// this option outputs a self signed certificate instead of a certificate request. This is typically used to generate a test certificate or a self signed root CA. The extensions added to the certificate (if any) are specified in the configuration file. Unless specified using the set_serial option, a large random number will be used for the serial number.
        ///
        /// If existing request is specified with the -in option, it is converted to the self signed certificate otherwise new request is created.
        /// </summary>
        public bool X509 { get; set; }
        /// <summary>
        /// when the -x509 option is being used this specifies the number of days to certify the certificate for. The default is 30 days.
        /// </summary>
        public int Days { get; set; } = 30;
        /// <summary>
        /// serial number to use when outputting a self signed certificate. This may be specified as a decimal value or a hex value if preceded by 0x. It is possible to use negative serial numbers but this is not recommended.
        /// </summary>
        public int? SetSerial { get; set; }
        /// <summary>
        /// Add a specific extension to the certificate(if the -x509 option is present) or certificate request.
        /// The argument must have the form of a key=value pair as it would appear in a config file.
        /// 
        /// This option can be given multiple times.
        /// </summary>
        public int? AddExt { get; set; }
        #endregion

        #region Implementation of ICommandOptions
        /// <summary>
        /// Returns string that represents the options
        /// </summary>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("req");

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
            yield return new NullableFormProperty(this.InForm, "-inform");
            yield return new NullableFormProperty(this.OutForm, "-outform");
            yield return new StringProperty(this.In, "-in");
            yield return new StringProperty(this.PassIn, "-passin");
            yield return new StringProperty(this.Out, "-out");
            yield return new StringProperty(this.PassOut, "-passout");
            yield return new BoolProperty(this.Text, "-text");
            yield return new BoolProperty(this.Subject, "-subject");
            yield return new BoolProperty(this.PubKey, "-pubkey");
            yield return new BoolProperty(this.NoOut, "-noout");
            yield return new BoolProperty(this.Modulus, "-modulus");
            yield return new BoolProperty(this.Verify, "-verify");
            yield return new BoolProperty(this.New, "-new");
            yield return new StringProperty(this.Subj, "-subj");
            yield return new StringProperty(this.Rand, "-rand");
            yield return new StringProperty(this.WriteRand, "-writerand");
            yield return new StringProperty(this.NewKey, "-newkey");
            yield return new StringProperty(this.PKeyOpt, "-pkeyopt");
            yield return new StringProperty(this.Key, "-key");
            yield return new NullableFormProperty(this.KeyForm, "-keyform");
            yield return new StringProperty(this.KeyOut, "-keyout");
            yield return new BoolProperty(this.Nodes, "-nodes");
            yield return new BoolProperty(this.Digest, "-digest");
            yield return new StringProperty(this.Config, "-config");
            yield return new BoolProperty(this.MultiValueRdn, "-multivalue-rdn");
            yield return new BoolProperty(this.X509, "-x509");
            yield return new IntProperty(this.Days, "-days");
            yield return new NullableIntProperty(this.SetSerial, "-set_serial");
            yield return new NullableIntProperty(this.AddExt, "-addext");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
