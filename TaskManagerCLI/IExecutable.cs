namespace TaskManagerCLI
{
    public interface IExecutable
    {
        public string Name { get; }
        public string Usage { get; }

        public CommandExecutionResult Run(string[] args);
    }
}