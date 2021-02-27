using System;

namespace Umator.Contract
{
    public abstract class ArgumentsClassAttribute : Attribute
    {
        public ArgumentsClassAttribute(Type argumentClassType)
        {
            ArgumentClassType = argumentClassType;
        }

        public Type ArgumentClassType { get; }
    }
}