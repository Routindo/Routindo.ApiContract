using System;

namespace Umator.Contract
{
    [AttributeUsage(AttributeTargets.Class)]
    public class PluginItemInfoAttribute : Attribute
    {
        public string Id { get; set; }

        public string Name { get; }

        public string Description { get; }

        public PluginItemInfoAttribute(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }


    }
}
