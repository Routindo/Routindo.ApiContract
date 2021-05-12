using System;
using System.Linq;
using System.Text;

namespace Routindo.Contract.Attributes
{
    public class ArgumentInfoAttribute: Attribute
    {
        public string DisplayName { get; }
        public bool Mandatory { get; }
        public string Type { get; }
        public string Description { get; }

        public ArgumentInfoAttribute(string displayName, bool mandatory, Type type, string description = "")
        {
            DisplayName = displayName;
            Mandatory = mandatory;
            Type = GetFullName(type);
            Description = description;
        }

        private string GetFullName(Type t)
        {
            if (!t.IsGenericType)
                return t.Name;
            StringBuilder sb = new StringBuilder();

            sb.Append(t.Name.Substring(0, t.Name.LastIndexOf("`", StringComparison.Ordinal)));
            sb.Append(t.GetGenericArguments().Aggregate("<",

                delegate (string aggregate, Type type)
                {
                    return aggregate + (aggregate == "<" ? "" : ",") + GetFullName(type);
                }
            ));
            sb.Append(">");

            return sb.ToString();
        }
    }
}
