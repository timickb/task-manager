using System;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class TasksListCommand : IExecutable
    {
        public string Name => "tasks";
        public string Usage => "<projectId>";
        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 2)
            {
                return new CommandExecutionResult(CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }
            
            if (!int.TryParse(args[1], out var projectId))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project Id must be an integer.");
            }
            
            var project = TaskManager.GetInstance().GetProjectById(projectId);

            if (project == null)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project with specified id doesn't exist.");
            }

            var tasks = project.Tasks;
            if (tasks.Count == 0)
            {
                return new CommandExecutionResult(CommandExecutionStatus.OK,
                    $"There are no tasks in project with id {projectId}");
            }

            var result = $"There are {tasks.Count} tasks in project:";
            // Sorting by status.
            result = tasks.Where(t => t.Status == TaskStatus.Opened).Aggregate(result, (current, task) => current + (task + Environment.NewLine));
            result = tasks.Where(t => t.Status == TaskStatus.InProgress).Aggregate(result, (current, task) => current + (task + Environment.NewLine));
            result = tasks.Where(t => t.Status == TaskStatus.Closed).Aggregate(result, (current, task) => current + (task + Environment.NewLine));

            return new CommandExecutionResult(CommandExecutionStatus.OK, result);

        }
    }
}