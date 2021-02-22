using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI
{
    public partial class TaskManager
    {
        public EpicTask CreateEpicTaskInProject(Project project, string taskName)
        {
            if (!IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var epicTask = new EpicTask
            {
                Id = nextId,
                Name = taskName,
                StoryTasks = new List<StoryTask>(),
                SimpleTasks =  new List<SimpleTask>()
            };
            
            project.Tasks.Add(epicTask);

            return epicTask;

        }

        public StoryTask CreateStoryTaskInProject(Project project, string taskName)
        {
            if (!IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var storyTask = new StoryTask
            {
                Id = nextId,
                Name = taskName,
                Executors = new List<User>()
            };
            
            project.Tasks.Add(storyTask);

            return storyTask;
        }

        public SimpleTask CreateSimpleTaskInProject(Project project, string taskName)
        {
            if (!IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var simpleTask = new SimpleTask
            {
                Id = nextId,
                Name = taskName,
                Executors = new List<User>()
            };
            
            project.Tasks.Add(simpleTask);

            return simpleTask;
        }

        public BugTask CreateBugTaskInProject(Project project, string taskName)
        {
            if (!IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var bugTask = new BugTask
            {
                Id = nextId,
                Name = taskName,
                Executors = new List<User>()
            };
            
            project.Tasks.Add(bugTask);

            return bugTask;
        }
        
        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="task">IAssignable task object</param>
        /// <param name="user">User object</param>
        public void AssignUserToTask(IAssignable task, User user)
        {
            task.AddExecutor(user);
        }

        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="task">IAssignable task object</param>
        /// <param name="user">User object</param>
        public void UnassignUserFromTask(IAssignable task, User user)
        {
            task.RemoveExecutor(user);
        }
        
        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="taskId">Task id in specified project</param>
        /// <returns></returns>
        public Task GetTaskByIdInProject(Project project, int taskId)
        {
            return project.Tasks.Find(task => task.Id == taskId);
        }
        
        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="task">Task object</param>
        /// <param name="status">Task status from enum</param>
        public void SetTaskStatus(Task task, TaskStatus status)
        {
            task.Status = status;
        }
        
        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="task">Task object</param>
        public void RemoveTaskFromProject(Project project, Task task)
        {
            project.Tasks.Remove(task);
        }
    }
}