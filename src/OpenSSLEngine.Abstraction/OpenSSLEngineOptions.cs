using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("OpenSSLEngine.Tests.Functionality")]
[assembly: InternalsVisibleTo("OpenSSLEngine.Windows")]
namespace OpenSSLEngine.Abstraction
{
    /// <summary>
    /// Additional configuration options
    /// </summary>
    public class OpenSSLEngineOptions
    {
        /// <summary>
        /// Allows the use of parallel execution
        /// </summary>
        /// /// <remarks>
        /// This options invloves creating new temporary copies of required resources, i.e each call to a command will generate new temporary resource files
        /// </remarks>
        public bool EnableParallelExecution { get; set; }
        internal bool DeleteDirectory { get; set; } = true;
    }
}
