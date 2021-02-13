namespace TaskManagerCLI
{
    public interface ICommand
    {
        public string Name { get; }
        public string Usage { get; }

        public CommandExecutionResult Run(string[] args);
    }
}