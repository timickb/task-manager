using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerAPI
{
    public partial class TaskManager
    {
        public EpicTask CreateEpicTaskInProject(Project project, string taskName)
        {
            if (!TaskManager.IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var epicTask = new EpicTask
            {
                Id = nextId,
                Name = taskName,
                StoryTasks = new List<StoryTask>(),
                SimpleTasks =  new List<SimpleTask>(),
                CreationDate = DateTime.Now
            };
            
            project.Tasks.Add(epicTask);

            return epicTask;

        }

        public StoryTask CreateStoryTaskInProject(Project project, string taskName)
        {
            if (!TaskManager.IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var storyTask = new StoryTask
            {
                Id = nextId,
                Name = taskName,
                Executors = new List<User>(),
                CreationDate = DateTime.Now
            };
            
            project.Tasks.Add(storyTask);

            return storyTask;
        }

        public SimpleTask CreateSimpleTaskInProject(Project project, string taskName)
        {
            if (!TaskManager.IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var simpleTask = new SimpleTask
            {
                Id = nextId,
                Name = taskName,
                Executors = new List<User>(),
                CreationDate = DateTime.Now
            };
            
            project.Tasks.Add(simpleTask);

            return simpleTask;
        }

        public BugTask CreateBugTaskInProject(Project project, string taskName)
        {
            if (!TaskManager.IsProjectNameCorrect(taskName))
            {
                throw new ArgumentException("Task name is too long or starts with a digit.");
            }
            
            var nextId = project.Tasks.Select(task => task.Id).Prepend(0).Max() + 1;
            
            var bugTask = new BugTask
            {
                Id = nextId,
                Name = taskName,
                Executors = new List<User>(),
                CreationDate = DateTime.Now
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
            task.AddExecutor(GetUserById(user.Id));
        }

        /// <summary>
        /// Very simple method.
        /// </summary>
        /// <param name="task">IAssignable task object</param>
        /// <param name="user">User object</param>
        public void UnassignUserFromTask(IAssignable task, User user)
        {
            task.RemoveExecutor(GetUserById(user.Id));
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

            // Check epic tasks and remove it also from them.
            if (task is BugTask) return;
            
            foreach(var _task in project.Tasks)
            {
                if (_task is EpicTask epicTask)
                {
                    switch (task)
                    {
                        case SimpleTask spt:
                            epicTask.SimpleTasks.Remove(spt);
                            break;
                        case StoryTask stt:
                            epicTask.StoryTasks.Remove(stt);
                            break;
                    }
                }
            }
        }

        public void InsertTaskToEpic(Project project, IAssignable task, EpicTask epicTask)
        {
            switch (task)
            {
                case BugTask _:
                    throw new ArgumentException("Unable to insert bug task to the epic task.");
                case SimpleTask simple:
                    epicTask.SimpleTasks.Add(simple);
                    break;
                case StoryTask story:
                    epicTask.StoryTasks.Add(story);
                    break;
                default:
                    throw new ArgumentException("Invalid task.");
            }
        }
        
        public void RemoveTaskFromEpic(Project project, IAssignable task, EpicTask epicTask)
        {
            switch (task)
            {
                case BugTask _:
                    throw new ArgumentException("Unable to remove bug task from the epic task.");
                case SimpleTask simple when epicTask.SimpleTasks.Contains(simple):
                    epicTask.SimpleTasks.Remove(simple);
                    break;
                case StoryTask story when epicTask.StoryTasks.Contains(story):
                    epicTask.StoryTasks.Remove(story);
                    break;
                default:
                    throw new ArgumentException("This task wasn't located in this epic task.");
            }
            
        }
        
    }
}