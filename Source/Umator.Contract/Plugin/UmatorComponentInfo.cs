using System;

namespace Umator.Contract
{
    public abstract class UmatorComponentInfo
    {
        protected UmatorComponentInfo(string id, Type watcherType, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            WatcherType = watcherType;
        }

        public string Id { get; }

        public string Name { get; }

        public string Description { get; }

        public Type WatcherType { get; }
    }
}