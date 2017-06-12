using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private static object _lockStorage = new object();

        public Repository(IEventStorage storage)
        {
            _storage = storage;
        }

        public void Save(T aggregateRoot, int expectedVersion)
        {
            if (aggregateRoot.GetUncommittedChanges().Any())
            {
                lock(_lockStorage)
                {
                    var item = new T();
                    if(expectedVersion != -1)
                    {
                        item = GetById(aggregateRoot.Id);
                        if(item.Version != expectedVersion)
                        {
                            throw new ConcurrencyException(string.Format("Aggregate {0} has been previously modified", item.Id));
                        }
                    }

                    _storage.Save(aggregateRoot);
                }
            }
        }

        public T GetById(Guid id)
        {
            IEnumerable<Event> events;
            var memento = _storage.GetMemento<BaseMemento>(id);
            if(memento != null)
            {
                events = _storage.GetEvents(id).Where(e => e.Version >= memento.Version);
            }
            else
            {
                events = _storage.GetEvents(id);
            }
            var obj = new T();
            if(memento != null)
            {
                ((IOriginator)obj).SetMemento(memento);
            }
            obj.LoadsFromHistory(events);
            return obj;
        }
    }
}
