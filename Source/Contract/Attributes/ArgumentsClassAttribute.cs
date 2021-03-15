using System;

namespace Routindo.Contract.Attributes
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