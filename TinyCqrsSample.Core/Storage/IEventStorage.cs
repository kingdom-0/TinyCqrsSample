using System;
using System.Collections.Generic;
using TinyCqrsSample.Core.Domain;
using TinyCqrsSample.Core.Domain.Mementos;
using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.Storage
{
    public interface IEventStorage
    {
        IEnumerable<Event> GetEvents(Guid aggregateId);

        void Save(AggregateRoot aggregate);

        T GetMemento<T>(Guid aggregateId) where T : BaseMemento;

        void SaveMemento(BaseMemento memento);
    }
}
