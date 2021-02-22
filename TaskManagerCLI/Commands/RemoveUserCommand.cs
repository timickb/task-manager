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

            var tm = TaskManager.GetInstance();
            
            // If arg1 can be integer, find user by id. If not, find it by name.
            tm.RemoveUser(int.TryParse(args[1], out var userId)
                ? tm.GetUserById(userId)
                : tm.GetUserByName(args[1]));

            return new CommandExecutionResult(
                CommandExecutionStatus.OK,
                $"User {args[1]} was successfully removed.");
        }
    }
}