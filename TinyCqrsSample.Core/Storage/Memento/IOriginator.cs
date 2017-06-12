using TinyCqrsSample.Core.Domain.Mementos;

namespace TinyCqrsSample.Core.Storage.Memento
{
    public interface IOriginator
    {
        BaseMemento GetMemento();

        void SetMemento(BaseMemento memento);
    }
}
