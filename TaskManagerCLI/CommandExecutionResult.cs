using System.Net.Mime;

namespace TaskManagerCLI
{
    public class CommandExecutionResult
    {
        /// <summary>
        /// The instance for unknown command case.
        /// </summary>
        public static readonly CommandExecutionResult UnknownCommand = new CommandExecutionResult()
        {
            TextOutput = "Unknown command. Type \"help\" to get a list of available commands."
        };

        /// <summary>
        /// The instance for "exit" command case.
        /// </summary>
        public static readonly CommandExecutionResult ExitCommand = new CommandExecutionResult()
        {
            TextOutput = "Bye!"
        };

        /// <summary>
        /// The visible content of the result.
        /// </summary>
        public string TextOutput { get; set; }
        
        /// <summary>
        /// Status of execution result.
        /// </summary>
        public CommandExecutionStatus Status { get; set; }

        /// <summary>
        /// Default constructor for commands.
        /// </summary>
        /// <param name="status">Execution result status.</param>
        /// <param name="textOutput">Text content of the result.</param>
        public CommandExecutionResult(CommandExecutionStatus status, string textOutput)
        {
            Status = status;
            TextOutput = textOutput;
        }

        /// <summary>
        /// Constructor for default instances.
        /// </summary>
        private CommandExecutionResult()
        {
            Status = CommandExecutionStatus.OK;
        }
        
        public override string ToString()
        {
            return TextOutput;
        }
    }
}