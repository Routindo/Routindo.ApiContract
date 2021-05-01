using System;

namespace Routindo.Contract.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginItemInfoAttribute : Attribute
    {
        private string _friendlyName;
        public string Id { get; set; }

        public string Name { get; }

        public string Description { get; }

        public string Category { get; set; } = "Uncategorized";

        public string FriendlyName
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_friendlyName))
                    return Name;
                return _friendlyName;
            }
            set => _friendlyName = value;
        }

        public PluginItemInfoAttribute(string id, string name, string description = "")
        {
            Id = id;
            Name = name;
            Description = description;
        }


    }
}
