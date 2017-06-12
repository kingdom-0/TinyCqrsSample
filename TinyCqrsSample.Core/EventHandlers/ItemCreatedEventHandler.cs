using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.Core.EventHandlers
{
    public class ItemCreatedEventHandler:IEventHandler<ItemCreatedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemCreatedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemCreatedEvent eventInstance)
        {
            var item = new DiaryItemDto()
            {
                Id = eventInstance.AggregateId,
                Description = eventInstance.Description,
                From = eventInstance.From,
                To = eventInstance.To,
                Title = eventInstance.Title,
                Version = eventInstance.Version,
            };
            _reportDatabase.Add(item);
        }
    }
}
