using System;
using System.Collections.Generic;
using System.Linq;
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
            var result = $"[EpicTask #{Id}] {Name} | created {CreationDate} | " +
                         $"{Status.ToString()} | {StoryTasks.Count + SimpleTasks.Count} connected subtasks: ";
            result = SimpleTasks.Aggregate(result, (current, task) => current + (task.Id + ", "));
            result = StoryTasks.Aggregate(result, (current, task) => current + (task.Id + ", "));
            return result + Environment.NewLine;
        }
    }
}