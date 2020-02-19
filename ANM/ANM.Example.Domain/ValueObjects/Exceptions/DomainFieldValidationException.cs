using ANM.Core.Domain.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANM.Example.Domain.ValueObjects.Exceptions
{
    public class DomainFieldValidationException : DomainException
    {
        public DomainFieldValidationException(string businessMessage) : base(businessMessage)
        {
        }
    }
}
