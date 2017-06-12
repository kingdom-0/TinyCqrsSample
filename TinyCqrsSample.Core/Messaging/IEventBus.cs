using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.Messaging
{
    public interface IEventBus
    {
        void Publish<T>(T eventInstance) where T : Event;
    }
}
