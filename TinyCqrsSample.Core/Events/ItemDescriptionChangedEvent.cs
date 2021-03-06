﻿using System;

namespace TinyCqrsSample.Core.Events
{
    public class ItemDescriptionChangedEvent:Event
    {
        public string Description { get; internal set; }

        public ItemDescriptionChangedEvent(Guid aggregateId, string description)
        {
            AggregateId = aggregateId;
            Description = description;
        }
    }
}
