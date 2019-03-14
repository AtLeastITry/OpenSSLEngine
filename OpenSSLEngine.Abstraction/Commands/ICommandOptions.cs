using System;
using System.Collections.Generic;

namespace OpenSSLEngine.Abstraction.Commands
{
    public interface ICommandOptions: IEnumerable<Tuple<object, string>>
    {
    }
}
