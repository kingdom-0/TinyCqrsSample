using TinyCqrsSample.Core.Commands;
using TinyCqrsSample.Core.Exceptions;
using TinyCqrsSample.Core.Utils;

namespace TinyCqrsSample.Core.Messaging
{
    public class CommandBus:ICommandBus
    {
        private readonly ICommandHandlerFactory _commandHandlerFactory;

        public CommandBus(ICommandHandlerFactory commandHandlerFactory)
        {
            _commandHandlerFactory = commandHandlerFactory;
        }

        public void Send<T>(T command) where T : Command
        {
            var handler = _commandHandlerFactory.GetHandlers<T>();
            if(handler != null)
            {
                handler.Execute(command);
            }
            else
            {
                throw new UnregisteredDomainCommandException("No handler was registered.");
            }
        }
    }
}
