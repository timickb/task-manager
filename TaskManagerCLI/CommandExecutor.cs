using System.Collections.Generic;
using System.Linq;
using TaskManagerCLI.Commands;

namespace TaskManagerCLI
{
    public class CommandExecutor
    {
        private readonly List<IExecutable> _commands;

        public CommandExecutor()
        {
            _commands = new List<IExecutable>
            {
                new AddUserCommand(),
                new RemoveUserCommand(),
                new UsersListCommand(),
                new CreateProjectCommand(),
                new RemoveProjectCommand(),
                new ProjectsListCommand(),
                new ChangeProjectNameCommand(),
                new AddTaskCommand(),
                new TasksListCommand(),
                new AddExecutorToTaskCommand(),
                new RemoveExecutorFromTaskCommand(),
                new SetTaskStatusCommand(),
                new InsertTaskToEpicCommand(),
                new RemoveTaskFromEpicCommand()
            };
        }

        /// <summary>
        /// Starts the commands execution.
        /// </summary>
        /// <param name="input">The command entered by user in CLI.</param>
        /// <returns>The result of command execution.</returns>
        public CommandExecutionResult Execute(string input)
        {
            var args = input.Split(' ');
            var commandName = args[0];

            // Find the command with name=commandName and execute it.
            foreach (var command in _commands.Where(command => command.Name == commandName))
            {
                return command.Run(args);
            }

            return commandName == Program.ExitCommand
                ? CommandExecutionResult.ExitCommand
                : CommandExecutionResult.UnknownCommand;
        }
    }
}