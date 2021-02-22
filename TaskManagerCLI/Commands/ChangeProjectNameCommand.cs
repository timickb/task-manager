namespace TaskManagerCLI.Commands
{
    public class ChangeProjectNameCommand : ICommand
    {
        public string Name => "change_project_name";
        public string Usage => "<projectId> <newProjectName>";

        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 3)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }

            if (!int.TryParse(args[1], out var projectId))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project Id must be an integer.");
            }

            if (!TaskManager.IsProjectNameCorrect(args[2]))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project name is incorrect.");
            }

            var project = TaskManager.GetInstance().GetProjectById(projectId);

            if (project == null)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project with specified id doesn't exist.");
            }

            project.Name = args[2];

            return new CommandExecutionResult(CommandExecutionStatus.OK,
                "Project name was successfully changed.");
        }
    }
}