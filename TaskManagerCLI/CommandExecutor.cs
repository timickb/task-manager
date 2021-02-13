using System.Collections.Generic;
using System.Linq;
using TaskManagerCLI.Commands;

namespace TaskManagerCLI
{
    public class CommandExecutor
    {
        private List<ICommand> _commands;

        public CommandExecutor()
        {
            _commands = new List<ICommand>();
            _commands.Add(new AddUserCommand());
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

            if (commandName == Program.ExitCommand)
            {
                return CommandExecutionResult.ExitCommand;
            }
            
            // If command "commandName" wasn't found, execute the default command.
            return CommandExecutionResult.UnknownCommand;
        }
    }
}