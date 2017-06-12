using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCqrsSample.Core.Exceptions
{
    public class UnregisterDomainEventException : Exception
    {
        public UnregisterDomainEventException(string message) : base(message)
        {

        }
    }
}
