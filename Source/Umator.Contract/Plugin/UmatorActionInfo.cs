using System;

namespace Umator.Contract
{
    public sealed class UmatorActionInfo : UmatorComponentInfo
    {
        private UmatorActionInfo(string id, Type watcherType, string name, string description) : base(id, watcherType,
            name, description)
        {
        }

        public static UmatorActionInfo Create<TAction>(string id, string name, string description)
            where TAction : class, IAction, new()
        {
            return new UmatorActionInfo(id, typeof(TAction), name, description);
        }
    }
}