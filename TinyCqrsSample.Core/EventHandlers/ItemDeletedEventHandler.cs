using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyCqrsSample.Core.Events;
using TinyCqrsSample.Core.Reporting;

namespace TinyCqrsSample.Core.EventHandlers
{
    public class ItemDeletedEventHandler:IEventHandler<ItemDeletedEvent>
    {
        private readonly IReportDatabase _reportDatabase;

        public ItemDeletedEventHandler(IReportDatabase reportDatabase)
        {
            _reportDatabase = reportDatabase;
        }

        public void Handle(ItemDeletedEvent eventInstance)
        {
            _reportDatabase.Delete(eventInstance.AggregateId);
        }
    }
}
