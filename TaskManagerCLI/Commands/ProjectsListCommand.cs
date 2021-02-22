using System;
using System.Linq;

namespace TaskManagerCLI.Commands
{
    public class ProjectsListCommand : IExecutable
    {
        public string Name => "projects";
        public string Usage => "";
        public CommandExecutionResult Run(string[] args)
        {
            var projects = TaskManager.GetInstance().Projects;

            if (projects.Count == 0)
            {
                return new CommandExecutionResult(CommandExecutionStatus.OK, "There are no projects in the system.");
            }
            
            var result = $"There are {projects.Count} projects:" + Environment.NewLine +
                         projects.Aggregate(string.Empty, (current, user) => current + (user + Environment.NewLine));

            return new CommandExecutionResult(CommandExecutionStatus.OK, result);
        }
    }
}