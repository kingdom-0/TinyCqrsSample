using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.Core.EventHandlers
{
    public class ItemFromChangedEventHandler:IEventHandler<ItemFromChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemFromChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemFromChangedEvent eventInstance)
        {
            var item = _reportDatabase.GetById(eventInstance.AggregateId);
            item.From = eventInstance.From;
            item.Version = eventInstance.Version;
        }
    }
}
