using System.Collections.Generic;

namespace TaskManagerAPI
{
    public class BugTask : Task, IAssignable
    {
        public List<User> Executors { get; set; }
        public void AddExecutor(User user)
        {
            if (Executors.Count > 0 || Executors.Contains(user))
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
            return $"[BugTask #{Id}] {Name} ({Description})" +
                   $"| created {CreationDate} " +
                   $"| {Status.ToString()}" +
                   $"| {Executors.Count} executors";
        }
    }
}