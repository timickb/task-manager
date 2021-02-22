using System;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI
{
    public partial class TaskManager
    {
        public Project CreateProject(string name)
        {
            if (!IsProjectNameCorrect(name))
            {
                throw new ArgumentException("Project name is too long");
            }
            var nextId = Projects.Select(proj => proj.Id).Prepend(0).Max() + 1;

            var project = new Project()
            {
                Id = nextId,
                Name = name
            };
            
            Projects.Add(project);

            return project;
        }
        
        /// <summary>
        /// Just removes specified project.
        /// </summary>
        /// <param name="project">Project object.</param>
        public void RemoveProject(Project project)
        {
            Projects.Remove(project);
        }
        
        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="id">Project id</param>
        /// <returns>Project object with specified id.</returns>
        public Project GetProjectById(int id)
        {
            return Projects.Find(proj => proj.Id == id);
        }
    }
}