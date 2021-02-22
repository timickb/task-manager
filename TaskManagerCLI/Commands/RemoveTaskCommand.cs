namespace TaskManagerCLI.Commands
{
    public class RemoveTaskCommand : IExecutable
    {
        public string Name => "remove_task";
        public string Usage => "<projectId> <taskId>";
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
            
            if (!int.TryParse(args[2], out var taskId))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Task Id must be an integer.");
            }
            
            var project = TaskManager.GetInstance().GetProjectById(projectId);

            if (project == null)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Project with specified id doesn't exist.");
            }

            var task = TaskManager.GetInstance().GetTaskByIdInProject(project, taskId);

            if (task == null)
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    $"Task with specified id doesn't exist in project with id {projectId}");
            }
            
            TaskManager.GetInstance().RemoveTaskFromProject(project, task);

            return new CommandExecutionResult(CommandExecutionStatus.OK,
                "Task was successfully removed.");
        }
    }
}