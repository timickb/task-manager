using System.Collections.Generic;

namespace TaskManagerLib
{
    public interface IAssignable
    {
        public List<User> Executors { get; set; }

        public void AddExecutor(User user);
        
        public void RemoveExecutor(User user);
    }
}