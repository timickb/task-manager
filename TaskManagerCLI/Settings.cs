namespace TaskManagerCLI
{
    public class Settings
    {
        public int MaxTasksAmountInProject { get; }
        public Settings()
        {
            // Set default settings.
            MaxTasksAmountInProject = 16;
        }

        public void ReadSettings(string filePath)
        {
            // TODO: settings reading.
        }

        public void WriteSettings(string filePath)
        {
            // TODO: settings writing.
        }
    }
}