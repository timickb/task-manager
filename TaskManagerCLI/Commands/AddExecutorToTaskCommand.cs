using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class AddExecutorToTaskCommand : IExecutable
    {
        public string Name => "add_executor";
        public string Usage => "<projectId> <taskId> <userId>";
        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 4)
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
            
            if (!int.TryParse(args[2], out var taskId))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "Task Id must be an integer.");
            }
            
            if (!int.TryParse(args[3], out var userId))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "User Id must be an integer.");
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

            var user = TaskManager.GetInstance().GetUserById(userId);
            
            if (user == null)
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    "User with specified id doesn't exist.");
            }

            if (!(task is IAssignable))
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    "Task must be assignable.");
            }

            try
            {
                TaskManager.GetInstance().AssignUserToTask(task as IAssignable, user);
            }
            catch (AssigningException e)
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    e.Message);
            }

            return new CommandExecutionResult(CommandExecutionStatus.OK,
                $"User with id {userId} was successfully assigned to the task with id {taskId}" +
                "in project with id {projectId}.");

        }
    }
}