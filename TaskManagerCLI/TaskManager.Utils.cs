namespace TaskManagerCLI
{
    /// <summary>
    /// [Utils] Different useful static methods.
    /// </summary>
    public partial class TaskManager
    {
        /// <summary>
        /// Determines whether the user name doesn't start
        /// with a digit and it's length isn't more than 20 symbols.
        /// </summary>
        /// <param name="name">User name</param>
        /// <returns>true or false.</returns>
        public static bool IsUserNameCorrect(string name)
        {
            // First symbol can't be a digit.
            return name.Length > 0
                   && !int.TryParse(name[0].ToString(), out _)
                   && name.Length <= 20;
        }
        
        /// <summary>
        /// Determines whether the project name doesn't start
        /// with a digit and it's length isn't more than 40 symbols.
        /// </summary>
        /// <param name="name">Project name</param>
        /// <returns>true or false.</returns>
        public static bool IsProjectNameCorrect(string name)
        {
            // First symbol can't be a digit.
            return name.Length > 0
                   && !int.TryParse(name[0].ToString(), out _)
                   && name.Length <= 40;
        }
        
        /// <summary>
        /// Determines whether the project description doesn't start
        /// with a digit and it's length isn't more than 48 symbols.
        /// </summary>
        /// <param name="desc">Project description</param>
        /// <returns>true or false.</returns>
        public static bool IsProjectDescriptionCorrect(string desc)
        {
            // First symbol can't be a digit.
            return desc.Length > 0
                   && !int.TryParse(desc[0].ToString(), out _)
                   && desc.Length <= 48;
        }
        
    }
}