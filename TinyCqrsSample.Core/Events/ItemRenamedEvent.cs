using System;

namespace TinyCqrsSample.Core.Events
{
    public class ItemRenamedEvent:Event
    {
        public string Title { get; internal set; }

        public ItemRenamedEvent(Guid aggregateId, string title)
        {
            AggregateId = aggregateId;
            Title = title;
        }
    }
}
