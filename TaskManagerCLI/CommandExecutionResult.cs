using System.Net.Mime;

namespace TaskManagerCLI
{
    public class CommandExecutionResult
    {
        /// <summary>
        /// The instance for unknown command case.
        /// </summary>
        public static CommandExecutionResult UnknownCommand = new CommandExecutionResult()
        {
            TextOutput = "Unknown command. Type \"help\" to get a list of available commands."
        };

        /// <summary>
        /// The instance for "exit" command case.
        /// </summary>
        public static CommandExecutionResult ExitCommand = new CommandExecutionResult()
        {
            TextOutput = "Bye!"
        };
        
        /// <summary>
        /// The visible content of the result.
        /// </summary>
        public string TextOutput { get; set; }

        public override string ToString()
        {
            return TextOutput;
        }
    }
}