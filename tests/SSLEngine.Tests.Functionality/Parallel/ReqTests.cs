using SSLEngine.Abstraction.Commands.Req;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace SSLEngine.Tests.Functionality.Parrallel
{
    public class ReqTests : ParallelTest
    {
        [Fact]
        public async Task Files_Are_Created_Async()
        {
            var keyFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.key";
            var cerFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.cer";

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

            Assert.True(File.Exists(keyFilePath) && File.Exists(cerFilePath));
        }

        [Fact]
        public void Files_Are_Created()
        {
            var keyFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.key";
            var cerFilePath = $"{Path.GetTempPath()}\\{Guid.NewGuid()}.cer";

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

            Assert.True(File.Exists(keyFilePath) && File.Exists(cerFilePath));
        }

        [Fact]
        public async Task Parallel_Without_Conflict_Async()
        {
            await Task.WhenAll(
                Files_Are_Created_Async(),
                Files_Are_Created_Async(),
                Files_Are_Created_Async(),
                Files_Are_Created_Async()
            );
        }
    }
}
