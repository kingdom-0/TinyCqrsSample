using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.CommandHandlers;
using TinyCqrsSample.Core.Commands;

namespace TinyCqrsSample.Core.Utils
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> GetHandler<T>() where T : Command;
    }
}
