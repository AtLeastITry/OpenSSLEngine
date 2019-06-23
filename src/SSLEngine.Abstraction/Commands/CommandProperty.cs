using System;

namespace SSLEngine.Abstraction.Commands
{
    internal class CommandProperty<T> : ICommandProperty 
    {
        public T Value { get; }
        public string Alias { get; }

        public CommandProperty(T value, string alias)
        {
            if (string.IsNullOrEmpty(alias))
                throw new ArgumentNullException(nameof(alias));

            Value = value;
            Alias = alias;
        }
    }
}
