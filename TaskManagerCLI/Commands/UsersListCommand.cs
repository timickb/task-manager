using System;
using System.Collections.Generic;
using System.Linq;
using TaskManagerAPI;

namespace TaskManagerCLI.Commands
{
    public class UsersListCommand : IExecutable
    {
        public string Name => "users";
        public string Usage => "";

        public CommandExecutionResult Run(string[] args)
        {
            var users = TaskManager.GetInstance().Users;

            if (users.Count == 0)
            {
                return new CommandExecutionResult(CommandExecutionStatus.OK, "There are no users in the system.");
            }
            
            var result = $"There are {users.Count} users:" + Environment.NewLine +
                users.Aggregate(string.Empty, (current, user) => current + (user + Environment.NewLine));

            return new CommandExecutionResult(CommandExecutionStatus.OK, result);
        }
    }
}