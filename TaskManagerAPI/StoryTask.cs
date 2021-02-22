using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace TaskManagerAPI
{
    public class StoryTask : Task, IAssignable
    {
        [JsonProperty("executors")] public List<User> Executors { get; set; }

        public StoryTask()
        {
            Executors = new List<User>();
        }

        public void AddExecutor(User user)
        {
            if (Executors.Contains(user))
            {
                throw new AssigningException("Executors limit for this task exceeded or this user" +
                                             "is already assigned here.");
            }

            Executors.Add(user);
        }

        public void RemoveExecutor(User user)
        {
            Executors.Remove(user);
        }

        public override string ToString()
        {
            var result = $"[StoryTask #{Id}] {Name} ({Description}) " +
                         $"| Created {CreationDate} " +
                         $"| {Status.ToString()} " +
                         $"| {Executors.Count} executors: {Environment.NewLine}";
            return Executors.Aggregate(result,
                       (current, user) => current + (user + Environment.NewLine))
                   + Environment.NewLine;
        }
    }
}