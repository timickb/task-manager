using System.Collections.Generic;
using TaskManagerLib;

namespace TaskManagerCLI
{
    public class TaskManager
    {
        private static TaskManager _instance;

        private Settings _settings;
        
        public List<User> Users { get; private set; }
        public List<Project> Projects { get; private set; }

        private TaskManager()
        {
            // Settings loading.
            _settings = new Settings();
            
            Users = new List<User>();
            Projects = new List<Project>();
        }

        public static TaskManager GetInstance()
        {
            return _instance ??= new TaskManager();
        }
    }
}