using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinyCqrsSample.Core.Exceptions
{
    public class UnregisteredDomainCommandException:Exception
    {
        public UnregisteredDomainCommandException(string message) : base(message)
        {

        }
    }
}
