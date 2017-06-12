using System;

namespace TinyCqrsSample.Core.Commands
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
