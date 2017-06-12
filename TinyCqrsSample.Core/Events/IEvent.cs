using System;

namespace TinyCqrsSample.Core.Events
{
    public interface IEvent
    {
        Guid Id { get; }
    }
}
