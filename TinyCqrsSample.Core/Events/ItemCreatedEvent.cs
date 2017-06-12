using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCqrsSample.Core.Events
{
    public class ItemCreatedEvent : Event
    {
        public string Title { get; internal set; }
        public DateTime From { get; internal set; }
        public DateTime To { get; internal set; }
        public string Description { get; internal set; }

        public ItemCreatedEvent(Guid aggregateId, string title, string description, DateTime from, DateTime to)
        {
            AggregateId = aggregateId;
            Title = title;
            From = from;
            To = to;
            Description = description;
        }
    }
}
