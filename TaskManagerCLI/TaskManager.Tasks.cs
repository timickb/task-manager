using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerLib;

namespace TaskManagerCLI
{
    /// <summary>
    /// All methods connected with tasks I decided
    /// to separate to a partial class.
    /// </summary>
    public partial class TaskManager
    {
        /// <summary>
        /// Assigns the user to the task.
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="task">Taks object</param>
        /// <exception cref="ArgumentException">Exception throws than the specified
        /// task object is not IAssignable</exception>
        /// <exception cref="InvalidOperationException">Exception throws than the specified
        /// task doesn't allow to assign any more users to itself.</exception>
        public void AssignUserToTask(User user, Task task)
        {
            if (!(task is IAssignable))
            {
                throw new ArgumentException("Task object must be IAssignable.");
            }

            try
            {
                ((IAssignable) task).AddExecutor(user);
            }
            catch (AssigningException)
            {
                throw new InvalidOperationException("Unable to assign any more executors for specified task.");
            }
        }

        /// <summary>
        /// Removes the user assigment to the task.
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="task">Task object</param>
        /// <exception cref="ArgumentException">Exception throws than the specified
        /// task object is not IAssignable</exception>
        public void RemoveAssignedUserFromTask(User user, Task task)
        {
            if (!(task is IAssignable))
            {
                throw new ArgumentException("Task object must be IAssignable.");
            }
            ((IAssignable) task).RemoveExecutor(user);
        }

        /// <summary>
        /// Changes task status.
        /// </summary>
        /// <param name="task">Task object</param>
        /// <param name="status">Task status from enum</param>
        public void ChangeTaskStatus(Task task, TaskStatus status)
        {
            task.Status = status;
        }

        /// <summary>
        /// Gives the executors list for the specified task.
        /// </summary>
        /// <param name="task">Task object</param>
        /// <returns>List of users</returns>
        /// <exception cref="ArgumentException">Exception throws than the specified
        /// task object is not IAssignable</exception>
        public List<User> GetTaskExecutorsList(Task task)
        {
            if (!(task is IAssignable))
            {
                throw new ArgumentException("Task object must be IAssignable.");
            }
            
            User[] list = { };
            ((IAssignable) task).Executors.CopyTo(list);

            return list.ToList();
        }
    }
}