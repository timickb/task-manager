using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class RemoveProjectCommand : ICommand
    {
        public string Name => "remove_project";
        public string Usage => "<projectId>";
        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 2)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }

            var tm = TaskManager.GetInstance();

            Project project = null;
            
            if (int.TryParse(args[1], out var projectId))
            {
                project = tm.GetProjectById(projectId);
            }

            if (project == null)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail, 
                    $"This project doesn't exist.");
            }
            
            tm.RemoveProject(project);

            return new CommandExecutionResult(
                CommandExecutionStatus.OK,
                $"Project with id {args[1]} was successfully removed.");
        }
    }
}