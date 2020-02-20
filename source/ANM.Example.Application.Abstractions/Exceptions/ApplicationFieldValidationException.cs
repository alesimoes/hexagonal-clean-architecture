using System;
using System.Collections.Generic;
using System.Text;

namespace ANM.Example.Application.Abstractions.Exceptions
{
    public class ApplicationFieldValidationException : Exception
    {
        public ApplicationFieldValidationException(string message) : base(message)
        {
        }
    }
}
