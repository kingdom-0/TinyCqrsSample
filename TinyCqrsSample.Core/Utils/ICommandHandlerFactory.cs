using TinyCqrsSample.Core.CommandHandlers;
using TinyCqrsSample.Core.Commands;

namespace TinyCqrsSample.Core.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandlers<T>() where T : Command;
    }
}
