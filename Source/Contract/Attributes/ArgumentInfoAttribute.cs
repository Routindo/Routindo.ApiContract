using System;

namespace Routindo.Contract.Attributes
{
    public class ArgumentInfoAttribute: Attribute
    {
        public string DisplayName { get; }
        public bool Mandatory { get; }
        public Type Type { get; }
        public string Description { get; }

        public ArgumentInfoAttribute(string displayName, bool mandatory, Type type, string description = "")
        {
            DisplayName = displayName;
            Mandatory = mandatory;
            Type = type;
            Description = description;
        }
    }
}
