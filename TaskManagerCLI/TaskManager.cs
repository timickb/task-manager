using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI
{
    /// <summary>
    /// Task Manager :)
    /// </summary>
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
        
        private readonly Settings _settings;
        
        public List<User> Users { get; }
        public List<Project> Projects { get; }
    }
}