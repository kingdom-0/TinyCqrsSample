using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Domain;

namespace TinyCqrsSample.Core.Storage
{
    public interface IRepository<T> where T:AggregateRoot, new()
    {
        void Save(T aggregateRoot, int expectedVersion);

        T GetById(Guid id);
    }
}
