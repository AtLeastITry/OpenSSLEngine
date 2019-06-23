using SSLEngine.Abstraction.Commands.Pkcs12;
using SSLEngine.Abstraction.Commands.Req;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace SSLEngine.Tests.Functionality
{
    public class Pscs12Tests : BaseTest
    {
        [Fact]
        public async Task File_Created_Async()
        {
            var keyFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.key";
            var cerFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.cer";
            var pfxFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.pfx";

            await _engine.ReqAsync(
                options: new ReqOptions
                {
                    NewKey = "rsa:2048",
                    Nodes = true,
                    KeyOut = keyFilePath,
                    X509 = true,
                    Days = 365,
                    Out = cerFilePath
                },
                input: new ReqInput
                {
                    CommonName = "",
                    CountryName = "",
                    EmailAddress = "",
                    LocalityName = "",
                    OrganizationalUnitName = "",
                    OrganizationName = "",
                    StateOrProvinceName = ""
                }
            );

            await _engine.Pkcs12Async(
                options: new Pkcs12Options
                {
                    Export = true,
                    In = cerFilePath,
                    InKey = keyFilePath,
                    Out = pfxFilePath,
                    PassOut = "pass:1234"
                }
            );

            Assert.True(File.Exists(pfxFilePath));
        }

        [Fact]
        public void File_Created()
        {
            var keyFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.key";
            var cerFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.cer";
            var pfxFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.pfx";

            _engine.Req(
                options: new ReqOptions
                {
                    NewKey = "rsa:2048",
                    Nodes = true,
                    KeyOut = keyFilePath,
                    X509 = true,
                    Days = 365,
                    Out = cerFilePath
                },
                input: new ReqInput
                {
                    CommonName = "",
                    CountryName = "",
                    EmailAddress = "",
                    LocalityName = "",
                    OrganizationalUnitName = "",
                    OrganizationName = "",
                    StateOrProvinceName = ""
                }
            );

            _engine.Pkcs12(
                options: new Pkcs12Options
                {
                    Export = true,
                    In = cerFilePath,
                    InKey = keyFilePath,
                    Out = pfxFilePath,
                    PassOut = "pass:1234"
                }
            );

            Assert.True(File.Exists(pfxFilePath));
        }

        [Fact]
        public async Task Parallel_Without_Conflict_Async()
        {
            await Task.WhenAll(
                File_Created_Async(),
                File_Created_Async(),
                File_Created_Async(),
                File_Created_Async()
            );
        }
    }
}
