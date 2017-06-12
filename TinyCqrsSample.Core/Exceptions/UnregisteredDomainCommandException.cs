﻿using System;

namespace TinyCqrsSample.Core.Exceptions
{
    public class UnregisteredDomainCommandException:Exception
    {
        public UnregisteredDomainCommandException()
        {
            
        }

        public UnregisteredDomainCommandException(string message) : base(message)
        {

        }

        public UnregisteredDomainCommandException(string message, Exception innerException)
            :base(message, innerException)
        {
            
        }
    }
}
