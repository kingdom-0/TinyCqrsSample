using System;

namespace TinyCqrsSample.Core.Events
{
    public class ItemDeletedEvent:Event
    {
        public ItemDeletedEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
