using System;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI
{
    /// <summary>
    /// [User] All methods relied to users.
    /// </summary>
    public partial class TaskManager
    {
        /// <summary>
        /// Creates new user and ADDS it to the users list.
        /// </summary>
        /// <param name="name">User name.</param>
        /// <returns>Created user object.</returns>
        /// <exception cref="ArgumentException">Exception throws when the
        /// user name length is more than 20 symbols.</exception>
        public User CreateUser(string name)
        {
            if (!IsUserNameCorrect(name))
            {
                throw new ArgumentException("User name is too long or starts with a digit.");
            }

            // Check if user with such name is already exists.
            if (Users.Any(user => user.Name == name))
            {
                throw new ArgumentException("User with this name is already exists.");
            }

            var nextId = Users.Select(user => user.Id).Prepend(0).Max() + 1;

            var user = new User
            {
                Id = nextId,
                Name = name
            };

            Users.Add(user);

            return user;
        }

        /// <summary>
        /// Unbinds the user from all tasks
        /// and removes it from the list.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            // Unassign this user from all tasks.
            foreach (var task in Projects.SelectMany(project => project.Tasks))
            {
                if (task is IAssignable assignable)
                {
                    try
                    {
                        assignable.RemoveExecutor(user);
                    }
                    catch (AssigningException)
                    {
                    }
                }

                if (!(task is EpicTask epicTask)) continue;

                foreach (var storyTask in epicTask.StoryTasks)
                {
                    try
                    {
                        storyTask.RemoveExecutor(user);
                    }
                    catch (AssigningException)
                    {
                    }
                }

                foreach (var simpleTask in epicTask.SimpleTasks)
                {
                    try
                    {
                        simpleTask.RemoveExecutor(user);
                    }
                    catch (AssigningException)
                    {
                    }
                }
            }

            Users.Remove(user);
        }

        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns>User object with specified id.</returns>
        public User GetUserById(int id)
        {
            return Users.Find(user => user.Id == id);
        }

        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns>User object with specified name.</returns>
        public User GetUserByName(string name)
        {
            return Users.Find(user => user.Name == name);
        }
    }
}