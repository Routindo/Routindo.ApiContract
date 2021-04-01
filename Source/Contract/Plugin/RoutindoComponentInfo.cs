using System;

namespace Routindo.Contract.Plugin
{
    public abstract class RoutindoComponentInfo
    {
        protected RoutindoComponentInfo(string id, Type type, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            ComponentType = type;
        }

        public string Id { get; }

        public string Name { get; }

        public string Description { get; }

        public Type ComponentType { get; }
    }
}