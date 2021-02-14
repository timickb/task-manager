using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerAPI;

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

        /// <summary>
        /// Removes specified project from the projects list.
        /// </summary>
        /// <param name="projectId">Project id</param>
        /// <exception cref="ArgumentException">Exception throws then the project
        /// with specified projectId doesn't exist.</exception>
        public void CloseProject(int projectId)
        {
            var project = Projects.Find(p => p.Id == projectId);
            
            if (project == null)
            {
                throw new ArgumentException($"Project with projectId {projectId} doesn't exist.");
            }
            
            // Close all tasks attached to this project.
            foreach (var task in project.Tasks)
            {
                task.Status = TaskStatus.Closed;
            }

            Projects.Remove(project);

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

        /// <summary>
        /// Finds project with specified Id and
        /// changes its name.
        /// </summary>
        /// <param name="projectId">Project Id</param>
        /// <param name="name">New project Name</param>
        /// <exception cref="ArgumentException">Exception throws than the name
        /// length is more than 47 symbols</exception>
        public void ChangeProjectName(int projectId, string name)
        {
            if (!IsProjectNameCorrect(name))
                throw new ArgumentException("Incorrect project name");

            foreach (var project in Projects.Where(project => project.Id == projectId))
            {
                project.Name = name;
            }
        }

        /// <summary>
        /// Finds project with specified Id and
        /// changes its name.
        /// </summary>
        /// <param name="id">Project Id</param>
        /// <param name="desc">New project Description</param>
        /// <exception cref="ArgumentException">Exception throws than the description
        /// length is more than 99 symbols</exception>
        public void ChangeProjectDescription(int id, string desc)
        {
            if (!IsProjectDescriptionCorrect(desc))
                throw new ArgumentException("Incorrect description");

            foreach (var project in Projects.Where(project => project.Id == id))
            {
                project.Description = desc;
            }
        }

        /// <summary>
        /// Adds an existing task to the project
        /// with specified projectId.
        /// </summary>
        /// <param name="projectId">Project projectId</param>
        /// <param name="task">Existing task object</param>
        /// <exception cref="ArgumentException">Exception throws then the project
        /// with specified projectId doesn't exist.</exception>
        /// <exception cref="InvalidOperationException">Exception throws then the project
        /// doesn't able to take new tasks. </exception>
        public void AttachTaskToProject(int projectId, Task task)
        {
            var project = Projects.Find(p => p.Id == projectId);

            if (project == null)
            {
                throw new ArgumentException($"Project with projectId {projectId} doesn't exist.");
            }

            if (project.Tasks.Count >= _settings.MaxTasksAmountInProject)
            {
                throw new InvalidOperationException(
                    "Maximum tasks amount for this projects has been already reached.");
            }

            project.Tasks.Add(task);

            // If task is IAssignable - make this task subscribed on UserRemoved event.
            if (task is IAssignable assignable)
            {
                UserRemoved += assignable.RemoveExecutor;
            }
        }

        /// <summary>
        /// Removes an existing task from the project
        /// with specified projectId.
        /// </summary>
        /// <param name="projectId">Project projectId</param>
        /// <param name="task">Existing task object</param>
        /// <exception cref="ArgumentException">Exception throws then the project
        /// with specified projectId doesn't exist.</exception>
        public void RemoveTaskFromProject(int projectId, Task task)
        {
            var project = Projects.Find(p => p.Id == projectId);

            if (project == null)
            {
                throw new ArgumentException($"Project with projectId {projectId} doesn't exist.");
            }

            project.Tasks.Remove(task);
            
            // If task is IAssignable - unsubscribe it from UserRemoved event.
            if (task is IAssignable assignable)
            {
                if (UserRemoved != null)
                    UserRemoved -= assignable.RemoveExecutor;
            }
        }

        /// <summary>
        /// Gives a copy of project tasks list.
        /// </summary>
        /// <param name="projectId">Project projectId</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Exception throws then the project
        /// with specified projectId doesn't exist.</exception>
        public List<Task> GetProjectTasksList(int projectId)
        {
            var project = Projects.Find(p => p.Id == projectId);

            if (project == null)
            {
                throw new ArgumentException($"Project with projectId {projectId} doesn't exist.");
            }

            Task[] list = { };
            project.Tasks.CopyTo(list);

            return list.ToList();
        }
    }
}