using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.Core.EventHandlers
{
    public class ItemRenamedEventHandler:IEventHandler<ItemRenamedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemRenamedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemRenamedEvent eventInstance)
        {
            var item = _reportDatabase.GetById(eventInstance.AggregateId);
            item.Title = eventInstance.Title;
            item.Version = eventInstance.Version;
        }
    }
}
