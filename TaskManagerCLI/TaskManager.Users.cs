using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerLib;

namespace TaskManagerCLI
{
    /// <summary>
    /// All methods connected with users I decided
    /// to separate to a partial class.
    /// </summary>
    public partial class TaskManager
    {
        /// <summary>
        /// Adds a new user by the name.
        /// Id for this user will be generated automatically.
        /// </summary>
        /// <param name="name">User name</param>
        /// <exception cref="ArgumentException">Exception throws than the
        /// user name length is more than 20 symbols.</exception>
        public void CreateUser(string name)
        {
            if(!IsUserNameCorrect(name))
                throw new ArgumentException("Incorrect user name.");
                
            // The identifier for this user is the incremented Id of the greatest in list.
            var nextId = Users.Select(user => user.Id).Prepend(0).Max() + 1;
            
            Users.Add(new User
            {
                Id = nextId,
                Name = name
            });
            
        }

        /// <summary>
        /// Removes specified user from the list and destroys
        /// all task assignments for this user.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            // TODO: decide how to automatically destroy task assignments.
        }
        
        /// <summary>
        /// Finds a user with specified Id and calls
        /// RemoveUser method for this user.
        /// </summary>
        /// <param name="id">User Id</param>
        public void RemoveUserById(int id)
        {
            
            foreach (var user in Users.Where(user => user.Id == id))
            {
                RemoveUser(user);
            }
        }
        
        /// <summary>
        /// Finds ALL users with specified name and calls
        /// RemoveUser method for them.
        /// </summary>
        /// <param name="name">User name</param>
        public void RemoveUsersByName(string name)
        {
            foreach (var user in Users.Where(user => user.Name == name))
            {
                RemoveUser(user);
            }
        }
        
        /// <summary>
        /// Gives a copy of Users list.
        /// </summary>
        /// <returns>List of users</returns>
        public List<User> GetUsersList()
        {
            User[] list = { };
            Users.CopyTo(list);
            return list.ToList();
        }
    }
}