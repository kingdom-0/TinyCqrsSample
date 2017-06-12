using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.EventHandlers;
using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.Utils
{
    public interface IEventHandlerFactory
    {
        IEnumerable<IEventHandler<T>> GetHandlers<T>() where T:Event;
    }
}
