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
            _commands = new List<IExecutable>();
            _commands.Add(new AddUserCommand());
            _commands.Add(new RemoveUserCommand());
            _commands.Add(new UsersListCommand());
            _commands.Add(new CreateProjectCommand());
            _commands.Add(new RemoveProjectCommand());
            _commands.Add(new ProjectsListCommand());
            _commands.Add(new ChangeProjectNameCommand());
            _commands.Add(new AddTaskCommand());
            _commands.Add(new TasksListCommand());
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

            // If command "commandName" wasn't found, execute the default command.
        }
    }
}