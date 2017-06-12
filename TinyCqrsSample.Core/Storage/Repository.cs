using System;
using System.Collections.Generic;
using System.Linq;
using TinyCqrsSample.Core.Domain;
using TinyCqrsSample.Core.Domain.Mementos;
using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Exceptions;
using TinyCqrsSample.Core.Storage.Memento;

namespace TinyCqrsSample.Core.Storage
{
    public class Repository<T>:IRepository<T> where T : AggregateRoot, new()
    {
        private readonly IEventStorage _storage;
        private static readonly object LockStorage = new object();

        public Repository(IEventStorage storage)
        {
            _storage = storage;
        }

        public void Save(T aggregateRoot, int expectedVersion)
        {
            if (!aggregateRoot.GetUncommittedChangeEvents().Any())
            {
                return;
            }

            lock(LockStorage)
            {
                if(expectedVersion != -1)
                {
                    var item = GetById(aggregateRoot.Id);
                    if(item.Version != expectedVersion)
                    {
                        throw new ConcurrencyException(string.Format("Aggregate {0} has been previously modified", item.Id));
                    }
                }

                _storage.Save(aggregateRoot);
            }
        }

        public T GetById(Guid id)
        {
            IList<Event> events;
            var memento = _storage.GetMemento<BaseMemento>(id);
            if(memento != null)
            {
                events = _storage.GetEvents(id).Where(e => e.Version >= memento.Version).ToList();
            }
            else
            {
                events = _storage.GetEvents(id).ToList();
            }
            var obj = new T();
            if(memento != null)
            {
                ((IOriginator)obj).SetMemento(memento);
            }
            obj.LoadEventsFromHistory(events);
            return obj;
        }
    }
}
