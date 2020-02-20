using System;

namespace ANM.Core.Domain.Abstractions.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string businessMessage)
            : base(businessMessage)
        {
        }
    }
}
