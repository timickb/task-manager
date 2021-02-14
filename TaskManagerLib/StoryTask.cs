using System.Collections.Generic;

namespace TaskManagerLib
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
            return $"[StoryTask #{Id}] {Name} ({Description}) | created {CreationDate} | {Status.ToString()}";
        }
    }
}