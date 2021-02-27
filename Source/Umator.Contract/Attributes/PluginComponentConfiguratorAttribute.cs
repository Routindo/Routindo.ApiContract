using System;

namespace Umator.Contract
{
    [AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true)]
    public class ComponentConfiguratorAttribute: Attribute
    {
        public Type ConfiguratorType { get; }
        public string ComponentId { get; }
        public string Description { get; }

        public ComponentConfiguratorAttribute(Type configuratorType, string targetComponentId, string description = null)
        {
            ConfiguratorType = configuratorType;
            ComponentId = targetComponentId; 
            Description = description;
        }
    }
}
