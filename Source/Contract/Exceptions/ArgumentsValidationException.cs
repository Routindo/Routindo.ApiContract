using System;
using System.Collections.Generic;
using System.Linq;

namespace Routindo.Contract.Exceptions
{
    public class ArgumentsValidationException : Exception
    {
        public readonly List<Exception> InnerExceptions = new List<Exception>();

        public ArgumentsValidationException(string message, List<Exception> innerExceptions = null) : base(message)
        {
            if (innerExceptions != null && innerExceptions.Any())
                InnerExceptions.AddRange(innerExceptions);
        }
    }
}