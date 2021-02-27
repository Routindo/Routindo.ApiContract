using System;

namespace Umator.Contract
{
    public class UmatorArgumentsMapperInfo : UmatorComponentInfo
    {
        private UmatorArgumentsMapperInfo(string id, Type watcherType, string name, string description) : base(id,
            watcherType, name, description)
        {
        }

        public static UmatorArgumentsMapperInfo Create<TArgumentsMapper>(string id, string name, string description)
            where TArgumentsMapper : class, IArgumentsMapper, new()
        {
            return new UmatorArgumentsMapperInfo(id, typeof(TArgumentsMapper), name, description);
        }
    }
}