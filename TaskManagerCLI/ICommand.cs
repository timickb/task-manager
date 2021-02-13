namespace TaskManagerCLI
{
    public interface ICommand
    {
        public string Name { get; set; }

        public CommandExecutionResult Run(string[] args);
    }
}