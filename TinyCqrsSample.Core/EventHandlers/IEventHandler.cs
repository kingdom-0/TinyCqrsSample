using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.EventHandlers
{
    public interface IEventHandler<TEvent> where TEvent:Event
    {
        void Handle(TEvent handle);
    }
}
