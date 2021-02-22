using System;

namespace TaskManagerCLI.Commands
{
    public class CreateProjectCommand : ICommand
    {
        public string Name => "add_project";
        public string Usage => "<projectName>";
        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 2)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }
            
            // Try to add new project.
            try
            {
                TaskManager.GetInstance().CreateProject(args[1]);
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
                $"Project {args[1]} was successfully added.");
        }
    }
}