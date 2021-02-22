using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TaskManagerAPI
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum TaskStatus
    {
        Opened,
        InProgress,
        Closed
    }
}