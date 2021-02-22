namespace TaskManagerCLI
{
    /// <summary>
    /// This interface defines that the
    /// object is a console command.
    /// </summary>
    public interface IExecutable
    {
        public string Name { get; }
        public string Usage { get; }
        
        public string Description { get; }

        public CommandExecutionResult Run(string[] args);
    }
}