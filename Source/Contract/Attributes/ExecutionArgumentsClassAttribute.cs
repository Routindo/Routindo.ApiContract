using System;

namespace Routindo.Contract.Attributes
{
    public class ExecutionArgumentsClassAttribute : ArgumentsClassAttribute
    {
        public ExecutionArgumentsClassAttribute(Type argumentClassType) : base(argumentClassType)
        {
        }
    }
}