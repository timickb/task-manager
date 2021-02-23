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
            if (Executors.All(u => u.Id != user.Id))
            {
                throw new AssigningException("This user wasn't assigned to this task.");
            }

            Executors.Remove(Executors.Find(u => u.Id == user.Id));
        }

        public override string ToString()
        {
            var result = $"[StoryTask #{Id}] {Name} " +
                         $"| Created {CreationDate} " +
                         $"| {Status.ToString()} " +
                         $"| {Executors.Count} executors: {Environment.NewLine}";
            return Executors.Aggregate(result,
                       (current, user) => current + (user + Environment.NewLine))
                   + Environment.NewLine;
        }
    }
}