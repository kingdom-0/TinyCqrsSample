using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.Core.EventHandlers
{
    public class ItemDescriptionChangedEventHandler:IEventHandler<ItemDescriptionChangedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemDescriptionChangedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemDescriptionChangedEvent eventInstance)
        {
            var item = _reportDatabase.GetById(eventInstance.AggregateId);
            item.Description = eventInstance.Description;
            item.Version = eventInstance.Version;
        }
    }
}
