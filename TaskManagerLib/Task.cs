using System;
using Newtonsoft.Json;

namespace TaskManagerLib
{
    public class Task
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }
        
        [JsonProperty("status")]
        public TaskStatus Status { get; set; }
        
    }
}