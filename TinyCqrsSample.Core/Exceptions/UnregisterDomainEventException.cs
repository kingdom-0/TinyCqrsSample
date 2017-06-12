using System;

namespace TinyCqrsSample.Core.Exceptions
{
    public class UnregisterDomainEventException : Exception
    {
        public UnregisterDomainEventException()
        {
            
        }

        public UnregisterDomainEventException(string message) : base(message)
        {

        }

        public UnregisterDomainEventException(string message, Exception innerException)
            : base(message, innerException)
        {
            
        }
    }
}
