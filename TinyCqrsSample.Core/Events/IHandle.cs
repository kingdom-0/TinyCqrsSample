namespace TinyCqrsSample.Core.Events
{
    public interface IHandle<in TEvent> where TEvent : Event
    {
        void Handle(TEvent e);
    }
}
