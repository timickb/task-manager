using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class SetTaskStatusCommand : IExecutable
    {
        public string Name => "set_task_status";
        public string Usage => "<projectId> <taskId> <opened | inProgress | closed>";

        public string Description =>
            "Changes the status of task <taskId> in project <projectId> to one from list: opened, inProgress, closed.";

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

            switch (args[3])
            {
                case "opened":
                    TaskManager.GetInstance().SetTaskStatus(task, TaskStatus.Opened);
                    break;
                case "closed":
                    TaskManager.GetInstance().SetTaskStatus(task, TaskStatus.Closed);
                    break;
                case "inProgress":
                    TaskManager.GetInstance().SetTaskStatus(task, TaskStatus.InProgress);
                    break;
                default:
                    return new CommandExecutionResult(CommandExecutionStatus.Fail,
                        "Incorrect task status. Choose one from: opened, inProgress, closed.");
            }

            return new CommandExecutionResult(CommandExecutionStatus.OK,
                "Task status was successfully changed.");
        }
    }
}