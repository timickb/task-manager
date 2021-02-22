using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class AddTaskCommand : IExecutable
    {
        public string Name => "add_task";
        public string Usage => "<projectId> <taskType> <taskName>";

        public string Description =>
            "Creates a task in project <projectId> with name <taskName> and with a type of status: story, task, bug, epic.";

        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 4)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }

            // Check <projectId>.
            if (!int.TryParse(args[1], out var projectId))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project Id must be an integer.");
            }

            var tm = TaskManager.GetInstance();

            var project = TaskManager.GetInstance().GetProjectById(projectId);

            if (project == null)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project with specified id doesn't exist.");
            }

            // If name has spaces we should concatenate all args after args[0]
            var taskName = args[3];
            for (var i = 4; i < args.Length; i++)
            {
                taskName += " " + args[i];
            }
            
            try
            {
                // Check <taskType>.
                switch (args[2])
                {
                    case "epic":
                        tm.CreateEpicTaskInProject(project, taskName);
                        break;
                    case "story":
                        tm.CreateStoryTaskInProject(project, taskName);
                        break;
                    case "task":
                        tm.CreateSimpleTaskInProject(project, taskName);
                        break;
                    case "bug":
                        tm.CreateBugTaskInProject(project, taskName);
                        break;
                    default:
                        return new CommandExecutionResult(CommandExecutionStatus.Fail,
                            "Unknown task type. Please select one from: epic, task, story, bug.");
                }
            }
            catch (ArgumentException e)
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    e.Message);
            }

            return new CommandExecutionResult(CommandExecutionStatus.OK,
                "Task was successfully added.");
        }
    }
}