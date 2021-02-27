using System;

namespace Umator.Contract
{
    public class MissingArgumentsException : Exception
    {
        public MissingArgumentsException(string message): base(message)
        {
            
        }
    }
}