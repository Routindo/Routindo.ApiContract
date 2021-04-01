using System;

namespace Routindo.Contract.Plugin
{
    public abstract class RoutindoComponentInfo
    {
        protected RoutindoComponentInfo(string id, Type watcherType, string name, string description)
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