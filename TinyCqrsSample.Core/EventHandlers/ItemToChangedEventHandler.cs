using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.Core.EventHandlers
{
    public class ItemToChangedEventHandler:IEventHandler<ItemToChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemToChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemToChangedEvent eventInstance)
        {
            var item = _reportDatabase.GetById(eventInstance.AggregateId);
            item.To = eventInstance.To;
            item.Version = eventInstance.Version;
        }
    }
}
