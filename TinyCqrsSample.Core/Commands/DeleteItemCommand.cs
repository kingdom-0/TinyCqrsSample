using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCqrsSample.Core.Commands
{
    public class DeleteItemCommand : Command
    {
        public DeleteItemCommand(Guid aggregateId, int version):base(aggregateId, version)
        {

        }
    }
}
