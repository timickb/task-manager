using System.Collections.Generic;
using Newtonsoft.Json;

namespace TaskManagerAPI
{
    public class StoryTask : Task, IAssignable
    {
        [JsonProperty("executors")]
        public List<User> Executors { get; set; }

        public StoryTask()
        {
            Executors = new List<User>();
        }

        public void AddExecutor(User user)
        {
            if (Executors.Contains(user))
            {
                throw new AssigningException();
            }
            Executors.Add(user);
        }

        public void RemoveExecutor(User user)
        {
            Executors.Remove(user);
        }

        public override string ToString()
        {
            return $"[StoryTask #{Id}] {Name} ({Description}) " +
                   $"| Created {CreationDate} " +
                   $"| {Status.ToString()}" +
                   $"| {Executors.Count} executors";
        }
    }
}