using System;

namespace TinyCqrsSample.Core.Commands
{
    public abstract class Command : ICommand
    {
        public Guid Id { get; }
        public int Version { get; }

        protected Command(Guid id, int version)
        {
            Id = id;
            Version = version;
        }
    }
}
