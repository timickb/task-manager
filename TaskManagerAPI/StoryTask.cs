using System.Collections.Generic;

namespace TaskManagerAPI
{
    public class StoryTask : Task, IAssignable
    {
        public List<User> Executors { get; set; }
        
        public void AddExecutor(User user)
        {
            Executors.Add(user);
        }

        public void RemoveExecutor(User user)
        {
            Executors.Remove(user);
        }

        public override string ToString()
        {
            return $"[StoryTask #{Id}] {Name} ({Description}) | Created {CreationDate} | {Status.ToString()}";
        }
    }
}