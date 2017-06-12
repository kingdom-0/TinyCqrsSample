using System;
using System.Collections.Generic;
using System.Linq;
using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Utils;

namespace TinyCqrsSample.Core.Domain
{
    public abstract class AggregateRoot:IEventProvider
    {
        private readonly List<Event> _changes;

        public Guid Id { get; internal set; }

        public int Version { get; internal set; }

        public int EventVersion { get; protected set; }

        protected AggregateRoot()
        {
            _changes = new List<Event>();
        }

        public IList<Event> GetUncommittedChangeEvents()
        {
            return _changes;
        }

        public void MarkChangesAsCommitted()
        {
            _changes.Clear();
        }

        public void LoadEventsFromHistory(IList<Event> historyEvents)
        {
            foreach(var eventInstance in historyEvents)
            {
                ApplyChange(eventInstance, false);
            }

            Version = historyEvents.Last().Version;
            EventVersion = Version;
        }

        protected void ApplyChange(Event eventInstance)
        {
            ApplyChange(eventInstance, true);
        }

        private void ApplyChange(Event eventInstance, bool isNew)
        {
            dynamic d = this;
            d.Handle(Converter.ChangeTo(eventInstance, eventInstance.GetType()));
            if(isNew)
            {
                _changes.Add(eventInstance);
            }
        }
    }
}
