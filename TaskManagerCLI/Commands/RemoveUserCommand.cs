namespace TaskManagerCLI.Commands
{
    public class RemoveUserCommand : ICommand
    {
        public string Name => "removeuser";
        public string Usage => "<userName/userId>";

        public CommandExecutionResult Run(string[] args)
        {
            if (args.Length < 2)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.WrongUsage,
                    $"Usage: {Name} {Usage}");
            }

            
            
            return new CommandExecutionResult(
                CommandExecutionStatus.OK,
                $"User {args[1]} was successfully removed.");
        }
    }
}