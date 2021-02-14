using Newtonsoft.Json;

namespace TaskManagerLib
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"[User #{Id}] {Name}";
        }
    }
}