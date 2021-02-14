using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaskManagerLib
{
    public class Project
    {
        
        [JsonProperty("id")]
        public int Id { get; private set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
            
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("tasks")]
        public List<Task> Tasks { get; set; }

        public override string ToString()
        {
            return $"[Project #{Id}] {Name} ({Description}) | {Tasks.Count} connected tasks.";
        }
    }
}