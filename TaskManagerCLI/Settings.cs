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

        public void ReadSettingsFromJSONFile(string filePath)
        {
            // TODO: settings reading.
        }

        public void WriteSettingsToJSONFile(string filePath)
        {
            // TODO: settings writing.
        }
    }
}