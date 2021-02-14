using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaskManagerAPI
{
    public class EpicTask : Task
    {
        [JsonProperty("story_tasks")]
        public List<StoryTask> StoryTasks { get; set; }
        
        [JsonProperty("simple_tasks")]
        public List<SimpleTask> SimpleTasks { get; set; }

        public override string ToString()
        {
            return $"[EpicTask #{Id}] {Name} ({Description}) | created {CreationDate} | " +
                   $"{Status.ToString()} | {StoryTasks.Count + SimpleTasks.Count} connected subtasks.";
        }
    }
}