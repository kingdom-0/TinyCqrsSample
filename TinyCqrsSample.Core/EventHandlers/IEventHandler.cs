using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.EventHandlers
{
    public interface IEventHandler<in TEvent> where TEvent : Event
    {
        void Handle(TEvent handle);
    }
}
