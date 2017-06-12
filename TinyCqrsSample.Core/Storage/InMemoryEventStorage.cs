using System;
using System.Collections.Generic;
using System.Linq;
using TinyCqrsSample.Core.Domain;
using TinyCqrsSample.Core.Domain.Mementos;
using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Exceptions;
using TinyCqrsSample.Core.Messaging;
using TinyCqrsSample.Core.Storage.Memento;
using TinyCqrsSample.Core.Utils;

namespace TinyCqrsSample.Core.Storage
{
    public class InMemoryEventStorage:IEventStorage
    {
        private readonly List<Event> _events;
        private readonly List<BaseMemento> _mementos;
        private readonly IEventBus _eventBus;

        public InMemoryEventStorage(IEventBus eventBus)
        {
            _events = new List<Event>();
            _mementos = new List<BaseMemento>();
            _eventBus = eventBus;
        }

        public IEnumerable<Event> GetEvents(Guid aggregateId)
        {
            var events = _events.Where(e => e.AggregateId == aggregateId).ToList();
            if(!events.Any())
            {
                throw new AggregateNotFoundException(string.Format("Aggregate with Id:{0} was not found", aggregateId));
            }
            return events;
        }

        public void Save(AggregateRoot aggregateRoot)
        {
            var uncommittedChanges = aggregateRoot.GetUncommittedChangeEvents().ToList();
            var version = aggregateRoot.Version;
            foreach(var eventInstance in uncommittedChanges)
            {
                version++;
                if (version > 0 && version % 3 == 0)
                {
                    var originator = (IOriginator)aggregateRoot;
                    var memento = originator.GetMemento();
                    memento.Version = version;
                    SaveMemento(memento);
                }
                eventInstance.Version = version;
                _events.Add(eventInstance);
            }

            foreach(var eventInstance in uncommittedChanges)
            {
                var destEvent = Converter.ChangeTo(eventInstance, eventInstance.GetType());
                _eventBus.Publish(destEvent);
            }
        }

        public T GetMemento<T>(Guid aggregateId) where T : BaseMemento
        {
            var memento = _mementos.Where(m => m.Id == aggregateId).Select(m => m).LastOrDefault();
            return memento as T;
        }

        public void SaveMemento(BaseMemento memento)
        {
            _mementos.Add(memento);
        }
    }
}
