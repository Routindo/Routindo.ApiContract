using System;
using Routindo.Contract.Actions;

namespace Routindo.Contract.Plugin
{
    public sealed class RoutindoActionInfo : RoutindoComponentInfo
    {
        private RoutindoActionInfo(string id, Type watcherType, string name, string description) : base(id, watcherType,
            name, description)
        {
        }

        public static RoutindoActionInfo Create<TAction>(string id, string name, string description)
            where TAction : class, IAction, new()
        {
            return new RoutindoActionInfo(id, typeof(TAction), name, description);
        }
    }
}