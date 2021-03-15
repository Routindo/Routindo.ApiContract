using System;

namespace Routindo.Contract.Exceptions
{
    public class MissingArgumentsException : Exception
    {
        public MissingArgumentsException(string message): base(message)
        {
            
        }
    }
}