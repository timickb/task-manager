using System;
using System.Collections.Generic;
using System.IO;
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
            _storage = new Storage("./");

            Users = _storage.ReadUsers();
            Projects = _storage.ReadProjects();

        }

        public static TaskManager GetInstance()
        {
            return _instance ??= new TaskManager();
        }

        public static bool IsUserNameCorrect(string name)
        {
            return name.Length <= 20;
        }

        public static bool IsProjectNameCorrect(string name)
        {
            return name.Length <= 40;
        }

        public static bool IsProjectDescriptionCorrect(string desc)
        {
            return desc.Length <= 48;
        }

        private readonly Settings _settings;
        private readonly Storage _storage;
        
        public List<User> Users { get; }
        public List<Project> Projects { get; }
        
        /// <summary>
        /// Simple method that allows to save
        /// all changed app data in one code line.
        /// </summary>
        public void CommitChanges()
        {
            _storage.WriteProjects(Projects);
            _storage.WriteUsers(Users);
        }
    }
}