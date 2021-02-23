using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerAPI
{
    public partial class TaskManager
    {
        /// <summary>
        /// Creates epic task in specified project
        /// with specified name.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="taskName">task name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Exception throws when the task name
        /// is empty; when the task name is longer than 40 symbols and when in starts from a digit.</exception>
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

        /// <summary>
        /// Creates story task in specified project
        /// with specified name.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="taskName">task name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Exception throws when the task name
        /// is empty; when the task name is longer than 40 symbols and when in starts from a digit.</exception>
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
        
        /// <summary>
        /// Creates simple task in specified project
        /// with specified name.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="taskName">task name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Exception throws when the task name
        /// is empty; when the task name is longer than 40 symbols and when in starts from a digit.</exception>
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
        
        /// <summary>
        /// Creates bug task in specified project
        /// with specified name.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="taskName">task name</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException">Exception throws when the task name
        /// is empty; when the task name is longer than 40 symbols and when in starts from a digit.</exception>
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
        
        /// <summary>
        /// Moves task {task} to the subtasks list of the
        /// epic task {epicTask} in specified project.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="task">Simple/Story task object</param>
        /// <param name="epicTask">Epic task object</param>
        /// <exception cref="ArgumentException">Exception throws when the specified task is not
        /// simple or story.</exception>
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
        
        /// <summary>
        /// Moves task {task} from the subtasks list of the
        /// epic task {epicTask} to the general tasks list in specified project.
        /// </summary>
        /// <param name="project">Project object</param>
        /// <param name="task">Simple/Story task object</param>
        /// <param name="epicTask">Epic task object</param>
        /// <exception cref="ArgumentException">Exception throws when the specified task is not
        /// simple or story.</exception>
        public void RemoveTaskFromEpic(Project project, IAssignable task, EpicTask epicTask)
        {
            switch (task)
            {
                case BugTask _:
                    throw new ArgumentException("Unable to remove bug task from the epic task.");
                
                case SimpleTask simple:
                    if (epicTask.SimpleTasks.Any(t => t.Id == simple.Id))
                    {
                        epicTask.SimpleTasks.Remove(
                            epicTask.SimpleTasks.Find(t => t.Id == simple.Id));
                    }

                    break;

                case StoryTask story:
                    if (epicTask.StoryTasks.Any(t => t.Id == story.Id))
                    {
                        epicTask.StoryTasks.Remove(
                            epicTask.StoryTasks.Find(t => t.Id == story.Id));
                    }

                    break;
                default:
                    throw new ArgumentException("This task wasn't located in this epic task.");
            }
            
        }
        
    }
}