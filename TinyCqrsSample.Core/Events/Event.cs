using System;

namespace TinyCqrsSample.Core.Events
{
    public class Event:IEvent
    {
        public Guid Id { get; }
        public Guid AggregateId { get; set; }
        public int Version { get; set; }

        public Event()
        {
            Id = Guid.NewGuid();
        }
    }
}
