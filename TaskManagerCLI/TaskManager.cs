using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerLib;

namespace TaskManagerCLI
{

    public delegate EventHandler UserRemoved(object sender, EventArgs args);
    public delegate EventHandler UserAdded(object sender, EventArgs args);

    public partial class TaskManager
    {
        private static TaskManager _instance;

        private TaskManager()
        {
            _settings = new Settings();
            
            Users = new List<User>();
            Projects = new List<Project>();
        }
        
        public static TaskManager GetInstance()
        {
            return _instance ??= new TaskManager();
        }
        
        private Settings _settings;
        
        
        
        public List<User> Users { get; }
        public List<Project> Projects { get; }

        /// <summary>
        /// Adds a new user by the name.
        /// Id for this user will be generated automatically.
        /// </summary>
        /// <param name="name">User name</param>
        public void AddUser(string name)
        {
            // The identifier for this user is the incremented Id of the greatest in list.
            var nextId = Users.Select(user => user.Id).Prepend(0).Max() + 1;
            
            Users.Add(new User
            {
                Id = nextId,
                Name = name
            });
            
        }

        /// <summary>
        /// Removes specified user from the list and destroyss
        /// all task assignments for this user.
        /// </summary>
        /// <param name="user"></param>
        public void RemoveUser(User user)
        {
            
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

        
        
        

    }
}