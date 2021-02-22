using System;

namespace TaskManagerCLI.Commands
{
    public class CreateProjectCommand : IExecutable
    {
        public string Name => "add_project";
        public string Usage => "<projectName>";
        public string Description => "Creates project with name <projectName>. <projectName> can contain spaces.";

        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 2)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }
            
            // If name has spaces we should concatenate all args after args[1]
            var projectName = args[1];
            for (var i = 2; i < args.Length; i++)
            {
                projectName += " " + args[i];
            }
            
            // Try to add new project.
            try
            {
                TaskManagerAPI.TaskManager.GetInstance().CreateProject(projectName);
            }
            catch (ArgumentException e)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    e.Message
                );
            }
            
            // If everything is OK - return "OK" result.
            return new CommandExecutionResult(
                CommandExecutionStatus.OK,
                $"Project {projectName} was successfully added.");
        }
    }
}