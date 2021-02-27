using System;

namespace Umator.Contract
{
    public class ExecutionArgumentsClassAttribute : ArgumentsClassAttribute
    {
        public ExecutionArgumentsClassAttribute(Type argumentClassType) : base(argumentClassType)
        {
        }
    }
}