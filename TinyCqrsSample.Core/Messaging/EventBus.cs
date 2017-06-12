using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Utils;

namespace TinyCqrsSample.Core.Messaging
{
    public class EventBus:IEventBus
    {
        private IEventHandlerFactory _eventHandlerFactory;

        public EventBus(IEventHandlerFactory eventHandlerFactory)
        {
            _eventHandlerFactory = eventHandlerFactory;
        }

        public void Publish<T>(T eventInstance) where T:Event
        {
            var handlers = _eventHandlerFactory.GetHandlers<T>();
            foreach(var handler in handlers)
            {
                handler.Handle(eventInstance);
            }
        }
    }
}
