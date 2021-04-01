namespace Routindo.Contract.Plugin
{
    public sealed class RoutindoPluginInfo
    {
        public RoutindoPluginInfo(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public string Id { get; }

        public string Name { get; }

        public string Description { get; }
    }
}