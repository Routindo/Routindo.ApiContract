using System.Text.Json;
using System.Text.Json.Serialization;

namespace Umator.Contract
{
    public static class ObjectSerializer
    {
        private static readonly JsonSerializerOptions Options;

        static ObjectSerializer()
        {
            if (Options == null)
                Options = new JsonSerializerOptions
                {
                    WriteIndented = true
                };
            Options.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
        }

        public static string ToJsonString(this object obj, bool useFormat = true)
        {
            if (useFormat)
                return JsonSerializer.Serialize(obj, Options);
            return JsonSerializer.Serialize(obj);
        }
    }
}