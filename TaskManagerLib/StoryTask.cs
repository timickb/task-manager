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
    }
}