using System.Collections;
using System.Collections.Generic;

namespace SSLEngine.Abstraction.Commands.Pkcs12
{
    public class Pkcs12Input : ICommandInput
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
