using System;
using Routindo.Contract.Arguments;

namespace Routindo.Contract.Plugin
{
    public class RoutindoArgumentsMapperInfo : RoutindoComponentInfo
    {
        private RoutindoArgumentsMapperInfo(string id, Type watcherType, string name, string description) : base(id,
            watcherType, name, description)
        {
        }

        public static RoutindoArgumentsMapperInfo Create<TArgumentsMapper>(string id, string name, string description)
            where TArgumentsMapper : class, IArgumentsMapper, new()
        {
            return new RoutindoArgumentsMapperInfo(id, typeof(TArgumentsMapper), name, description);
        }
    }
}