using System.Collections.Generic;
using System.Linq;
using TaskManagerLib;

namespace TaskManagerCLI
{
    /// <summary>
    /// All methods connected with projects I decided
    /// to separate to a partial class.
    /// </summary>
    public partial class TaskManager
    {
        public void CreateProject(string name, string description)
        {
            var nextId = Projects.Select(project => project.Id).Prepend(0).Max() + 1;
            
            Projects.Add(new Project
            {
                Name = name,
                Description = description
            });
        }

        public void CloseProject(Project project)
        {
            
        }
        
        /// <summary>
        /// Gives a copy of Projects list.
        /// </summary>
        /// <returns>List of projects</returns>
        public List<Project> GetProjectsList()
        {
            Project[] list = { };
            Projects.CopyTo(list);
            return list.ToList();
        }
    }
}