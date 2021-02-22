namespace TaskManagerCLI.Commands
{
    public class RemoveUserCommand : IExecutable
    {
        public string Name => "removeuser";
        public string Usage => "<userName/userId>";

        public string Description =>
            "Removes user with id <userId> OR name <userName> from the system. User will be automatically removed from all connected tasks.";

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
            var user = int.TryParse(args[1], out var userId) ? tm.GetUserById(userId) : tm.GetUserByName(args[1]);

            if (user == null)
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    $"This user doesn't exist.");
            }

            tm.RemoveUser(user);

            return new CommandExecutionResult(
                CommandExecutionStatus.OK,
                $"User {args[1]} was successfully removed.");
        }
    }
}