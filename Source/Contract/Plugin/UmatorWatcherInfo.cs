using System;
using Routindo.Contract.Watchers;

namespace Routindo.Contract.Plugin
{
    public sealed class RoutindoWatcherInfo : RoutindoComponentInfo
    {
        public RoutindoWatcherInfo(string id, Type watcherType, string name, string description) : base(id, watcherType,
            name, description)
        {
        }

        public static RoutindoWatcherInfo Create<TWatcher>(string id, string name, string description)
            where TWatcher : class, IWatcher, new()
        {
            return new RoutindoWatcherInfo(id, typeof(TWatcher), name, description);
        }
    }
}