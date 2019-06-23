using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("SSLEngine.Tests.Functionality")]
[assembly: InternalsVisibleTo("SSLEngine.Windows")]
namespace SSLEngine.Abstraction
{
    /// <summary>
    /// Additional configuration options
    /// </summary>
    public class SSLEngineOptions
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
