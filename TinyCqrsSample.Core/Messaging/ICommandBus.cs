using TinyCqrsSample.Core.Commands;

namespace TinyCqrsSample.Core.Messaging
{
    public interface ICommandBus
    {
        void Send<T>(T command) where T : Command;
    }
}
