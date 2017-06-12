using System;

namespace TinyCqrsSample.Core.Events
{
    public class ItemToChangedEvent:Event
    {
        public DateTime To { get; internal set; }
        
        public ItemToChangedEvent(Guid aggregateId, DateTime to)
        {
            AggregateId = aggregateId;
            To = to;
        }
    }
}
