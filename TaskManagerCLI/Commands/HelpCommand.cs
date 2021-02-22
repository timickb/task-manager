using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManagerCLI.Commands
{
    public class HelpCommand : IExecutable
    {
        public string Name => "help";
        public string Usage => "";
        public string Description => "Prints the list of all available commands and description for each of them.";

        public CommandExecutionResult Run(string[] args)
        {
            var cmdList = CommandExecutor.Commands;
            var result = cmdList.Aggregate("",
                (current, cmd) => current + $"* {cmd.Name} {cmd.Usage} | {cmd.Description}{Environment.NewLine}");

            return new CommandExecutionResult(CommandExecutionStatus.OK, result);
        }
    }
}