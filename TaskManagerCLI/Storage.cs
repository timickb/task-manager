using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TaskManagerAPI;

namespace TaskManagerCLI
{
    /// <summary>
    /// Class for app data storing manage.
    /// </summary>
    public class Storage
    {
        /// <summary>
        /// Path to the directory where the
        /// app data files locate.
        /// </summary>
        public string DirectoryPath { get; }

        public Storage(string path)
        {
            path = Path.GetFullPath(path);

            if (!Directory.Exists(path))
            {
                throw new ArgumentException("Specified path doesn't exist.");
            }

            DirectoryPath = path;
        }
        
        /// <summary>
        /// Reads the file with saved users.
        /// </summary>
        /// <returns>List of users.</returns>
        /// <exception cref="Exception">Exception throws the it's impossible
        /// to read the file.</exception>
        public List<User> ReadUsers()
        {
            var filePath = Path.Combine(DirectoryPath, "users.json");

            try
            {
                using var sr = new StreamReader(filePath);
                var data = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<User>>(data);
            }
            catch (IOException)
            {
                throw new Exception();
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception();
            }
        }
        
        /// <summary>
        /// Reads the file with saved projects.
        /// </summary>
        /// <returns>List of projects.</returns>
        /// <exception cref="Exception">Exception throws the it's impossible
        /// to read the file.</exception>
        public List<Project> ReadProjects()
        {
            var filePath = Path.Combine(DirectoryPath, "projects.json");

            try
            {
                using var sr = new StreamReader(filePath);
                var data = sr.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Project>>(data);
            }
            catch (IOException)
            {
                throw new Exception();
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Serializes the list of users and writes
        /// it to the users.json file.
        /// </summary>
        /// <param name="users">List of users</param>
        /// <exception cref="Exception">Exception throws when it's impossible
        /// to write to the file.</exception>
        public void WriteUsers(List<User> users)
        {
            var data = JsonConvert.SerializeObject(users);

            var filePath = Path.Combine(DirectoryPath, "users.json");

            try
            {
                using var sw = new StreamWriter(filePath);
                sw.Write(data);
            }
            catch (IOException)
            {
                throw new Exception();
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Serializes the list of projects and writes
        /// it to the users.json file.
        /// </summary>
        /// <param name="projects">List of projects</param>
        /// <exception cref="Exception">Exception throws when it's impossible
        /// to write to the file.</exception>
        public void WriteProjects(List<Project> projects)
        {
            string data = JsonConvert.SerializeObject(projects);

            string filePath = Path.Combine(DirectoryPath, "projects.json");

            try
            {
                using var sw = new StreamWriter(filePath);
                sw.Write(data);
            }
            catch (IOException)
            {
                throw new Exception();
            }
            catch (UnauthorizedAccessException)
            {
                throw new Exception();
            }
        }
    }
}