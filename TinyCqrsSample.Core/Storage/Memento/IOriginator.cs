using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Domain.Mementos;

namespace TinyCqrsSample.Core.Storage.Memento
{
    public interface IOriginator
    {
        BaseMemento GetMemento();

        void SetMemento(BaseMemento memento);
    }
}
