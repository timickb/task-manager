using System.Collections.Generic;
using TaskManagerCLI;

namespace TaskManagerAPI
{
    /// <summary>
    /// Task Manager :)
    /// </summary>
    public partial class TaskManager
    {
        private static TaskManager _instance;

        private TaskManager()
        {
            _storage = new Storage("./");

            Users = _storage.ReadUsers();
            Projects = _storage.ReadProjects();
        }

        public static TaskManager GetInstance()
        {
            return _instance ??= new TaskManager();
        }
        
        
        private readonly Storage _storage;

        public List<User> Users { get; }
        public List<Project> Projects { get; }
        
        /// <summary>
        /// An opportunity to change the app data
        /// folder path externally.
        /// </summary>
        public string StorageFolderPath
        {
            get => _storage.DirectoryPath;
            set => _storage.DirectoryPath = value;
        }

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