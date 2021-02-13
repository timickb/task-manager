using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaskManagerLib
{
    public class Project
    {
        
        [JsonProperty("name")]
        public string Name { get; set; }
            
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("tasks")]
        public List<Task> Tasks { get; set; }
        
        
    }
}