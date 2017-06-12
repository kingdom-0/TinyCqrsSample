using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T eventInstance) where T : Event;
    }
}
