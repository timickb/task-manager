using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class AddTaskCommand : ICommand
    {
        public string Name => "add_task";
        public string Usage => "<projectId> <taskType> <taskName>";

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

            try
            {
                // Check <taskType>.
                switch (args[2])
                {
                    case "epic":
                        tm.CreateEpicTaskInProject(project, args[3]);
                        break;
                    case "story":
                        tm.CreateStoryTaskInProject(project, args[3]);
                        break;
                    case "task":
                        tm.CreateSimpleTaskInProject(project, args[3]);
                        break;
                    case "bug":
                        tm.CreateBugTaskInProject(project, args[3]);
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