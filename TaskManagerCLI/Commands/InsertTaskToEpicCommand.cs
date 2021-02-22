using System;
using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class InsertTaskToEpicCommand : IExecutable
    {
        public string Name => "insert_task_to_epic";
        public string Usage => "<projectId> <taskId> <epicTaskId>";

        public string Description =>
            "Moves the task <taskId> in project <projectId> from the main tasks list to the container <epicTaskId>.";

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

            if (!int.TryParse(args[3], out var epicTaskId))
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

            var epicTask = TaskManager.GetInstance().GetTaskByIdInProject(project, epicTaskId);

            if (epicTask == null)
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    $"Task with specified id doesn't exist in project with id {projectId}");
            }

            // Check whether the `task` IS NOT epic and whether the `epicTask` IS epic.
            if ((task is EpicTask) || !(epicTask is EpicTask))
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    $"Task with id {taskId} MUSTN'T be Epic, task with id {epicTaskId} MUST be epic!");
            }

            try
            {
                TaskManager.GetInstance().InsertTaskToEpic(project, task as IAssignable, epicTask as EpicTask);
            }
            catch (ArgumentException e)
            {
                return new CommandExecutionResult(CommandExecutionStatus.Fail,
                    e.Message);
            }

            return new CommandExecutionResult(CommandExecutionStatus.OK,
                "Success.");
        }
    }
}