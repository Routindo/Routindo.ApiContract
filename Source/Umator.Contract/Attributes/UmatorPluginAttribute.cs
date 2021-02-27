using System;

namespace Umator.Contract
{
    [AttributeUsage(AttributeTargets.Assembly)]
    public class UmatorPluginAttribute : Attribute
    {
        public UmatorPluginAttribute(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; set; }

        public string Name { get; }

        public string Description { get; }

        public string Author { get; set; }

        public string AuthorUri { get; set; }

        public string SupportUri { get; set; }

        public string DocumentationUri { get; set; } 
    }
}
