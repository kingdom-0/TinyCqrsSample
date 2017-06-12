using System.Collections.Generic;
using TinyCqrsSample.Core.Events;

namespace TinyCqrsSample.Core.Domain
{
    public interface IEventProvider
    {
        void LoadEventsFromHistory(IList<Event> historyEvents);

        IList<Event> GetUncommittedChangeEvents();
    }
}
