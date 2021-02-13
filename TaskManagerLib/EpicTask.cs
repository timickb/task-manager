using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaskManagerLib
{
    public class EpicTask : Task
    {
        [JsonProperty("story_tasks")]
        public List<StoryTask> StoryTasks { get; set; }
        
        [JsonProperty("simple_tasks")]
        public List<SimpleTask> SimpleTasks { get; set; }
    }
}