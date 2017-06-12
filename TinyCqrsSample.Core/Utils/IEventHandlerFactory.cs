using System.Collections.Generic;
using TinyCqrsSample.Core.EventHandlers;
using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T:Event;
    }
}
