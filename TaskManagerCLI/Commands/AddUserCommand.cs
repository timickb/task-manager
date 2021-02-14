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

            var userName = args[1];
            if (!Utils.IsUserNameCorrect(args[1]))
            {
                return new CommandExecutionResult(
                    CommandExecutionStatus.Fail,
                    "User name is incorrect.");
            }

            // If everything is OK - add this user.
            TaskManager.GetInstance().Users.Add(new User
            {
                Id = Utils.GetNextUserId(),
                Name = args[1]
            });
            
            return new CommandExecutionResult(
                CommandExecutionStatus.OK,
                $"User {args[1]} was successfully added.");
        }
    }
}