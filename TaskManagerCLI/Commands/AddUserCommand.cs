using System;
using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class AddUserCommand : ICommand
    {
        public string Name => "adduser";
        public string Usage => "<userName>";

        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 2)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }
            
            // Try to add new user.
            try
            {
                TaskManager.GetInstance().CreateUser(args[1]);
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
                $"User {args[1]} was successfully added.");
        }
    }
}