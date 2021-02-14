using System.Collections.Generic;

namespace TaskManagerLib
{
    public class SimpleTask : Task, IAssignable
    {
        public List<User> Executors { get; set; }
        public void AddExecutor(User user)
        {
            if (Executors.Count > 0)
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
            return $"[SimpleTask #{Id}] {Name} ({Description}) | created {CreationDate} | {Status.ToString()}";
        }
    }
}