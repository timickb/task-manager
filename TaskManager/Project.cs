using System;
using Newtonsoft.Json;

namespace TaskManager
{
    public class Project
    {
        [JsonProperty("name")]
        public string Name { get; set; } 
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }
        
        [JsonProperty("deadline")]
        public DateTime Deadline { get; set; }
        
        [JsonProperty("closed")]
        public bool Closed { get; set; }
        
        
    }
}