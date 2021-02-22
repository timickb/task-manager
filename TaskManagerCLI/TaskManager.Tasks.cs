using System;
using System.Collections.Generic;
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
                Name = taskName
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
    }
}