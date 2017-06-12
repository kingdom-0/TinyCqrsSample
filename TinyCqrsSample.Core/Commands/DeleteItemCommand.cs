using System;

namespace TinyCqrsSample.Core.Commands
{
    public class DeleteItemCommand : Command
    {
        public DeleteItemCommand(Guid aggregateId, int version)
            : base(aggregateId, version)
        {

        }
    }
}
