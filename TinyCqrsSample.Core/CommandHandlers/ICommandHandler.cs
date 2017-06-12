using TinyCqrsSample.Core.Commands;

namespace TinyCqrsSample.Core.CommandHandlers
{
    public interface ICommandHandler<in TCommand> where TCommand : Command
    {
        void Execute(TCommand command);
    }
}
