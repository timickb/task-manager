namespace TaskManagerCLI
{
    /// <summary>
    /// Different static useful stuff.
    /// </summary>
    public partial class TaskManager
    {
        public static bool IsProjectNameCorrect(string name) => name.Length < 48;

        public static bool IsTaskNameCorrect(string name) => name.Length < 48;

        public static bool IsProjectDescriptionCorrect(string desc) => desc.Length < 100;

        public static bool IsTaskDescriptionCorrect(string desc) => desc.Length < 100;

        public static bool IsUserNameCorrect(string name) => name.Length < 20;
    }
}