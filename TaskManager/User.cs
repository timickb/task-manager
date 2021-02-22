using Newtonsoft.Json;

namespace TaskManager
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}