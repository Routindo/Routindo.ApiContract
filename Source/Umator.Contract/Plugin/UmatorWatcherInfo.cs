using System;

namespace Umator.Contract
{
    public sealed class UmatorWatcherInfo : UmatorComponentInfo
    {
        public UmatorWatcherInfo(string id, Type watcherType, string name, string description) : base(id, watcherType,
            name, description)
        {
        }

        public static UmatorWatcherInfo Create<TWatcher>(string id, string name, string description)
            where TWatcher : class, IWatcher, new()
        {
            return new UmatorWatcherInfo(id, typeof(TWatcher), name, description);
        }
    }
}