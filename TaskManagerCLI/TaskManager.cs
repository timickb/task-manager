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

        

        
        
        

    }
}