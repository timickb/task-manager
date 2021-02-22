using System;
using Newtonsoft.Json;

namespace TaskManagerAPI
{
    public abstract class Task
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("name")]
        public string Name { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("creation_date")]
        public DateTime CreationDate { get; set; }
        
        [JsonProperty("status")]
        public TaskStatus Status { get; set; }

        public override string ToString()
        {
            return $"[Task #{Id}] {Name} ({Description}) | created {CreationDate} | {Status.ToString()}";
        }
    }
}